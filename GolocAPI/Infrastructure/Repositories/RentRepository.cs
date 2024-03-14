using GolocAPI.Entities;
using Infrastructure.Repositories.Common;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace GolocAPI.Infrastructure.Repositories;
public interface IRentRepository : IGenericRepository<Rent>
{
    IEnumerable<Rent> GetAll(String userId);
    Task AddMessage(ChatMessage chatMessage);
    Task<String> GetMessageReceiverId(Guid rentId, String senderId);
}
public class RentRepository : GenericRepository<Rent>, IRentRepository
{
    private readonly GolocDbContext golocDbContext;

    public RentRepository(GolocDbContext golocDbContext) : base(golocDbContext)
    {
        this.golocDbContext = golocDbContext;
    }

    public IEnumerable<Rent> GetAll(String userId)
    {
        return golocDbContext.Rents.Include(rent => rent.Product.Owner).Include(rent => rent.Renter).Where(rent => rent.RenterId == userId || rent.Product.OwnerId == userId).AsEnumerable();
    }
    public override async Task<Rent> GetById(Guid id)
    {
        return await golocDbContext.Rents.Include(rent => rent.Messages).Include(rent => rent.Renter).Include(rent => rent.Product.Owner).FirstAsync(rent => rent.Id == id);
    }
    public async Task<String> GetMessageReceiverId(Guid rentId, String senderId)
    {
        Rent rent = (await golocDbContext.Rents.Include(rent => rent.Product).FirstAsync(rent => rent.Id == rentId));
        return (rent.RenterId == senderId ? rent.Product.OwnerId : rent.RenterId);
    }
    public async Task AddMessage(ChatMessage chatMessage)
    {

        chatMessage.CreationDate = DateTime.Now;
        await golocDbContext.AddAsync(chatMessage);
    }
}
