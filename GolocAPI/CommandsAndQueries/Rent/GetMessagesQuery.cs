using GolocAPI.Models;
using MediatR;

namespace GolocAPI.CommandsAndQueries;

public record GetMessagesQuery(Guid RentId) : IRequest<List<ChatMessageModel>>;
