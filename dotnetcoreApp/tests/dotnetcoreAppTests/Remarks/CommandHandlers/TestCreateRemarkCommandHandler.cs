using Application.Remarks.CommandHandlers;
using ApplicationShared.Remarks.Commands;
using Common.Errors;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence;
using Persistence.Repositories;
using Persistence.UnitOfWork;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationTests.Remarks.CommandHandlers
{
    [TestClass]
    public class TestCreateRemarkCommandHandler
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IPersistenceUnitOfWork> _mockPersistenceUnitOfWork;

        private CreateRemarkCommandHandler _sut;

        [TestInitialize]
        public void Init()
        {
            Mock<IRepository<Remark>> mockRepository = new Mock<IRepository<Remark>>();
            mockRepository
                .Setup(x => x.Add(It.IsAny<Remark>()))
                .Returns(new Remark());

            _mockPersistenceUnitOfWork = new Mock<IPersistenceUnitOfWork>();
            _mockPersistenceUnitOfWork
                .Setup(x => x.SaveChangesAsync());

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork
                .Setup(x => x.GetGenericRepository<Remark>())
                .Returns(mockRepository.Object);

            _sut = new CreateRemarkCommandHandler(_mockPersistenceUnitOfWork.Object, _mockUnitOfWork.Object);
        }

        [TestMethod]
        public async Task Handle_Should_ThrowsRemarkNotSavedException_When_CreateRemarkCommandIsNull()
        {
            // Arrange
            CreateRemarkCommand command = null;

            // Act
            // Assert
            RemarkNotSavedException actualException =
                await Assert.ThrowsExceptionAsync<RemarkNotSavedException>(async () => await _sut.Handle(command, CancellationToken.None));

            Assert.AreEqual($"{nameof(CreateRemarkCommand)} is null.", actualException.Message);
            _mockPersistenceUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [TestMethod]
        public async Task Handle_Should_CallSaveChangesAsyncOnce_When_CreateRemarkCommandIsNotNull()
        {
            // Arrange
            CreateRemarkCommand command = new ("Test CreateActivity Title", 123);

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            _mockPersistenceUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}