﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApp.Domain.Models;
using TodoApp.Domain.Models.EF;
using TodoApp.Infrastructure.Dtos.TodoDtos;
using TodoApp.Infrastructure.Pagination;
using TodoApp.Domain.Models.Entities;

namespace Todo.Application.Services.TodoServices
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public TodoService(ApplicationDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ApiResponse> GetAllTodos(PagingRequest pagingRequest)
        {
            
            /*// Call stored procedure for pagination
            *//*   var todos = await _dbContext.Set<Todo>()
                .FromSqlRaw("EXEC dbo.GetTodosWithPaging @PageNumber, @PageSize, @SearchTerm",
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@PageSize", pageSize),
                    new SqlParameter("@SearchTerm", searchTerm ?? (object)DBNull.Value))
                .ToListAsync();*/
            var todos = "";
            var todoListVm = _mapper.Map<List<TodoVm>>(todos);

            return new ApiResponse
            {
                Success = true,
                Message = "Todos fetched successfully.",
                Data = todoListVm
            };
        }

        public async Task<ApiResponse> GetTodoById(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Todo not found!"
                };
            }

            var todoVm = _mapper.Map<TodoVm>(todo);

            return new ApiResponse
            {
                Success = true,
                Message = "Todo fetched successfully.",
                Data = todoVm
            };
        }

        /*public async Task<ApiResponse> CreateTodo(TodoVm todoVm)
        {
            var todo = _mapper.Map<Todo>(todoVm);
            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse
            {
                Success = true,
                Message = "Todo created successfully."
            };
        }*/
        public async Task<ApiResponse> CreateTodo(TodoVm todoVm)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> UpdateTodo(int id, TodoVm todoVm)
        {
            var todo = await _dbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Todo not found!"
                };
            }

            _mapper.Map(todoVm, todo);
            _dbContext.Todos.Update(todo);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse
            {
                Success = true,
                Message = "Todo updated successfully."
            };
        }

        public async Task<ApiResponse> DeleteTodo(int id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Todo not found!"
                };
            }

            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();

            return new ApiResponse
            {
                Success = true,
                Message = "Todo deleted successfully."
            };
        }
    }
}
