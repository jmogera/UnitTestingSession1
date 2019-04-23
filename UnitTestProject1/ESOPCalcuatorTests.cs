using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Calculator;
using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Exceptions;

namespace UnitTestProject1
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ESOPCalcuatorTests
    {
        [TestMethod]
        public void ESOPCalculator_Initialize_ShouldCreateObject()
        {
            //Arrange
            ESOPCalculator calculator = null;
            var company = new Company();
            company.Id = 1;
            company.Employees.Add(new Employee() { });
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ESOPCalculator_PassNullCompany_ShouldThrowAnException()
        {
            //Arrange
            Company company = null;
            ESOPCalculator calculator = null;
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCompanyIdException))]
        public void ESOPCalculator_ValidCompany_WithInvalidId_ShouldThrowException()
        {
            //Arrange
            Company company = new Company();
            company.Id = 0;
            ESOPCalculator calculator = null;
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCompanyIdException))]
        public void ESOPCalculator_ValidCompany_WithInvalidNegativeId_ShouldThrowException()
        {
            //Arrange
            Company company = new Company();
            company.Id = -10;
            ESOPCalculator calculator = null;
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        public void ESOPCalculator_ValidCompany_WithValidId_ShouldIntializeClass()
        {
            //Arrange
            Company company = new Company();
            company.Id = 10;
            company.Employees.Add(new Employee());
            ESOPCalculator calculator = null;
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        [ExpectedException(typeof(NoEmployeesException))]
        public void ESOPCalculator_ValidCompany_WithNoEmployees_ShouldThrowException()
        {
            //Arrange
            Company company = new Company();
            company.Id = 10;
            ESOPCalculator calculator = null;
            //Act
            calculator = new ESOPCalculator(company);
            //Asserts
            Assert.IsNotNull(calculator);
        }

        [TestMethod]
        public void ESOPCalculator_CalculateStatement_ValidEmployee_WithEndDate_ShouldNotGetStatement()
        {
            //Arrange
            int expected = 0;

            Company company = new Company();
            company.Id = 10;
            company.ESOPStartDate = DateTime.Today.AddDays(-367);
            
            Employee employee = new Employee();
            employee.Id = 1;
            employee.Name = "Jason";
            employee.StartDate = DateTime.Today.AddDays(-366);
            employee.EndDate = DateTime.Today;
            company.Employees.Add(employee);

            ESOPCalculator calculator = new ESOPCalculator(company);

            //Act
            List<ESOPStatement> actual = calculator.CalculateStatement();

            //Asserts
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Count);
        }
    }
}
