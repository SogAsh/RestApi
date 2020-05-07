using System;
using System.Collections.Generic;
using System.Text;

namespace Rest_api_test_1._4
{
    public static class BaseData
	{
		#region Company
		public const string Company_Name = "Company"; 
		public const string Company_Depnum = "100"; 
		public const string Company_Name2 = "Firm"; 
		public const string Company_Depnum2 = "101"; 
		public const string Company_Name3 = "Shop"; 
		public const string Company_Depnum3 = "102"; 
		public const string Company_Name4 = "Store"; 
		public const string Company_Depnum4 = "104";
		public const int Company_Start_Id = 67200000;
		public const int Company_Finish_Id = 67300000;
		#endregion

		#region Departmanet
		public const string Departmanet_Name = "Department"; 
		public const string Departmanet_Num = "200"; 
		public const string Departmanet_Name1 = "IT Department"; 
		public const string Departmanet_Num1 = "201"; 
		public const string Departmanet_Name2 = "Big Department"; 
		public const string Departmanet_Num2 = "202"; 
		public const string Departmanet_Name3 = "Sell Department"; 
		public const string Departmanet_Num3 = "203";
		#endregion

		#region names
		public static string [] names = new string[] 
			        {
						"EMIS",
						"Администрация",
						"Бухгалтерия",
						"Обслуживание производства",
						"Отдел",
						"Отдел закупок"
					};
		#endregion

		#region permissionarr
		public static string[] permissionarr = new string[]
		{
				"Доступ без ограничений"
		};
		#endregion

		#region Employee
		public const string Employee_Last_Name1 = "Petrov"; 
		public const string Employee_First_Name1 = "Petr"; 
		public const string Employee_Middle_Name1 = "Petrovich"; 
		public const string Employee_Full_Name1 = "Petrov Petr Petrovich"; 
		public const string Employee_Work_Num1 = "100"; 
		public const string Employee_Photo1 = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDABIMDRANCxIQDhAUExIVGywdGxgYGzYnKSAsQDlEQz85Pj1HUGZXR0thTT0+WXlaYWltcnNyRVV9hnxvhWZwcm7/2wBDARMUFBsXGzQdHTRuST5Jbm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm5ubm7/wAARCABAADEDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwDsMUYFFBOBmmAbRRtFcmfEN9qE7C0QW8CnhiMu39BUitek7vtMuf8AfNS5pFqDaudRgUmBXNr4imsrqOO+UPA5x5qjDIfcdxXSZ4pp3JasGBRSUUxDhUVyM28o9VP8qkHSqOswmayOCwKkMCD+H9aG7IaV3Y5vSUVU2Dse9bqxL5eTXORSXMPlmCJZCwBAJxk4zjnpWvHqExtWd7cqyHBQMDn6GsOputjM15V8pgR94gCuwgVkt41kbc4UBm9TiuMujcXsqie38kB1yd4bHI9K7G0RktY1cksFGc+tXAzqdyWiiitDMUU2RFkQq4yp6il3ADmsHWvFdlYROlvIlxc4wqIcqD7kfy60AUL6ZbDVJYSAYzzz0FRrqsK7gd27zMgYGMfXp+HWsJ2cW0d2rNIr8Tbzk7j1P0P880okURZ3LtxjGTWMo2Z0QndHT6XJFqOqbB/q4lL4XoTwP6103avOLTUpNHaK/QBnlbb5Z7xf0JOPpt9662w8WaVe8ef5D/3Zxt/Xp+taRjZGMpczNqimean98fnRVEnlWpaze6o+bqYlM5Ea8KvXt+PU81RoooA1NIvRArJIFKEHKkcEe9QRvYjUCWjkNvn5Vzn/AOvj9aqRMQ/HelBHm5I7UxF3V7gTyrsxt6gD9Kz6dIcuabSe4IKKKKQz/9k="; //--

		public const string Employee_Last_Name2 = "Sidorov"; 
		public const string Employee_First_Name2 = "Ivan"; 
		public const string Employee_Middle_Name2 = "Sidorovich";
		public const string Employee_Work_Num2 = "101"; 
		public const string Employee_Full_Name2 = "Sidorov Ivan Sidorovich";

		public const string Employee_Last_Name3 = "Petrova"; 
		public const string Employee_First_Name3 = "Anna"; 
		public const string Employee_Middle_Name3 = "Petrovna"; 
		public const string Employee_Work_Num3 = "102"; 
		public const string Employee_Full_Name3 = "Petrova Anna Petrovna";

		public const string Employee_Last_Name4 = "Bogdan"; 
		public const string Employee_First_Name4 = "Yan"; 
		public const string Employee_Middle_Name4 = "Bogdanovich";
		public const string Employee_Full_Name4 = "Bogdan Yan Bogdanovich"; 
		public const string Employee_Work_Num4 = "103";

		public const int Employee_Start_Id = 67200000;
		public const int Employee_Finish_Id = 67300000;

		#endregion

		#region Position
		public const string Position1 = "Chief"; 
		public const string Position1_Code = "301"; 
		public const string Position1_Num = "302"; 
		public const string Position2 = "Exec"; 
		public const string Position2_Code = "303"; 
		public const string Position2_Num = "304"; 
		public const string Position3 = "Counter"; 
		public const string Position3_Code = "305"; 
		public const string Position3_Num = "306";
		public const int Position_Start_Id = 67200000;
		public const int Position_Finish_Id = 67300000;
		#endregion

		#region User
		public const string UserRoot = "root";
		public const string UserRootId = "67200001";
		public const string UserGuard = "guard";
		public const string UserService = "service";
		#endregion

		#region Device
		public const string Device_Port = "20002"; 
		public const string Device_Type = "OT_TERM_BS_PV_WTC_2";
		#endregion

		#region Checkpoint
		public const string Checkpoint_Name = "Проходная";
		public const int Checkpoint_Direction = 1;
		public const string Checkpoint_Time = "2020-05-03T15:00"; //"2020-05-03 15:00:00"
		public const string Checkpoint_Time2 = "Вс.03.05.2020 15:00:00";
		#endregion

		#region Report
		public const string Report_Name = "REPORT_WORKTIME_DETAILS";
		#endregion

		#region Worktime
		public const string Worktime = "2020-04-30T09:00:00+50:00";
		#endregion
	}

}
