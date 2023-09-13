using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using Restaurant.Domain.Extensions;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Services;

namespace Restauraunt.Tests
{
    public class DishServiceTest
    {
        private readonly Fixture _fixture;
        private readonly DishService _dishService;

        private readonly IDishRepository _dishRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public DishServiceTest()
        {
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _unitOfWork = Substitute.For<IUnitOfWork>();            
            _dishRepository = Substitute.For<IDishRepository>();
            _commentRepository = Substitute.For<ICommentRepository>();
            _dishService = new DishService(_dishRepository, _commentRepository, _unitOfWork);
        }

        [Fact]
        public void GetTypesTests()
        {
            // Arrange
            var types = ((Category[])Enum.GetValues(typeof(Category)))
                .ToDictionary(k => (int)k, t => t.GetDisplayName());

            // Act
            var result = _dishService.GetTypes();

            // Assert
            result.Data.Should().BeEquivalentTo(types);
        }

        [Theory]
        [AutoData]
        public async Task FindDishById(long id)
        {
            // Arrange
            var cts = new CancellationToken();
            _dishRepository.Find(id, cts).Returns(new Dish()
            {
                Id = id,
                DishPhotos = new List<DishPhoto>() { new() }
            });

            // Act
            var result = await _dishService.GetOneDishAsync(id, cts);

            // Assert
            result.Id.Should().Be(id);
        }

        [Theory]
        [AutoData]
        public async Task GetDishAsync_WithValidId_ReturnsDishViewModel(
            long id, CancellationToken cancellationToken)
        {
            // Arrange
            var product = _fixture.Build<Dish>()
                .With(p => p.Id, id)
                .With(p => p.DishPhotos, new[] { _fixture.Create<DishPhoto>() })
                .Create();
            _dishRepository.Find(id, cancellationToken).Returns(product);

            // Act
            var result = await _dishService.GetOneDishAsync(id, cancellationToken);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.Photos.Should().NotBeNull();
            result.Photos.Should().HaveCount(1);
        }


        [Theory]
        [AutoData]
        public async Task GetDishAsync_WithInvalidId_ReturnsNull(
            long id, CancellationToken cancellationToken)
        {
            // Arrange
            _dishRepository.Find(id, cancellationToken).Returns((Dish)null);

            // Act
            var result = await _dishService.GetOneDishAsync(id, cancellationToken);

            // Assert
            result.Should().BeNull();
        }


        [Theory]
        [AutoData]
        public async Task GetDishAsync_WithException_ReturnsBaseResponseWithInternalServerError(
            string searchTerm, Exception exception)
        {
            // Arrange
            _dishRepository.GetAll().Throws(exception);

            // Act
            var result = await _dishService.GetOneDishAsync(searchTerm);

            // Assert
            result.StatusCode.Should().Be(StatusCode.InternalServerError);
            result.Description.Should().Contain(exception.Message);
        }

        [Theory]
        [AutoData]
        public async Task Create_ValidDish_ReturnsBaseResponseWithCreatedDish( List<byte[]> imageDataList, Category category)
        {
            // Arrange
            var model = new DishViewModel();
            model.Category = category.ToString();

            // Act
            var result = await _dishService.Create(model, imageDataList);

            // Assert
            result.StatusCode.Should().Be(StatusCode.OK);
            result.Data.Should().NotBeNull();
        }


        [Theory]
        [AutoData]
        public async Task Create_WithException_ReturnsBaseResponseWithInternalServerError(
            List<byte[]> imageDataList,
            Exception exception,
            Category category)
        {
            // Arrange
            var model = new DishViewModel();
            model.Category = category.ToString();
            _dishRepository.Create(Arg.Any<Dish>()).ThrowsAsync(exception);

            // Act
            var result = await _dishService.Create(model, imageDataList);

            // Assert
            result.StatusCode.Should().Be(StatusCode.InternalServerError);
            result.Description.Should().Contain(exception.Message);
        }

        [Theory]
        [AutoData]
        public void GetDishes_WithExistingProducts_ReturnsBaseResponseWithDishesList()
        {
            // Arrange
            var dishes = new List<Dish> { new() };

            _dishRepository.GetAll().Include(p => p.DishPhotos)
                .Returns(dishes.AsQueryable());

            // Act
            var result = _dishService.GetDishes(1, 10);

            // Assert
            result.StatusCode.Should().Be(StatusCode.OK);
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public void GetDishes_WithNoDishes_ReturnsBaseResponseWithZeroElements()
        {
            // Arrange
            var dishes = new List<Dish>();

            _dishRepository.GetAll().Include(p => p.DishPhotos).Returns(dishes.AsQueryable());

            // Act
            var result = _dishService.GetDishes();

            // Assert
            result.StatusCode.Should().Be(StatusCode.OK);
            result.Description.Should().Contain("0 elements");
        }

        [Theory]
        [AutoData]
        public void GetProducts_WithException_ReturnsBaseResponseWithInternalServerError(
            Exception exception)
        {
            // Arrange
            _dishRepository.GetAll().Include(p => p.DishPhotos).Throws(exception);

            // Act
            var result = _dishService.GetDishes();

            // Assert
            result.StatusCode.Should().Be(StatusCode.InternalServerError);
            result.Description.Should().Contain(exception.Message);
        }
    }
}