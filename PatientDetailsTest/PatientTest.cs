using NUnit.Framework;
using System.Web;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
//using System.Web.Http;
using PatientDetails.Controllers;
using PatientDetails.Models;
using Newtonsoft.Json;

namespace PatientDetailsTest
{
        [TestFixture]
    public class PatientTest   
    {
        private readonly PatientDetailsContext _context;

        public void PatientDetailsGetById()
        {
            // Set up Prerequisites   
            var controller = new patientinfoController(_context);
            // Act on Test  
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            var response = controller.GetPatientInfo(1);
            // Assert the result  
            PatientInfo patients;
            Assert.IsTrue(response.TryGetContentValue<PatientInfo>(out patients));
            Assert.AreEqual("Jignesh", patients.PatientName);
        }
        public void DepartmentGetByIdSuccess()
        {
            // Set up Prerequisites   
            var controller = new patientinfoController(_context);
            // Act on Test  
            var response = controller.GetPatientInfo(1);
            var contentResult = response as OkNegotiatedContentResult<patientinfo>();

    var responseResult = JsonConvert.DeserializeObject<List<PatientInfo>>(response.Content.ReadAsStringAsync().Result);
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);

            controller = new CheckServiceApiController { Request = new HttpRequestMessage() };
            controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            HealthCheckRunner.ServiceNames = new List<string>();
            HttpResponseMessage response = controller.GetState();
            dynamic status;
            response.TryGetContentValue<dynamic>(out status);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.AreEqual(1, status.code);
        }
    } 
}