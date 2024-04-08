using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;

namespace GolocAPI.Handlers;

public class GetAllRentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllRentsQuery, List<RentModel>>
{
    public async Task<List<RentModel>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
    {
        return unitOfWork.RentRepository.GetAll(request.UserId).Where(rent => rent.RenterId == request.UserId || rent.Product.OwnerId == request.UserId).Select(rent => mapper.Map<RentModel>(rent)).ToList();
    }
}
