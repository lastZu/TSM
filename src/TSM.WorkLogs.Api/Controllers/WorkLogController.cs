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
public class WorkLogController : ControllerBase
{
    private readonly IWorkLogService _workLogService;

    public WorkLogController(IWorkLogService workLogService)
    {
        _workLogService = workLogService;
    }

    [HttpGet]
    public async Task<List<WorkLogResponse>> GetAll(CancellationToken cancellationToken)
    {
        return await _workLogService.GetAll(cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<WorkLogByIdResponse> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new WorkLogByIdRequest
        {
            Id = id
        };

        return await _workLogService.GetById(request, cancellationToken);
    }

    [HttpPost]
    public async Task<CreateWorkLogResponse> Create([FromBody] CreateWorkLogRequest request, CancellationToken cancellationToken)
    {
        return await _workLogService.Create(request, cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<UpdateWorkLogResponse> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateWorkLogRequest request,
        CancellationToken cancellationToken)
    {
        request.Id = id;

        return await _workLogService.Update(request, cancellationToken);
    }
}
