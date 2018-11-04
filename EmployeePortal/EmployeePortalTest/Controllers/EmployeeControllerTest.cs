using EmployeePortal.Controllers;
using EmployeePortal.Interfaces;
using EmployeePortal.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EmployeePortalTest.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        List<EmployeeViewModel> employees = new List<EmployeeViewModel>() { new EmployeeViewModel { FirstName = "TestFName", LastName = "LastName", EmployeeID = 1000, Salary = 90000 } };
        static Mock<IRepository<EmployeeViewModel>> MockRepository = new Mock<IRepository<EmployeeViewModel>>();
        EmployeeController Target = new EmployeeController(MockRepository.Object);

        [TestMethod]
        public void GetAllEmployeeTest()
        {
            //Do Setup
            MockRepository.Setup(repo => repo.GetAll()).Returns(employees);

            //Call Target
            IEnumerable<EmployeeViewModel> result = Target.GetAllEmployee();

            //Test Outcome
            Assert.AreEqual(employees, result);
            MockRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            //Do Setup
            var id = 1000;
            MockRepository.Setup(repo => repo.Delete(id)).Returns(true);

            //Call Target
            Target.Request = new HttpRequestMessage();
            Target.Request.SetConfiguration(new HttpConfiguration());
            var result = Target.DeleteEmployee(id);

            //Test Outcome
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
            MockRepository.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
            MockRepository.VerifyAll();
            MockRepository.VerifyNoOtherCalls();
        }


        [TestMethod]
        public void GetEmployeeTest()
        {
            //Do Setup
            var id = 1000;
            MockRepository.Setup(repo => repo.Get(id)).Returns(employees[0]);

            //Call Target
            Target.Request = new HttpRequestMessage();
            Target.Request.SetConfiguration(new HttpConfiguration());
            EmployeeViewModel result = Target.GetEmployee(id);

            //Test Outcome
            Assert.AreEqual(employees[0], result);
            Assert.AreSame(result.FirstName, employees[0].FirstName);
            MockRepository.Verify(repo => repo.Get(It.IsAny<int>()), Times.Once);
            MockRepository.VerifyAll();
            MockRepository.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void AddEmployeeTest()
        {
            //Do Setup
            MockRepository.Setup(repo => repo.Add(employees[0])).Returns(true);

            //Call Target
            Target.Request = new HttpRequestMessage();
            Target.Request.SetConfiguration(new HttpConfiguration());
            var result = Target.AddEmployee(employees[0]);

            //Test Outcome
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.Created);
            MockRepository.Verify(repo => repo.Add(It.IsAny<EmployeeViewModel>()), Times.Once);
            MockRepository.VerifyAll();
            MockRepository.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            //Do Setup
            MockRepository.Setup(repo => repo.Update(employees[0])).Returns(true);

            //Call Target
            Target.Request = new HttpRequestMessage();
            Target.Request.SetConfiguration(new HttpConfiguration());
            var result = Target.UpdateEmployee(employees[0]);

            //Test Outcome
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
            MockRepository.Verify(repo => repo.Update(It.IsAny<EmployeeViewModel>()), Times.Once);
            MockRepository.VerifyAll();
            MockRepository.VerifyNoOtherCalls();
        }
    }
}
