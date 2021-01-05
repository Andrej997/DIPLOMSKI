using Common.Models.Common;
using Common.Models.Common_U;
using AvioMicroservice.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightInterfaces
{
    public interface IFriend
    {
        Task<ActionResult<User>> GetUser(MAANPP20ContextFlight _context, string email);
        Task<ActionResult<IEnumerable<User>>> GetWaitingUsers(MAANPP20ContextFlight _context, string email);
        Task<ActionResult<IEnumerable<User>>> GetFriendRequestUsers(MAANPP20ContextFlight _context, string email);
        Task<ActionResult<IEnumerable<User>>> GetFriendlist(MAANPP20ContextFlight _context, string email);
        Task<ActionResult<FriendRequest>> AddFriendRequest(MAANPP20ContextFlight _context, FriendRequest friendRequest);
        Task<ActionResult<Friend>> AddFriend(MAANPP20ContextFlight _context, string id);
        Task<ActionResult<FriendRequest>> DeleteFriendRequest(MAANPP20ContextFlight _context, string id);
        Task<Friend> DeleteFriend(MAANPP20ContextFlight _context, string id);
    }
}
