using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TSM.TaskManager.Application.Services.Tags.Models.Requests;
using TSM.TaskManager.Application.Services.Tags.Models.Responses;

namespace TSM.TaskManager.Application.Services.Tags;

public interface ITagService
{
	Task<IReadOnlyList<TagResponse>> GetAll(CancellationToken cancellationToken);

	Task<CreateTagResponse> Create(CreateTagRequest request, CancellationToken cancellationToken);

	Task<UpdateTagResponse> Update(UpdateTagRequest request, CancellationToken cancellationToken);

	Task Delete(DeleteTagRequest request, CancellationToken cancellationToken);
}