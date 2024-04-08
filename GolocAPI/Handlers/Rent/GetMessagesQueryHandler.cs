using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;

namespace GolocAPI.Handlers
{
    public class GetMessagesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<GetMessagesQuery, List<ChatMessageModel>>
    {
        public async Task<List<ChatMessageModel>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<RentModel>(await unitOfWork.RentRepository.GetById(request.RentId)).ChatMessages;
        }
    }
}
