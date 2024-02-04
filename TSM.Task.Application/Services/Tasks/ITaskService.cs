using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Application.Services.Tasks;

public interface ITaskService
{
	public Task<CreateTaskResponse> Create(CreateTaskRequest request, CancellationToken cancellationToken = default);
	public Task<List<GetTaskByIdResponse>> GetAll(CancellationToken cancellationToken = default);
	public Task<GetTaskByIdResponse> GetById(GetTaskByIdRequest request, CancellationToken cancellationToken = default);
	public Task<UpdateTaskResponse> Update(UpdateTaskRequest request, CancellationToken cancellationToken = default);
	public void Delete(DeleteTaskRequest request, CancellationToken cancellationToken = default);
}