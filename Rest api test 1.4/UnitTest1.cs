using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serialization.Json;
using NUnit.Framework;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Rest_api_test_1._4
{
    [TestFixture]
    public class UnitTest1
    {
        public static int orgstructureId;
        public static string orgstructureName;

        [Test]
        public async Task POSTOrgstructure()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = BaseData.Company_Name,
                depnum = BaseData.Company_Depnum
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            orgstructureId = Orgstructure.id;
            orgstructureName = Orgstructure.name;
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Company_Name), "orgstructure name is nor correct");

            string actualtext = GetObject.GetCompany(BaseData.Company_Name);
            Assert.AreEqual(BaseData.Company_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int departmentId;

        [Test]
        public async Task POSTDepartment()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/", Method.POST);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();

            request.AddJsonBody(new
            {
                name = BaseData.Departmanet_Name,
                parent = orgstructureId,
                depnum = BaseData.Departmanet_Num
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            departmentId = Orgstructure.id;
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Departmanet_Name), "orgstructure name is nor correct");

            string actualtext = GetObject.GetDepartment(BaseData.Departmanet_Name);
            Assert.AreEqual(BaseData.Departmanet_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int orgstructureDeleteId;
        [Test]
        public async Task POSTOrgstructureForDelete()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = BaseData.Company_Name4,
                depnum = BaseData.Company_Depnum4
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            orgstructureDeleteId = Orgstructure.id;
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Company_Name4), "orgstructure name is nor correct");

            string actualtext = GetObject.GetCompany(BaseData.Company_Name4);
            Assert.AreEqual(BaseData.Company_Name4, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int departmentDeleteId;

        [Test]
        public async Task POSTDepartmentForDelete()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/", Method.POST);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();

            request.AddJsonBody(new
            {
                name = BaseData.Departmanet_Name3,
                depnum = BaseData.Departmanet_Num3,
                parent = orgstructureId
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            departmentDeleteId = Orgstructure.id;
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Departmanet_Name3), "orgstructure name is nor correct");

            string actualtext = GetObject.GetDepartment(BaseData.Departmanet_Name3);
            Assert.AreEqual(BaseData.Departmanet_Name3, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int employeeId;

        [Test]
        public async Task POSTEmployee()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/", Method.POST);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            POSTJob();

            request.AddJsonBody(new
            {
                workernum = BaseData.Employee_Work_Num1,
                parent = orgstructureId,
                job = jobId,
                first_name = BaseData.Employee_First_Name1,
                last_name = BaseData.Employee_Last_Name1,
                middle_name = BaseData.Employee_Middle_Name1
                //photo = BaseData.Employee_Photo1
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            employeeId = Employee.id;
            Assert.That(Employee.last_name, Is.EqualTo(BaseData.Employee_Last_Name1), "employee name is nor correct");

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name1);
            Assert.AreEqual(BaseData.Employee_Full_Name1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int employeeDeleteid;

        [Test]
        public async Task POSTEmployeeForDelete()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/", Method.POST);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            POSTJobForDelete();

            request.AddJsonBody(new
            {
                workernum = BaseData.Employee_Work_Num4,
                parent = orgstructureId,
                job = jobDeletedId,
                first_name = BaseData.Employee_First_Name4,
                last_name = BaseData.Employee_Last_Name4,
                middle_name = BaseData.Employee_Middle_Name4
                //photo = BaseData.Employee_Photo1
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            employeeDeleteid = Employee.id;
            Assert.That(Employee.last_name, Is.EqualTo(BaseData.Employee_Last_Name4), "employee name is nor correct");

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name4);
            Assert.AreEqual(BaseData.Employee_Full_Name4, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETOrgstructure()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTOrgstructure();
            var request = new RestRequest("orgstructure/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Orgstructure>>(response.Content);
            var name = rootObject.results[0].name;

            string actualtext = GetObject.GetCompany(orgstructureName);
            Assert.AreEqual(orgstructureName, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETOrgstructureId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            request.AddUrlSegment("orgstructureid", orgstructureId);
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Company_Name), "orgstructure name is nor correct");

            string actualtext = GetObject.GetCompany(BaseData.Company_Name);
            Assert.AreEqual(BaseData.Company_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PUTOrgstructureId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.PUT);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            request.AddUrlSegment("orgstructureid", orgstructureId);
            request.AddJsonBody(new
            {
                name = BaseData.Company_Name2,
                depnum = BaseData.Company_Depnum2
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Company_Name2), "orgstructure name is nor correct");

            string actualtext = GetObject.GetCompany(BaseData.Company_Name2);
            Assert.AreEqual(BaseData.Company_Name2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PUTDepartmentId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.PUT);
            request.AddHeader("Accept", "application/json");

            POSTDepartment();
            request.AddUrlSegment("orgstructureid", departmentId);

            request.AddJsonBody(new
            {
                depnum = BaseData.Departmanet_Num1,
                name = BaseData.Departmanet_Name1,
                parent = orgstructureId
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Departmanet_Name1), "orgstructure name is nor correct");

            string actualtext = GetObject.GetDepartment(BaseData.Departmanet_Name1);
            Assert.AreEqual(BaseData.Departmanet_Name1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PATCHOrgstructureId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.PATCH);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            request.AddUrlSegment("orgstructureid", orgstructureId);

            request.AddJsonBody(new
            {
                name = BaseData.Company_Name3,
                depnum = BaseData.Company_Depnum3
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Company_Name3), "orgstructure name is nor correct");

            string actualtext = GetObject.GetCompany(BaseData.Company_Name3);
            Assert.AreEqual(BaseData.Company_Name3, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PATCHDepartmentId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.PATCH);
            request.AddHeader("Accept", "application/json");

            POSTDepartment();
            request.AddUrlSegment("orgstructureid", departmentId);

            request.AddJsonBody(new
            {
                depnum = BaseData.Departmanet_Num2,
                name = BaseData.Departmanet_Name2,
                parent = orgstructureId
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.That(Orgstructure.name, Is.EqualTo(BaseData.Departmanet_Name2), "orgstructure name is nor correct");

            string actualtext = GetObject.GetDepartment(BaseData.Departmanet_Name2);
            Assert.AreEqual(BaseData.Departmanet_Name2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task DELETEOrgstructureId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            POSTCleanerOrgstructure();
            POSTOrgstructureForDelete();
            request.AddUrlSegment("orgstructureid", orgstructureDeleteId);

            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.IsNull(Orgstructure, "orgstructure name is nor correct");

            string actualtext = GetObject.GetDeletedCompany(BaseData.Company_Name3);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task DELETEDepartmentId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("orgstructure/{orgstructureid}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            POSTDepartmentForDelete();
            request.AddUrlSegment("orgstructureid", departmentDeleteId);
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.IsNull(Orgstructure, "orgstructure name is nor correct");

            string actualtext = GetObject.GetDeletedCompany(BaseData.Company_Name3);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETEmployee()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTEmployee();
            var request = new RestRequest("employee/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Employee>>(response.Content);
            var last_name = rootObject.results[0].last_name;
            employeeId = rootObject.results[0].id;
            //Assert.That(last_name, Is.EqualTo(BaseData.Employee_Last_Name1), "employee last_name is nor correct");

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name1);
            Assert.AreEqual(BaseData.Employee_Full_Name1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETEmployeeId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/{employeeid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            POSTEmployee();
            request.AddUrlSegment("employeeid", employeeId);
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.That(Employee.last_name, Is.EqualTo(BaseData.Employee_Last_Name1), "employee name is nor correct");

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name1);
            Assert.AreEqual(BaseData.Employee_Full_Name1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PUTEmployeeId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/{employeeid}", Method.PUT);
            request.AddHeader("Accept", "application/json");

            POSTOrgstructure();
            POSTEmployee();
            POSTJob();
            request.AddUrlSegment("employeeid", employeeId);

            request.AddJsonBody(new
            {
                parent = orgstructureId,
                first_name = BaseData.Employee_First_Name2,
                last_name = BaseData.Employee_Last_Name2,
                middle_name = BaseData.Employee_Middle_Name2,
                workernum = BaseData.Employee_Work_Num2,
                job = jobId
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.That(Employee.last_name, Is.EqualTo(BaseData.Employee_Last_Name2), "orgstructure name is nor correct"); //правильно ли диссериализовалось

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name2);
            Assert.AreEqual(BaseData.Employee_Full_Name2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task PATCHEmployeeId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/{employeeid}", Method.PATCH);
            request.AddHeader("Accept", "application/json");

            POSTEmployee();
            request.AddUrlSegment("employeeid", employeeId);

            request.AddJsonBody(new
            {
                first_name = BaseData.Employee_First_Name3,
                last_name = BaseData.Employee_Last_Name3,
                parent = orgstructureId,
                middle_name = BaseData.Employee_Middle_Name3,
                workernum = BaseData.Employee_Work_Num3,
                job = jobId
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.That(Employee.last_name, Is.EqualTo(BaseData.Employee_Last_Name3), "orgstructure name is nor correct"); //правильно ли диссериализовалось

            string actualtext = GetObject.GetEmployee(BaseData.Employee_Full_Name3);
            Assert.AreEqual(BaseData.Employee_Full_Name3, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task DELETEEmployeeId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("employee/{employeeid}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            POSTCleanerEmployee();
            POSTEmployeeForDelete();
            request.AddUrlSegment("employeeid", employeeDeleteid);
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.IsNull(Employee, "Employee is not null");

            string actualtext = GetObject.GetDeletedEmployee(BaseData.Employee_Full_Name4);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }
        
        public static int jobId;
        public static string jobName;

        [Test]
        public async Task POSTJob()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("job/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = BaseData.Position1,
                code = BaseData.Position1_Code,
                num = BaseData.Position1_Num
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            jobId = Job.id;
            jobName = Job.name;
            Assert.That(Job.name, Is.EqualTo(BaseData.Position1), "job name is nor correct");

            string actualtext = GetObject.GetPosition(BaseData.Position1);
            Assert.AreEqual(BaseData.Position1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int jobDeletedId;

        [Test]
        public async Task POSTJobForDelete()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("job/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = BaseData.Position2,
                code = BaseData.Position2_Code,
                num = BaseData.Position2_Num
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            jobDeletedId = Job.id;
            Assert.That(Job.name, Is.EqualTo(BaseData.Position2), "job name is nor correct");

            string actualtext = GetObject.GetPosition(BaseData.Position2);
            Assert.AreEqual(BaseData.Position2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int jobDeletedId2;

        [Test]
        public async Task POSTJobForDelete2()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("job/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                name = BaseData.Position3,
                code = BaseData.Position3_Code,
                num = BaseData.Position3_Num
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            jobDeletedId2 = Job.id;
            Assert.That(Job.name, Is.EqualTo(BaseData.Position3), "job name is nor correct");

            string actualtext = GetObject.GetPosition(BaseData.Position3);
            Assert.AreEqual(BaseData.Position3, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETJob()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTJob();
            var request = new RestRequest("job/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Job>>(response.Content);
            var name = rootObject.results[0].name;
            //Assert.That(name, Is.EqualTo(jobName), "job name is nor correct"); не сработает, т.е. в массиве много name

            string actualtext = GetObject.GetPosition(jobName);
            Assert.AreEqual(jobName, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETJobId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("job/{jobid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            POSTJob();
            request.AddUrlSegment("jobid", jobId);
            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            Assert.That(Job.name, Is.EqualTo(BaseData.Position1), "job name is nor correct");

            string actualtext = GetObject.GetPosition(BaseData.Position1);
            Assert.AreEqual(BaseData.Position1, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task DELETEJobId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("job/{jobid}", Method.DELETE);
            request.AddHeader("Accept", "application/json");

            POSTCleanerJob();
            POSTJobForDelete();
            request.AddUrlSegment("jobid", jobDeletedId);

            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            Assert.IsNull(Job, "job name is nor correct");

            string actualtext = GetObject.GetDeletedPosition(BaseData.Position2);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int userId;
        public static dynamic permissionArr;

        [Test]
        public async Task GETUser()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("users/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<User>>(response.Content);
            var id = rootObject.results[0].id;
            var login = rootObject.results[0].login;
            userId = id;
            permissionArr = rootObject.results;
            Assert.That(login, Is.EqualTo(BaseData.UserRoot), "job name is nor correct");

            string actualtext = GetObject.GetUserName(BaseData.UserRoot);
            Assert.AreEqual(BaseData.UserRoot, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETUserId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("users/{usersid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            GETUser();
            request.AddUrlSegment("usersid", userId);
            var response = await BaseMethods.GetResponse(client, request);

            var User = JsonConvert.DeserializeObject<User>(response.Content);
            Assert.That(User.login, Is.EqualTo(BaseData.UserRoot), "job name is nor correct");

            string actualtext = GetObject.GetUserName(BaseData.UserRoot);
            Assert.AreEqual(BaseData.UserRoot, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETUserIdPermissions()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            GETUser();
            
            var request = new RestRequest("users/{userid}/permissions", Method.GET);
            request.AddHeader("Accept", "application/json");

            request.AddUrlSegment("userid", userId);
            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var UserPermissions = JsonConvert.DeserializeObject<UserPermissions[]>(response.Content);
            for (int i = 0; i < UserPermissions.Length; i++)
            {
                string actualtext = GetObject.GetUserName(BaseData.UserRoot);
                Assert.AreEqual(BaseData.UserRoot, actualtext, "В БД studio название name of orgstructure имеет некорректное название");  
            } 
        }

        public static int deviceid;

        [Test]
        public async Task GETDevices()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("devices/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Devices>>(response.Content);
            var port = rootObject.results[0].port;
            deviceid = rootObject.results[0].id;
            Assert.That(port, Is.EqualTo(BaseData.Device_Port), "user name is nor correct");

            string actualtext = GetObject.GetDevice(BaseData.Device_Type);
            Assert.AreEqual(BaseData.Device_Type, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETDevicesId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("devices/{deviceid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            GETDevices();
            request.AddUrlSegment("deviceid", deviceid);
            var response = await BaseMethods.GetResponse(client, request);

            var Devices = JsonConvert.DeserializeObject<Devices>(response.Content);
            Assert.That(Devices.port, Is.EqualTo(BaseData.Device_Port), "user name is nor correct");

            string actualtext = GetObject.GetDevice(BaseData.Device_Type);
            Assert.AreEqual(BaseData.Device_Type, actualtext, "В БД studio название name of orgstructure имеет некорректное название");

        }

        public static int checkpointid;

        [Test]
        public async Task GETCheckpoint()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("checkpoint", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Checkpoint>>(response.Content);
            var checkpointName = rootObject.results[0].name;
            checkpointid = rootObject.results[0].id;
            Assert.That(checkpointName, Is.EqualTo(BaseData.Checkpoint_Name), "user name is nor correct");

            string actualtext = GetObject.GetCheckpoint(BaseData.Checkpoint_Name);
            Assert.AreEqual(BaseData.Checkpoint_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");


        }

        [Test]
        public async Task GETCheckpointId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("checkpoint/{checkpointid}", Method.GET);
            request.AddHeader("Accept", "application/json");

            GETCheckpoint();
            request.AddUrlSegment("checkpointid", checkpointid);
            var response = await BaseMethods.GetResponse(client, request);

            var checkpoint = JsonConvert.DeserializeObject<Checkpoint>(response.Content);
            Assert.That(checkpoint.name, Is.EqualTo(BaseData.Checkpoint_Name), "user name is nor correct");

            string actualtext = GetObject.GetCheckpoint(BaseData.Checkpoint_Name);
            Assert.AreEqual(BaseData.Checkpoint_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static string eventTime;

        [Test]
        public async Task POSTCheckpointIdEvent()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("test@mail.ru", "1");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("checkpoint/{checkpointid}/event", Method.POST);
            request.AddHeader("Accept", "application/json");

            GETCheckpoint();
            request.AddUrlSegment("checkpointid", checkpointid);
            request.AddJsonBody(new
            {
                direction = BaseData.Checkpoint_Direction,
                time = BaseData.Checkpoint_Time,
                photo = BaseData.Employee_Photo1
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var checkpoint = JsonConvert.DeserializeObject<Checkpoint>(response.Content);
            string actualtext = GetObject.GetCheckpoint(BaseData.Checkpoint_Name);
            Assert.AreEqual(BaseData.Checkpoint_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int reportid;
        public static dynamic reportArr;

        [Test]
        public async Task GETReport()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("report/", Method.GET);
            request.AddHeader("Accept", "application/json");

            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Report>>(response.Content);
            var name = rootObject.results[0].name;
            reportid = rootObject.results[0].id;
            reportArr = rootObject.results;
            Assert.That(name, Is.EqualTo(BaseData.Report_Name), "report name is nor correct");

            string actualtext = GetObject.GetReport(BaseData.Report_Name);
            Assert.AreEqual(BaseData.Report_Name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETReportId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            GETReport();
            foreach (dynamic report in reportArr)
            {
                var request = new RestRequest("report/{reportid}", Method.GET);
                request.AddUrlSegment("reportid", report.id);

                request.AddHeader("Accept", "application/json");
                var response = await BaseMethods.GetResponse(client, request);

                var reportresult = JsonConvert.DeserializeObject<Report>(response.Content);
                Assert.That(reportresult.name, Is.EqualTo(report.name), "report name is nor correct");

                string actualtext = GetObject.GetReport(report.name);
                Assert.AreEqual(report.name, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
            }
        }

        [Test]
        public async Task POSTCleanerJob()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("cleaner/job/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                start_id = BaseData.Position_Start_Id,
                finish_id = BaseData.Position_Finish_Id,
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Job = JsonConvert.DeserializeObject<Job>(response.Content);
            Assert.IsNull(Job, "orgstructure name is nor correct");

            string actualtext = GetObject.GetDeletedPosition(BaseData.Position1);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task POSTCleanerEmployee()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("cleaner/employee/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                start_id = BaseData.Employee_Start_Id,
                finish_id = BaseData.Employee_Finish_Id,
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Employee = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.IsNull(Employee, "orgstructure name is nor correct");

            string actualtext = GetObject.GetDeletedEmployee(BaseData.Employee_Full_Name1);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task POSTCleanerOrgstructure()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("cleaner/orgstructure/", Method.POST);
            request.AddHeader("Accept", "application/json");

            request.AddJsonBody(new
            {
                start_id = BaseData.Company_Start_Id,
                finish_id = BaseData.Company_Finish_Id,
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Orgstructure = JsonConvert.DeserializeObject<Orgstructure>(response.Content);
            Assert.IsNull(Orgstructure, "orgstructure name is nor correct");

            string actualtext = GetObject.GetDeletedCompany(BaseData.Company_Name);
            Assert.IsEmpty(actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static string token;

        [Test]
        public async Task POSTAuthLogin()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            GETUser();
            var request = new RestRequest("auth/login", Method.POST);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var Login = JsonConvert.DeserializeObject<Login>(response.Content);
            token = Login.token;
            Assert.That(Login.user_id, Is.EqualTo(userId), "report name is nor correct");

            string actualtext = GetObject.GetUserId(BaseData.UserRootId);
            Assert.AreEqual(BaseData.UserRootId, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task POSTAuthLogout()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTAuthLogin();
            var request = new RestRequest("auth/logout", Method.POST);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);
        }

        public static int eventId;

        [Test]
        public async Task GETLogs()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTCheckpointIdEvent();
            var request = new RestRequest("logs/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Logs>>(response.Content);
            var name = rootObject.results[0].time;
            eventId = rootObject.results[0].id;

            string actualtext = GetObject.GetLog(BaseData.Checkpoint_Time);
            Assert.AreEqual(BaseData.Checkpoint_Time2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETLogsId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            GETLogs();
            var request = new RestRequest("logs/{logsid}/", Method.GET);
            request.AddUrlSegment("logsid", eventId);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var Logs = JsonConvert.DeserializeObject<Logs>(response.Content);

            string actualtext = GetObject.GetLog(BaseData.Checkpoint_Time);
            Assert.AreEqual(BaseData.Checkpoint_Time2, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        public static int templId;
        /* Нужны шаблоны в программе для выполнения метода
        [Test]
        public async Task GETTempl()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTEmployee();
            var request = new RestRequest("templ/", Method.GET);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var rootObject = JsonConvert.DeserializeObject<RootObject<Templ>>(response.Content);
            var employeeName = rootObject.results[0].employee.ToString();
            templId = rootObject.results[0].id;

            string actualtext = GetObject.GetEmployeeId(employeeName);
            Assert.AreEqual(employeeName, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }

        [Test]
        public async Task GETTemplId()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            POSTEmployee();
            GETTempl();
            var request = new RestRequest("templ/{templid}/", Method.GET);
            request.AddUrlSegment("templid", templId);
            request.AddHeader("Accept", "application/json");
            var response = await BaseMethods.GetResponse(client, request);

            var Templ = JsonConvert.DeserializeObject<Templ>(response.Content);
            var employeeName = Templ.employee.ToString();
            var templnewId = Templ.id;

            string actualtext = GetObject.GetEmployeeId(employeeName);
            Assert.AreEqual(employeeName, actualtext, "В БД studio название name of orgstructure имеет некорректное название");
        }
        */
        public static string uuidId;

        [Test]
        public async Task POSTWorktimePresence()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("worktime/presence/", Method.POST);
            request.AddHeader("Accept", "application/json");

            POSTEmployee();

            request.AddJsonBody(new
            {
                time = BaseData.Worktime
            });

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Worktime = JsonConvert.DeserializeObject<Worktime>(response.Content);
            uuidId = Worktime.uuid;
        }

        [Test]
        public async Task GETWorktimePresenceResult()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("worktime/presence/result", Method.GET);
            request.AddHeader("Accept", "application/json");

            POSTWorktimePresence();
            request.AddParameter("uuid", uuidId);

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Summary = JsonConvert.DeserializeObject<Summary>(response.Content);
            var totalCount = Summary.total_count.ToString();

            var actualtext = GetObject.GetEmployeeSum();
            //Assert.AreEqual(totalCount, actualtext);
        }

        [Test]
        public async Task GETWorktimeStatus()
        {
            var client = new RestClient("https://localhost:8088/api/v1/");
            client.Authenticator = new HttpBasicAuthenticator("root", "0");
            BaseMethods.DisableCheckCertificate();

            var request = new RestRequest("worktime/status/", Method.GET);
            request.AddHeader("Accept", "application/json");

            POSTWorktimePresence();
            request.AddParameter("uuid", uuidId);

            request.RequestFormat = DataFormat.Json;
            var response = await BaseMethods.GetResponse(client, request);

            var Status = JsonConvert.DeserializeObject<Status>(response.Content);
            var status = Status.status;
            var detail = Status.detail;
            Assert.AreEqual(status, 2);
            Assert.AreEqual(detail, "");
        }
    }
}
