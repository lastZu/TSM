using System.Collections.Generic;

using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Application.Services.Tasks;

public interface ITaskService
{
	public CreateTaskResponse Create(CreateTaskRequest request);
	public List<ReadTaskResponse> GetAll();
	public ReadTaskResponse GetById(ReadTaskRerquest request);
	public UpdateTaskResponcse Update(UpdateTaskRequest request);
	public void Delete(DeleteTaskRerquest request);
	public void Save();
}