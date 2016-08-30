using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Threading;
using System.Threading.Tasks;
using FISCA;
using System.Data;
using FISCA.Data;
using System.Collections.Concurrent;

namespace AttendanceReadCard
{
    internal class StudentRecordFinder
    {
		private Dictionary<string, Dictionary<string, StudentRecord>> Students { get; set; }
		private Dictionary<string, StudentRecord> dicStudentNumbers { get; set; }

		private Dictionary<string, ClassRecord> classes = new Dictionary<string, ClassRecord>();

        private Exception LoadDataError { get; set; }

        private ManualResetEvent Wait = new ManualResetEvent(true);

        public StudentRecordFinder()
        {
            LoadDataError = null;

            Wait.Reset();

            Task task = Task.Factory.StartNew(() => LoadData(),
                new CancellationToken(),
                TaskCreationOptions.None,
                TaskScheduler.Default);
        }

        private void LoadData()
        {
            try
            {
                Students = new Dictionary<string, Dictionary<string, StudentRecord>>();
				dicStudentNumbers = new Dictionary<string, StudentRecord>();

                foreach (ClassRecord cr in Class.SelectAll())
                    classes.Add(cr.ID, cr);

				//	先找在學生的系統編號
				DataTable table = (new QueryHelper()).Select(string.Format("select array_to_string(ARRAY_AGG(id),',') as student_id from student where status in (1, 2)"));
				if (table == null || table.Rows.Count == 0)
					throw new Exception("無在校生。");
				//	分批在學生的系統編號
				string[] StudentIDs = (table.Rows[0][0] + "").Split(new char[] { ',' });
				IEnumerable<IGrouping<int, string>> divided_groups = StudentIDs.Select((item, index) => new { item, index }).GroupBy(x => x.index / 150, x => x.item);
				int divide_count = divided_groups.Count();
				BlockingCollection<IEnumerable<StudentRecord>> Records = new BlockingCollection<IEnumerable<StudentRecord>>(divide_count);
				//	以分批後的系統編號批次取得資料
				Parallel.ForEach(divided_groups, (item) =>
				{
					IEnumerable<StudentRecord> records = Student.SelectByIDs(item);
					Records.Add(records);
				});
				//	最後再合併
				List<StudentRecord> StudentRecords = new List<StudentRecord>();
				foreach (IEnumerable<StudentRecord> x in Records)
				{
					StudentRecords.AddRange(x);
				}

				foreach (StudentRecord sr in StudentRecords)
                {
                    //沒有班級不處理。
                    if (string.IsNullOrWhiteSpace(sr.RefClassID))
                        continue;

                    //沒有座號不處理。
                    if (string.IsNullOrWhiteSpace(sr.SeatNo + ""))
						continue;

					//沒有學號不處理。
					if (string.IsNullOrWhiteSpace(sr.StudentNumber + ""))
						continue;

                    ClassRecord cr = classes[sr.RefClassID];

                    if (!Students.ContainsKey(cr.Name))
                        Students.Add(cr.Name, new Dictionary<string, StudentRecord>());

                    if (!Students[cr.Name].ContainsKey(sr.SeatNo + ""))
                        Students[cr.Name].Add(sr.SeatNo + "", sr);

					if (!dicStudentNumbers.ContainsKey(sr.StudentNumber.Trim().ToLower()))
						dicStudentNumbers.Add(sr.StudentNumber.Trim().ToLower(), sr);
				
                }
            }
            catch (Exception ex)
            {
                LoadDataError = ex;
                RTOut.WriteError(ex);
            }
            finally
            {
                Wait.Set();
            }
        }

		public ClassRecord FindClass(string studentNumber)
		{
			Wait.WaitOne();

			if (LoadDataError != null)
				throw LoadDataError;

			if (dicStudentNumbers.ContainsKey(studentNumber.Trim().ToLower()))
			{
				string class_id = dicStudentNumbers[studentNumber.Trim().ToLower()].RefClassID;

				if (this.classes.ContainsKey(class_id))
					return this.classes[class_id];
				else
					return null;
			}
			else
				return null;
		}

        public StudentRecord Find(string className, string seatNo)
        {
            Wait.WaitOne();

            if (LoadDataError != null)
                throw LoadDataError;

            if (Students.ContainsKey(className))
            {
                if (Students[className].ContainsKey(seatNo))
                    return Students[className][seatNo];
                else
                    return null;
            }
            else
                return null;
        }

		public StudentRecord Find(string studentNumber)
		{
			Wait.WaitOne();

			if (LoadDataError != null)
				throw LoadDataError;

			if (dicStudentNumbers.ContainsKey(studentNumber.Trim().ToLower()))
			{
				return dicStudentNumbers[studentNumber.Trim().ToLower()];
			}
			else
				return null;
		}
    }
}
