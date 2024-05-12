using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.TaskManager.Application.Models;
using TSM.TaskManager.Application.Services.Tasks.Models.Requests;
using TSM.TaskManager.Application.Services.Tasks.Models.Responses;

namespace TSM.TaskManager.Application.Services.Tasks;

public interface ITaskService
{
	public Task<IReadOnlyList<TaskResponse>> GetAll(CancellationToken cancellationToken);
	public Task<TaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken);
	public Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken);
	public Task<PagedList<SearchTaskResponse>> Search(SearchTasksRequest request, CancellationToken cancellationToken);
	public Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken);
	public Task Delete(DeleteTaskRequest request, CancellationToken cancellationToken);
}
