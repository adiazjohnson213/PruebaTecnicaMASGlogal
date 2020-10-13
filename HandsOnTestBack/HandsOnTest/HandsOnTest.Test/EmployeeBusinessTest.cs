using HandsOnTest.Business.DTO;
using HandsOnTest.Business.Exeption;
using HandsOnTest.Business.Factories;
using HandsOnTest.Business.Services;
using HandsOnTest.Repository.Entities;
using HandsOnTest.Repository.Reposotories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Test
{
    [TestClass]
    public class EmployeeBusinessTest
    {
        IMasGlobalEmployeeTestRepository masGlobalEmployeeTestRepository;
        IEmployeeFactory employeeFactory;
        EmployeeBusiness employeeBusiness;
        IEnumerable<Employee> employeeList;

        [TestInitialize]
        public void Inicializar()
        {
            masGlobalEmployeeTestRepository = Substitute.For<IMasGlobalEmployeeTestRepository>();
            employeeFactory = Substitute.For<IEmployeeFactory>();
            employeeBusiness = new EmployeeBusiness(masGlobalEmployeeTestRepository, employeeFactory);
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
        public async Task GetEmployeeById()
        {
            //Arrage
            masGlobalEmployeeTestRepository.GetEmployeesAsync().Returns(employeeList);
            employeeFactory.CreateEmployee(Arg.Any<Employee>()).Returns(new HourlyEmployee(employeeList.FirstOrDefault()));

            //Act
            var resultado = await employeeBusiness.GetEmployee(1);

            //Assert
            Assert.AreEqual(72000000, resultado.AnnualSalary);
        }

        [TestMethod]
        [ExpectedException(typeof(HandsOnTestException))]
        public async Task GetEmployeeWithError()
        {
            //Act
            await employeeBusiness.GetEmployee(4);
        }

        [TestMethod]
        [ExpectedException(typeof(HandsOnTestException))]
        public async Task GetEmployeeByIdWithError()
        {
            //Arrage
            masGlobalEmployeeTestRepository.GetEmployeesAsync().Returns(employeeList);

            //Act
            await employeeBusiness.GetEmployee(3);
        }
    }
}
