using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tasks.Models.Requests;
using TSM.Task.Application.Services.Tasks.Models.Responses;

namespace TSM.Task.Application.Services.Tasks;

public interface ITaskService
{
    public Task<List<TaskResponse>> GetAll(CancellationToken cancellationToken = default);
    public Task<TaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default);
    public Task<PagedList<SearchTaskResponse>> Search(SearchTaskRequest request, CancellationToken cancellationToken = default);
    public Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default);
    public Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default);
    public System.Threading.Tasks.Task Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default);
}