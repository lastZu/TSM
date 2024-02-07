using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tasks.Models;
using TaskEntity = TSM.Task.Domain.Entities.Task;

namespace TSM.Task.Application.Services.Tasks;

public interface ITaskService
{
	public Task<List<GetTaskByIdResponse>> GetAll(CancellationToken cancellationToken = default);
	public Task<GetTaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default);
	public Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default);
	public Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default);
	public System.Threading.Tasks.Task Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default);
}