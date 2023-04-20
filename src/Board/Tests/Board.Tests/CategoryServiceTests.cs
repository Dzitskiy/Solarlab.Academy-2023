using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Application.AppData.Contexts.Categories.Services;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Board.Tests
{
    public class CategoryServiceTests : IClassFixture<CategoryListFixture>
    {
        public CategoryServiceTests(ITestOutputHelper output, CategoryListFixture fixture)
        {
            _output = output;
            _fixture = fixture;

            _output.WriteLine($"Test {nameof(CategoryServiceTests)} created");
        }

        private readonly ITestOutputHelper _output;
        private readonly CategoryListFixture _fixture;

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task Category_GetById_Success1(int index)
        {
            // Arrange
            Guid id = CategoryListFixture.Ids[index];

            CancellationToken token = new CancellationToken(false);

            Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();

            var expected = _fixture.List.First(x => x.Id == id);

            categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

            CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

            // Act
            var result = await service.GetByIdAsync(id, token);

            // Assert
            result.ShouldNotBe(null);

            id.ShouldBe(result.Id);
            expected.Name.ShouldBe(result.Name);
            expected.CreatedAt.ShouldBe(result.CreatedAt);
            expected.IsActive.ShouldBe(result.IsActive);
            expected.ParentId.ShouldBe(result.ParentId);

            categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }

        public static IEnumerable<object[]> GetByIdSuccessParams =>
            new List<object[]>
            {
                new object[] { 0, DateTime.Now },
                new object[] { 1, DateTime.Now }
            };

        [Theory]
        [MemberData(nameof(GetByIdSuccessParams))]
        public async Task Category_GetById_Success2(int index, DateTime dt)
        {
            _output.WriteLine($"Index: {index}, Time: {dt.Ticks}");

            // Arrange
            Guid id = CategoryListFixture.Ids[index];

            CancellationToken token = new CancellationToken(false);

            Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            
            var expected = _fixture.List.First(x => x.Id == id);

            categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

            CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

            // Act
            var result = await service.GetByIdAsync(id, token);

            // Assert
            result.ShouldNotBe(null);

            id.ShouldBe(result.Id);
            expected.Name.ShouldBe(result.Name);
            expected.CreatedAt.ShouldBe(result.CreatedAt);
            expected.IsActive.ShouldBe(result.IsActive);
            expected.ParentId.ShouldBe(result.ParentId);
            
            categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }

        [Theory]
        [ClassData(typeof(CategoryIdTestData))]
        public async Task Category_GetById_Success3(Guid id)
        {
            _output.WriteLine($"Id: {id}");

            // Arrange

            CancellationToken token = new CancellationToken(false);

            Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();

            var expected = _fixture.List.First(x => x.Id == id);

            categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => expected);

            CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

            // Act
            var result = await service.GetByIdAsync(id, token);

            // Assert
            result.ShouldNotBe(null);

            id.ShouldBe(result.Id);
            expected.Name.ShouldBe(result.Name);
            expected.CreatedAt.ShouldBe(result.CreatedAt);
            expected.IsActive.ShouldBe(result.IsActive);
            expected.ParentId.ShouldBe(result.ParentId);

            categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }

        [Fact]
        public async Task Category_GetById_Fail()
        {
            // Arrange
            var id = Guid.NewGuid();
            _output.WriteLine($"Id: {id}");

            CancellationToken token = new CancellationToken(false);

            Mock<ICategoryRepository> categoryRepositoryMock = new Mock<ICategoryRepository>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();

            categoryRepositoryMock.Setup(x => x.GetByIdAsync(id, token)).ReturnsAsync(() => null);

            CategoryService service = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object, null, null);

            // Act
            var result = await service.GetByIdAsync(id, token);

            // Assert
            result.ShouldBe(null);
            categoryRepositoryMock.Verify(x => x.GetByIdAsync(id, token), Times.Once);
        }
    }
}