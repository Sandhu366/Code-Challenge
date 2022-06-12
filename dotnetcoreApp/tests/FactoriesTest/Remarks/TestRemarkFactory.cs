using ApplicationShared.Remarks.Commands;
using AutoMapper;
using Domain;
using Factories.Remarks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FactoriesTest.Remarks
{
    [TestClass]
    public class TestRemarkFactory
    {
        private Mock<IMapper> _mockMapper;

        private RemarkFactory _sut;

        [TestInitialize]
        public void Init()
        {
            _mockMapper = new Mock<IMapper>();

            _sut = new RemarkFactory(_mockMapper.Object);
        }

        [TestMethod]
        public void UpdateRemark_ShouldThrowNullReferenceException_WhenEditRemarkCommandIsNull()
        {
            // Arrange
            Remark remark = new();
            EditRemarkCommand command = null;

            // Act
            // Assert
            NullReferenceException result = Assert.ThrowsException<NullReferenceException>(() => _sut.UpdateRemark(remark, command));

            Assert.AreEqual($"{nameof(EditRemarkCommand)} is null", result.Message);
        }

        [TestMethod]
        public void UpdateRemark_ShouldUpdateRemarkWithProperties_WhenEditRemarkCommandIsNotNull()
        {
            // Arrange
            int id = 123;
            string body = "I am making a remark";
            Remark remark = new();
            EditRemarkCommand command = new(id, body);

            // Act
            Remark result = _sut.UpdateRemark(remark, command);

            // Assert
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(body, result.Body);
        }
    }
}
