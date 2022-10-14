using System.Web.Http.Results;
using PatientDetails.Controllers;
using PatientDetails.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PatientDetails.Services;
using Moq;
using NUnit.Framework.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using Microsoft.CodeAnalysis.Differencing;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;
using System.Net;
using MediatR;
using PatientDetails.Queries;
using PatientDetails.Commands;


namespace PatientInfoTest
{

    [TestFixture]
    public class Tests
    {
        private Mock<IMediator> mockMediatr;

        [Test]
        public void GetPatient()
        {
            mockMediatr = new Mock<IMediator>();
            mockMediatr.Setup(x => x.Send(new GetPatientInfoQueriesByID(42),
    It.IsAny<CancellationToken>())).Returns(Task.FromResult(new PatientInfo { Id = 42, PatientName = "Demo Name", Phone = "8787878787", Address = "demo address", Dob = Convert.ToDateTime("09/09/1990"), EmailId = "demo@gmail.com" }));

            var controller = new PatientinfoController(mockMediatr.Object);
            ActionResult<PatientInfo> result = controller.GetPatientInfo(42).Result;
            PatientInfo patientinfo = result.Value;

            Assert.IsNotNull(patientinfo);
            Assert.AreEqual(42, patientinfo.Id);
        }
        [Test]
        public void GetReturnsNotFound()
        {
            var mockRepository = new Mock<IMediator>();
            var controller = new PatientinfoController(mockRepository.Object);

            // Act
            ActionResult<PatientInfo> actionResult = controller.GetPatientInfo(10).Result;

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
        }
        [Test]
        public void DeleteReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IMediator>();
            var controller = new PatientinfoController(mockRepository.Object);

            // Act
            IActionResult actionResult = controller.DeletePatientInfo(10).Result;
            var notFoundResult = (Microsoft.AspNetCore.Mvc.NotFoundResult)actionResult;

            notFoundResult.StatusCode.Equals(404);

            Assert.IsInstanceOfType(actionResult, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
        }
        [Test]
        public void DeleteReturnsOk()
        {
            mockMediatr = new Mock<IMediator>();
            mockMediatr.Setup(x => x.Send(new GetPatientInfoQueriesByID(42),
     It.IsAny<CancellationToken>())).ReturnsAsync(new PatientInfo { Id = 42, PatientName = "Demo Name", Phone = "8787878787", Address = "demo address", Dob = Convert.ToDateTime("09/09/1990"), EmailId = "demo@gmail.com" });

            var controller = new PatientinfoController(mockMediatr.Object);
            IActionResult actionResult = controller.DeletePatientInfo(42).Result;
            Assert.IsInstanceOfType(actionResult, typeof(Microsoft.AspNetCore.Mvc.OkResult));
        }
        [Test]
        public void PostMethod()
        {
            var mockRepository = new Mock<IMediator>();
            var controller = new PatientinfoController(mockRepository.Object);

            ActionResult<PatientInfo> actionResult = controller.PostPatientInfo(new PatientInfo { Id = 50, PatientName = "Demo Name", Phone = "8787878787", Address = "demo address", Dob = Convert.ToDateTime("09/09/1990"), EmailId = "demo@gmail.com" }).Result;

            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Result);
            Assert.IsInstanceOfType(actionResult.Result, typeof(Microsoft.AspNetCore.Mvc.CreatedAtActionResult));
        }
        [Test]
        public void PutPatient()
        {
            var mockRepository = new Mock<IMediator>();
            var controller = new PatientinfoController(mockRepository.Object);

            IActionResult actionResult = controller.PutPatientInfo(55,new PatientInfo { Id = 55, PatientName = "Demo Name", Phone = "8787878787", Address = "demo address", Dob = Convert.ToDateTime("09/09/1990"), EmailId = "demo@gmail.com" }).Result;
            var contentResult = actionResult as NegotiatedContentResult<PatientInfo>;

            var nocontentResule = (NoContentResult)actionResult;
            nocontentResule.StatusCode.Equals(204);

            Assert.IsNotNull(actionResult);
        }

    }
}