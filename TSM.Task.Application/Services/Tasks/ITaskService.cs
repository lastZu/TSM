using TSM.Task.Application.Services.Tasks.Models;

namespace TSM.Task.Application.Services.Tasks;

public interface ITaskService
{
	public CreateTaskResponcse Create(CreateTaskRerquest request);
	public ReadTaskResponcse GetById(ReadTaskRerquest request);
	public UpdateTaskResponcse Update(UpdateTaskRequest request);
	public void Delete(DeleteTaskRerquest request);
	public void Save();
}