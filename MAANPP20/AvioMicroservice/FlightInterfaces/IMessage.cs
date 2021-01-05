using Common.Models.Common;
using AvioMicroservice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IMessage
    {
        Task<ActionResult<IEnumerable<Message>>> GetUser(MAANPP20ContextFlight _context, string id);
        Task<ActionResult<Message>> AddFriendRequest(MAANPP20ContextFlight _context, Message message);
    }
}
