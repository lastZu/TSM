using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TSM.WorkLog.Application.Services;
using WorkLogEntity = TSM.WorkLog.Domain.Entities.WorkLog;
using TSM.WorkLog.Application.Services.WorkLogs;
using TSM.WorkLog.Infrastructure;

namespace TSM.WorkLogs.Application.Services;

public sealed class WorkLogService : IWorkLogService
{
	private readonly WorkLogContext _workLogContext;

	private readonly DbSet<WorkLogEntity> _workLogsSet;

	private readonly IMapper _mapper;

	public WorkLogService(WorkLogContext workLogContext, IMapper mapper)
	{
		_workLogContext = workLogContext;
		_mapper = mapper;

		_workLogsSet = _workLogContext.Set<WorkLogEntity>();
	}

	public async Task<IReadOnlyList<WorkLogResponse>> GetAll(CancellationToken cancellationToken)
	{
		var workLogs = await _workLogsSet
			.AsNoTracking()
			.ToListAsync(cancellationToken);

		return _mapper.Map<IReadOnlyList<WorkLogResponse>>(workLogs);
	}

	public async Task<WorkLogByIdResponse> GetById(WorkLogByIdRequest request, CancellationToken cancellationToken)
	{
		var workLog = await _workLogsSet
			.AsNoTracking()
			.Where(workLog => workLog.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		return _mapper.Map<WorkLogByIdResponse>(workLog);
	}

	public async Task<CreateWorkLogResponse> Create(CreateWorkLogRequest request, CancellationToken cancellationToken)
	{
		var workLog = _mapper.Map<WorkLogEntity>(request);

		await _workLogsSet.AddAsync(workLog, cancellationToken);

		await _workLogContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<CreateWorkLogResponse>(workLog);
	}

	public async Task<UpdateWorkLogResponse> Update(UpdateWorkLogRequest request, CancellationToken cancellationToken)
	{
		var workLog = await _workLogsSet
			.Where(workLog => workLog.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		_mapper.Map(request, workLog);

		_workLogsSet.Update(workLog);

		await _workLogContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<UpdateWorkLogResponse>(workLog);
	}
}
