using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using ThirteenDaysAWeek.iFlyShop.Api.Controllers;
using ThirteenDaysAWeek.iFlyShop.Api.Data.Repositories;
using ThirteenDaysAWeek.iFlyShop.Api.Models;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);
        private readonly Mock<IRepository<Product>> _mockProductRepository;
        private readonly Fixture _fixture = new Fixture();

        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductRepository = _mockRepository.Create<IRepository<Product>>();
            _controller = new ProductController(_mockProductRepository.Object);
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_Repository_Is_Null()
        {
            // Arrange
            IRepository<Product> repository = null;
            Action ctor = () => new ProductController(repository);

            // Act + Assert
            ctor.Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_Should_Not_Throw_ArgumentNullException_When_Repository_Is_Not_Null()
        {
            // Arrange
            Action ctor = () => new ProductController(_mockProductRepository.Object);

            // Act + Assert
            ctor.Should()
                .NotThrow<ArgumentNullException>();
        }

        [Fact]
        public async  Task GetProducts_Should_Return_List_Of_Products()
        {
            // Arrange
            var products = _fixture.Create<IEnumerable<Product>>();

            _mockProductRepository.Setup(_ => _.GetAll())
                .ReturnsAsync(products);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            _mockRepository.VerifyAll();
            result.Should()
                .NotBeNullOrEmpty();

            result.Should()
                .BeEquivalentTo(products);
        }

        [Fact]
        public async Task GetProductById_Should_Return_Single_Product()
        {
            // Arrange
            var product = _fixture.Create<Product>();

            _mockProductRepository.Setup(_ => _.GetById(It.Is<int>(x => x == product.ProductId)))
                .ReturnsAsync(product);

            // Act
            var result = await _controller.GetProductById(product.ProductId);

            // Assert
            _mockRepository.VerifyAll();
            result.Should()
                .NotBeNull();
            result.Should()
                .Be(product);
        }
    }
}
