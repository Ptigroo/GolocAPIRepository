using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using GolocAPI.Models;
using Newtonsoft.Json;
using Infrastructure.Repositories;
using AutoMapper;
using GolocAPI.Entities;
namespace GolocAPI.Services;
[Authorize]
public class ChatHub(IUnitOfWork unitOfWork, IMapper mapper) : Hub
{
    public async Task SendMessage(string message)
    {
            String senderId = Context.User.Identity.GetUserId();
            ChatMessageModel messageModel = JsonConvert.DeserializeObject<ChatMessageModel>(message);
            String receiverId = await unitOfWork.RentRepository.GetMessageReceiverId(messageModel.RentId, senderId);
            messageModel.SenderId = senderId;
            await unitOfWork.RentRepository.AddMessage(mapper.Map<ChatMessage>(messageModel));
            await unitOfWork.Save();
            await Clients.User(receiverId).SendAsync("ReceiveMessage", JsonConvert.SerializeObject(messageModel));
    }
}
