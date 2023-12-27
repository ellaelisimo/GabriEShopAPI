using AutoFixture;
using FluentAssertions;
using GabriEShopAPI.DTOs;
using GabriEShopAPI.Entities;
using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Services;
using Moq;

namespace ItemTestProject.ItemServiceTests
{
    public class ItemServiceTests
    {
        private readonly ItemService _itemService;

        private readonly Mock<IItemRepository> _itemRepositoryMock;

        private readonly Fixture _fixture;

        public ItemServiceTests()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemRepositoryMock.Object);//moq keliauja cia - object
            _fixture = new Fixture();
        }

        [Fact]
        public void Get_ReturnsListOfITems()
        {
            //Arrange
            _itemRepositoryMock.Setup(m => m.GetItems()).Returns(new List<Item> { new Item { id = 2 } });

            //Act
            var result = _itemService.GetItems();

            //Assert
            result[0].id.Should().Be(2);
            //as tikrinu lista, jo pirmas elementas turi turet id = 2 
        }

        [Fact]
        public async Task Get_GivenValidId_ReturnsItemWithId()
        {
            //Arrange
            int id = 1;
            var expectedItem = new Item { id = id };
            _itemRepositoryMock.Setup(m => m.GetItemById(id)).ReturnsAsync(expectedItem);

            //Act
            var result = await _itemService.GetItemById(id);

            //Assert
            _itemRepositoryMock.Verify(m => m.GetItemById(id), Times.Once());

            result.id.Should().Be(id);
        }

        [Fact]
        public async Task Add_WhenItemDoesNotExists_ReturnsAddedItem()
        {
            //Arrange
            var newItem = new AddNewItem //Dto
            {
                Name = "Test",
                Price = 10,
                Quantity = 1,
            };
            _itemRepositoryMock.Setup(m => m.CheckIfItemExists(newItem.Name)).ReturnsAsync(false);
            _itemRepositoryMock.Setup(m => m.AddNewItem(It.IsAny<Item>())).ReturnsAsync(1);
            _itemRepositoryMock.Setup(m => m.GetItemById(1)).ReturnsAsync(new Item { id = 15, name = newItem.Name, price = newItem.Price, quantity = newItem.Quantity });

            //Act 
            var result = await _itemService.AddNewItem(newItem);

            //Assert
            result.name.Should().Be(newItem.Name);
            result.price.Should().Be(newItem.Price);
            result.quantity.Should().Be(newItem.Quantity);
        }

        [Fact]
        public async Task Update_GivenValidId_ReturnsDeletedItem()
        {
            //Arrange
            int itemId = 1;
            var updateItem = new Item
            {
                id = itemId,
                name = "Test",
                price = 10.89m,
                quantity = 1,
            };
            _itemRepositoryMock.Setup(m => m.UpdateItem(itemId, updateItem.name, updateItem.price, updateItem.quantity)).ReturnsAsync(true);

            //Act
            var result = await _itemService.UpdateItem(itemId, updateItem.name, updateItem.price, updateItem.quantity);

            //Assert
            result.Should().BeEquivalentTo(updateItem);
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(2)]
        public async Task Theory_Get_GivenValidId_ReturnsItemWithId(int id)
        {
            //Arrange
            //var expectedItem = new Item { id = id };
            var entity = _fixture.Build<Item>().With(m => m.id == id).Create();
            _itemRepositoryMock.Setup(m => m.GetItemById(id)).ReturnsAsync(entity);

            //Act
            var result = await _itemService.GetItemById(id);

            //Assert
            _itemRepositoryMock.Verify(m => m.GetItemById(id), Times.Once());

            result.id.Should().Be(id);
        }

        [Fact]
        public async Task NewFact_Get_GivenValidId_ReturnsItemWithId()
        {
            //Arrange
            int id = _fixture.Create<int>();
            var expectedItem = new Item { id = id };
            _itemRepositoryMock.Setup(m => m.GetItemById(id)).ReturnsAsync(expectedItem);

            //Act
            var result = await _itemService.GetItemById(id);

            //Assert
            _itemRepositoryMock.Verify(m => m.GetItemById(id), Times.Once());

            result.id.Should().Be(id);
        }
    }
}
