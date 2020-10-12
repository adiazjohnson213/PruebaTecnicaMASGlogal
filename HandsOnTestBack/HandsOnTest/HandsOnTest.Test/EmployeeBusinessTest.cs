using HandsOnTest.Business.Exeption;
using HandsOnTest.Business.Services;
using HandsOnTest.Repository.Entities;
using HandsOnTest.Repository.Reposotories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnTest.Test
{
    [TestClass]
    public class EmployeeBusinessTest
    {
        IMasGlobalEmployeeTestRepository masGlobalEmployeeTestRepository;
        EmployeeBusiness employeeBusiness;
        IEnumerable<Employee> employeeList;

        [TestInitialize]
        public void Inicializar()
        {
            masGlobalEmployeeTestRepository = Substitute.For<IMasGlobalEmployeeTestRepository>();
            employeeBusiness = new EmployeeBusiness(masGlobalEmployeeTestRepository);
            employeeList = new List<Employee> {
                    new Employee {
                        Id= 1,
                        Name= "Arthur",
                        ContractTypeName= "HourlySalaryEmployee",
                        RoleId= 1,
                        RoleName= "Developer",
                        RoleDescription= null,
                        HourlySalary= 50000,
                        MonthlySalary= 6000000
                    },
                    new Employee {
                        Id= 2,
                        Name= "Fancisco",
                        ContractTypeName= "MonthlySalaryEmployee",
                        RoleId= 1,
                        RoleName= "Arquitect",
                        RoleDescription= null,
                        HourlySalary= 50000,
                        MonthlySalary= 9000000
                    },
                    new Employee {
                        Id= 2,
                        Name= "Juan",
                        ContractTypeName= "HourlySalaryEmployee",
                        RoleId= 1,
                        RoleName= "Designer",
                        RoleDescription= null,
                        HourlySalary= 25000,
                        MonthlySalary= 3000000
                    }
                };
        }

        [TestMethod]
        public void GetEmployee()
        {
            //Arrage
            masGlobalEmployeeTestRepository.GetEmployeesAsync().Returns(employeeList);

            //Act
            var resultado = employeeBusiness.GetEmployee();

            //Assert
            Assert.AreEqual(3, resultado.ToList().Count());
        }

        [TestMethod]
        public void GetEmployeeById()
        {
            //Arrage
            masGlobalEmployeeTestRepository.GetEmployeesAsync().Returns(employeeList);

            //Act
            var resultado = employeeBusiness.GetEmployee(1);

            //Assert
            Assert.AreEqual(72000000, resultado.AnnualSalary);
        }

        [TestMethod]
        [ExpectedException(typeof(HandsOnTestException))]
        public void GetEmployeeWithError()
        {
            //Act
            employeeBusiness.GetEmployee(4);
        }

        [TestMethod]
        [ExpectedException(typeof(HandsOnTestException))]
        public void GetEmployeeByIdWithError()
        {
            //Arrage
            masGlobalEmployeeTestRepository.GetEmployeesAsync().Returns(employeeList);

            //Act
            employeeBusiness.GetEmployee(3);
        }
    }
}
