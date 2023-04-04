using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Application.AppData.Contexts.Categories.Services;
using Board.Contracts.Category;
using Moq;
using Xunit;

namespace Board.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task Category_GetById_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            CancellationToken token = new CancellationToken(false);

            Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();

            CategoryInfoDto expected = new CategoryInfoDto
            {
                Id = id,
                Name = "test name",
                CreatedAt = DateTime.Now,
                IsActive = true,
                ParentId = id
            };

            categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

            CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await service.GetByIdAsync(id, token);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(expected.Name, result.Name);
            Assert.Equal(expected.CreatedAt, result.CreatedAt);
            Assert.Equal(expected.IsActive, result.IsActive);
            Assert.Equal(expected.ParentId, result.ParentId);

            categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }
    }
}