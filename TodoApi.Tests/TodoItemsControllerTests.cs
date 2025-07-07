using todoApi.DTO;
using FluentAssertions;
using Xunit;

namespace TodoApi.Tests
{
    public class TodoItemsControllerTests : IClassFixture<CustomWebApplicationFactory<todoApi.Program>>
    {
        private readonly HttpClient _client;

        public TodoItemsControllerTests(CustomWebApplicationFactory<todoApi.Program> factory)
        {
            ArgumentNullException.ThrowIfNull(factory);
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTodoItems_ReturnsSuccessAndList()
        {
            var response = await _client.GetAsync("/api/todoitems");
            response.EnsureSuccessStatusCode();

            var items = await response.Content.ReadFromJsonAsync<List<TodoItemDTO>>();
            items.Should().NotBeNull();
        }

        [Fact]
        public async Task PostTodoItem_CreatesItemSuccessfully()
        {
            var newItem = new TodoItemDTO
            {
                Name = "Integration Test Item",
                IsComplete = false
            };

            var response = await _client.PostAsJsonAsync("/api/todoitems", newItem);
            response.EnsureSuccessStatusCode();

            var createdItem = await response.Content.ReadFromJsonAsync<TodoItemDTO>();
            createdItem.Should().NotBeNull();
            createdItem!.Name.Should().Be("Integration Test Item");
        }
    }
}