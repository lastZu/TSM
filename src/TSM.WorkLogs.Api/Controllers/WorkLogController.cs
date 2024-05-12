using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSM.WorkLogs.Application;
using TSM.WorkLogs.Application.Services.WorkLogs;

namespace TSM.WorkLogs.Api.Controllers;

[ApiController]
[Route("work-logs")]
internal sealed class WorkLogController : ControllerBase
{
	private readonly IWorkLogService _workLogService;

	public WorkLogController(IWorkLogService workLogService)
	{
		_workLogService = workLogService;
	}

	[HttpGet]
	public Task<List<WorkLogResponse>> GetAll(CancellationToken cancellationToken)
	{
		return _workLogService.GetAll(cancellationToken);
	}

	[HttpGet("{id:guid}")]
	public Task<WorkLogByIdResponse> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
	{
		var request = new WorkLogByIdRequest
		{
			Id = id
		};

		return _workLogService.GetById(request, cancellationToken);
	}

	[HttpPost]
	public Task<CreateWorkLogResponse> Create([FromBody] CreateWorkLogRequest request, CancellationToken cancellationToken)
	{
		return _workLogService.Create(request, cancellationToken);
	}

	[HttpPut]
	public Task<UpdateWorkLogResponse> Update(
		[FromBody] UpdateWorkLogRequest request,
		CancellationToken cancellationToken)
	{
		return _workLogService.Update(request, cancellationToken);
	}
}
