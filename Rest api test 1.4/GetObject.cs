using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rest_api_test_1._4
{
	public class GetObject
	{
		public static string GetCompany(string dbValue) //get name of Company
		{
			string returnQuery = BaseMethods.GetDataFromDb("select dep_name from firmnum where dep_name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetDeletedCompany(string dbValue) //get name of Company
		{
			string returnQuery = BaseMethods.GetDataFromDb("select dep_name from firmnum where dep_name = '" + dbValue + "'");
			return returnQuery;
		}

		public static string GetDepartment(string dbValue) //get name of Department
		{
			string returnQuery = BaseMethods.GetDataFromDb("select dep_name from departnum where dep_name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetDeletedDepartment(string dbValue) //get name of Department
		{
			string returnQuery = BaseMethods.GetDataFromDb("select dep_name from departnum where dep_name = '" + dbValue + "'");
			return returnQuery;
		}

		public static string GetEmployee(string dbValue) //get name of Employee
		{
			BaseMethods.ExecuteSqlQuery("workernumactual.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select worker_name from workernumactual where worker_name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}
		
		public static string GetEmployeeId(string dbValue) //get name of Employee
		{
			BaseMethods.ExecuteSqlQuery("workernumactual.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select worker_id from workernumactual where worker_id = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}
		
		public static string GetDeletedEmployee(string dbValue) //get name of deleted Employee
		{
			BaseMethods.ExecuteSqlQuery("workernumactual.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select worker_name from workernumactual where worker_name = '" + dbValue + "'");
			return returnQuery;
		}

		public static string GetEmployeeSum() //get name of Employee
		{
			BaseMethods.ExecuteSqlQuery("workernumactual.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select count(*) from workernumactual");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetPosition(string dbValue) //get Position
		{
			string returnQuery = BaseMethods.GetDataFromDb("select job_name from jobnum where job_name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetDeletedPosition(string dbValue) //get deleted Position
		{
			string returnQuery = BaseMethods.GetDataFromDb("select job_name from jobnum where job_name = '" + dbValue + "'");
			return returnQuery;
		}

		public static string GetUserName(string dbValue) //get name of User Name
		{
			BaseMethods.ExecuteSqlQuery("username.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from username where value = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetUserId(string dbValue) //get name of User Name
		{
			BaseMethods.ExecuteSqlQuery("username.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select obj_id from username where obj_id = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetLog(string dbValue) //get name of User Name
		{
			string returnQuery = BaseMethods.GetDataFromDb("select time from restapi.log where time = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetDevice(string dbValue) //get name of Device
		{
			string returnQuery = BaseMethods.GetDataFromDb("select type from terminalparam where type = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetCheckpoint(string dbValue) //get name of Device
		{
			string returnQuery = BaseMethods.GetDataFromDb("select name from restapi.checkpoint where name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}

		public static string GetReport(string dbValue) //get name of Report
		{
			string returnQuery = BaseMethods.GetDataFromDb("select name from reports_hidden_status where name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				Assert.Fail();
			}
			return returnQuery;
		}


		/*
			int i = 0;

			public string GetRecuredEmployee(string dbValue) //get name of Recured Employee
			{					
				string returnQuery = BaseMethods.GetDataFromDb("select worker_name from workernumstate where worker_state IS DISTINCT FROM 'd' and worker_name = '" + dbValue + "'");
				if (returnQuery == string.Empty)
				{				
					BaseMethods.Log("workernumactual", "dbValue is not exist or was deleted from BS", i++);
					Assert.Fail();
				}		
				return returnQuery;	
			}

			public string GetCard(string dbValue) //get name of Card
			{
			string returnQuery = BaseMethods.GetDataFromDb("SELECT num_card from workercard where num_card = '" + dbValue + "'");	
				if (returnQuery == string.Empty)
				{				
					BaseMethods.Log("workercard", "dbValue is not exist or was deleted from BS", i++);
					Assert.Fail();
				}
			return returnQuery;	
			}

			/*
			// Доработать!!!
			public string GetNotCard(string dbValue) //get null Card
			{
			string returnQuery = BaseMethods.GetDataFromDb("SELECT card_hex from card where card_hex = 'c9b365'");	
				if (returnQuery == string.Empty)
				{				
					BaseMethods.Log("card", "dbValue is not exist or was deleted from BS", i++);
					Assert.Fail();
				}
			return returnQuery;	
			}


		public string GetDeletedAtAllEmployee(string dbValue) //get name of Deleted at all Employee
		{
			string returnQuery = BaseMethods.GetDataFromDb("select worker_name from workernumstate where worker_state IS NOT DISTINCT FROM 'd' and  worker_name = '" + dbValue + "'");
			return returnQuery;
		}


		public string GetAccessZone(string dbValue) //get name of Access Zone
		{
			string returnQuery = BaseMethods.GetDataFromDb("SELECT name from policyparam where name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("policyparam", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetDesign(string dbValue) //get name of Design
		{
			BaseMethods.ExecuteSqlQuery("design.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from design where value = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("design", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetAccessShedule(string dbValue) //get name of Access Shedule
		{
			string returnQuery = BaseMethods.GetDataFromDb("select sched_name from schedules where sched_name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("schedules", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetReportDesign(string dbValue) //get name of Access Shedule
		{
			BaseMethods.ExecuteSqlQuery("reportdesign.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from reportdesign where value = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("reportdesign", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetSchedule(string dbValue) //get name of Schedule
		{
			string returnQuery = BaseMethods.GetDataFromDb("select name from schedule where name = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("schedule", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetMnemoschema(string dbValue) //get name of Schedule
		{
			BaseMethods.ExecuteSqlQuery("mnemoschema.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from mnemoschema where value = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("mnemoschema", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetPlacement(string dbValue) //get name of Placement
		{
			BaseMethods.ExecuteSqlQuery("placement.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from placement where value = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("placement", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetAttendanceRules(string dbValue) //get name of Attendance Rules
		{
			BaseMethods.ExecuteSqlQuery("attendancerules.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from attendancerules where value = '" + dbValue + "'");
			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("attendancerules", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}



		public string GetUserRole(string dbValue) //get name of User Role
		{
			BaseMethods.ExecuteSqlQuery("userrole.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from userrole where value = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("userrole", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetTaskSched(string dbValue) //get name of User Role
		{
			BaseMethods.ExecuteSqlQuery("taskscheduler.sql");

			string returnQuery = BaseMethods.GetDataFromDb("select value from taskscheduler where value = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("taskscheduler", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetQuestion(string dbValue) //get name of Question
		{
			BaseMethods.ExecuteSqlQuery("question.sql");
			string returnQuery = BaseMethods.GetDataFromDb("select value from question where value = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("question", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetConfirmList(string dbValue) //get name of Confirm List
		{
			BaseMethods.ExecuteSqlQuery("confirmlist.sql");
			string returnQuery = BaseMethods.GetDataFromDb("select value from confirmlist where value = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("confirmlist", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}

		public string GetRoleTemplate(string dbValue) //get name of Role Template
		{
			string returnQuery = BaseMethods.GetDataFromDb("select interface_name from role_template where interface_name = '" + dbValue + "'");

			if (returnQuery == string.Empty)
			{
				BaseMethods.Log("role_template", "dbValue is not exist or was deleted from BS", i++);
				Assert.Fail();
			}
			return returnQuery;
		}
		 */
	}
}
