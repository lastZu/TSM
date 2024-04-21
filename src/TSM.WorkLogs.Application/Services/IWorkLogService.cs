using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.WorkLogs.Application.Services.WorkLogs;

namespace TSM.WorkLogs.Application;

public interface IWorkLogService
{
    public Task<List<WorkLogResponse>> GetAll(CancellationToken cancellationToken = default);
    public Task<WorkLogByIdResponse> GetById(WorkLogByIdRequest request, CancellationToken cancellationToken = default);
    public Task<CreateWorkLogResponse> Create(CreateWorkLogRequest request, CancellationToken cancellationToken = default);
    public Task<UpdateWorkLogResponse> Update(UpdateWorkLogRequest request, CancellationToken cancellationToken = default);
}
