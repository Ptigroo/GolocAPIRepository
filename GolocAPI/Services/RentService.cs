using AutoMapper;
using GolocAPI.Entities;
using GolocAPI.Models;
using Infrastructure.Repositories;

namespace GolocAPI.Services
{
    public interface IRentService
    {
        Task AddRent(RentPostModel rentPostModel, string renterId);
        Task<List<ChatMessageModel>> GetMessages(Guid id);
        List<RentModel> GetAllRents(string userId);
    }
    public class RentService : IRentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddRent(RentPostModel rentPostModel, string renterId)
        {
            Rent rent = mapper.Map<Rent>(rentPostModel);
            rent.RenterId = renterId;
            rent.Messages = new List<ChatMessage>() { new ChatMessage { Message = rentPostModel.FirstMessage, SenderId = renterId, CreationDate = DateTime.Now } };
            await unitOfWork.RentRepository.Create(rent);
            await unitOfWork.Save();
        }
        public async Task<List<ChatMessageModel>> GetMessages(Guid id)
        {
            return mapper.Map<RentModel>(await unitOfWork.RentRepository.GetById(id)).ChatMessages;
        }
        public List<RentModel> GetAllRents(string userId)
        {
            return unitOfWork.RentRepository.GetAll(userId).Where(rent => rent.RenterId == userId || rent.Product.OwnerId == userId).Select(rent => mapper.Map<RentModel>(rent)).ToList();
        }
    }
}
