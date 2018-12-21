using System;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit.Tests.Generic;
using _1_DomainModels;
using _1_Entity.Model;
using _3_Cqrs.Service.Command;
using _3_Cqrs.Service.CommandHandlers;
using _5_Repositories.Contracts;

namespace Unit.Tests.Specific.CommandTest.StudentCommandTest
{
    [TestClass]
    public class AddStudentUnitTest : BaseTest<AddStudentCommandHandler>
    {
        private Mock<IBaseRepository<Student>> _mockRepository;
        private Mock<IMapper> _mockMapper;


        [TestMethod]
        public void AddStudent_ThrowsException_WhenParameterIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddStudent_ShouldAddStudent()
        {
            CreateItemToTest().Execute(new AddStudentCommand(new StudentDto()));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<StudentDto>(), It.IsAny<Student>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Add(It.IsAny<Student>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }


        protected override AddStudentCommandHandler CreateItemToTest()
        {
            return new AddStudentCommandHandler(_mockMapper.Object, _mockRepository.Object);
        }

        protected override void SetupMockingForTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IBaseRepository<Student>>();
        }
    }
}
