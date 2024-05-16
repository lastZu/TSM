using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TSM.TaskManager.Infrastructure;
using TSM.TaskManager.Domain.Entities;
using TSM.TaskManager.Application.Services.Tags.Models.Requests;
using TSM.TaskManager.Application.Services.Tags.Models.Responses;

namespace TSM.TaskManager.Application.Services.Tags;

internal sealed class TagService : ITagService
{
	private readonly TaskContext _taskContext;
	private readonly DbSet<Tag> _tagsSet;
	private readonly IMapper _mapper;

	public TagService(TaskContext taskContext, IMapper mapper)
	{
		_taskContext = taskContext;
		_mapper = mapper;

		_tagsSet = _taskContext.Set<Tag>();
	}

	public async Task<IReadOnlyList<TagResponse>> GetAll(CancellationToken cancellationToken)
	{
		var tags = await _tagsSet
			.AsNoTracking()
			.ToListAsync(cancellationToken);

		return _mapper.Map<IReadOnlyList<TagResponse>>(tags);
	}

	public async Task<CreateTagResponse> Create(CreateTagRequest request, CancellationToken cancellationToken)
	{
		var tag = _mapper.Map<Tag>(request);

		await _tagsSet.AddAsync(tag, cancellationToken);

		await _taskContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<CreateTagResponse>(tag);
	}

	public async Task<UpdateTagResponse> Update(UpdateTagRequest request, CancellationToken cancellationToken)
	{
		var tag = await _tagsSet
			.Where(tag => tag.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		if (tag is null)
		{
			throw new ArgumentOutOfRangeException($"Tag {request.Id} is not found");
		}

		_mapper.Map(request, tag);

		_tagsSet.Update(tag);

		await _taskContext.SaveChangesAsync(cancellationToken);

		return _mapper.Map<UpdateTagResponse>(tag);
	}

	public async System.Threading.Tasks.Task Delete(DeleteTagRequest request, CancellationToken cancellationToken)
	{
		var tag = await _tagsSet
			.Where(tag => tag.Id == request.Id)
			.FirstOrDefaultAsync(cancellationToken);

		if (tag is null)
		{
			throw new ArgumentOutOfRangeException($"Tag with id - {request.Id} does not exists");
		}

		_tagsSet.Remove(tag);

		await _taskContext.SaveChangesAsync(cancellationToken);
	}
}