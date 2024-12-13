

using TodoApp.Domain.Models;
using TodoApp.Infrastructure.Dtos.TodoDtos;
using TodoApp.Infrastructure.Pagination;

namespace Todo.Application.Services.TodoServices
{
    public interface ITodoService
    {
        Task<ApiResponse> GetAllTodos(PagingRequest pagingRequest);
        Task<ApiResponse> GetTodoById(int id);
        Task<ApiResponse> CreateTodo(TodoVm todoVm);
        Task<ApiResponse> UpdateTodo(int id, TodoVm todoVm);
        Task<ApiResponse> DeleteTodo(int id);
    }

}
