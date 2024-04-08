using AutoMapper;
using GolocAPI.CommandsAndQueries;
using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;
using MediatR;
namespace GolocAPI.Handlers;
public class AddRentComandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddRentCommand, RentModel>
{
    public async Task<RentModel> Handle(AddRentCommand rentCommand, CancellationToken cancellationToken)
    {
        Rent rent = mapper.Map<Rent>(rentCommand);
        rent.RenterId = rentCommand.RenterId;
        rent.Messages = new List<ChatMessage>() { new ChatMessage { Message = rentCommand.FirstMessage, SenderId = rentCommand.RenterId, CreationDate = DateTime.Now } };
        Rent rentResult = await unitOfWork.RentRepository.Create(rent);
        await unitOfWork.Save();
        return mapper.Map<RentModel>(rentResult);
    }
}
