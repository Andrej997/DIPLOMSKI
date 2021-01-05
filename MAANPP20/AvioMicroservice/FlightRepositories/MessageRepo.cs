using Common.Models.Common;
using AvioMicroservice.Data;
using AvioMicroservice.FlightInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvioMicroservice.FlightRepositories
{
    public class MessageRepo : IMessage
    {
        public async Task<ActionResult<Message>> AddFriendRequest(MAANPP20ContextFlight _context, Message message)
        {
            if (message.myId == message.hisId) return null;

            var user = await _context.Users
                .Include(address => address.address)
                .Include(friends => friends.friends)
                    .ThenInclude(messages => messages.messages)
                .FirstOrDefaultAsync(i => i.Id == message.myId);

            if (user == null) return null;

            foreach (var friend in user.friends)
            {
                if (friend.deleted == false)
                    if (friend.hisId == message.hisId)
                        friend.messages.Add(message);
            }
            // ja sam poslao zahtev
            _context.Messages.Add(message);

            var he = await _context.Users
                .Include(address => address.address)
                .Include(friends => friends.friends)
                    .ThenInclude(messages => messages.messages)
                .FirstOrDefaultAsync(i => i.Id == message.hisId);


            if (he == null) return null;

            var tempMessage = new Message();
            tempMessage.hisId = message.myId;
            tempMessage.myId = message.hisId;
            tempMessage.isUnread = message.isUnread;
            tempMessage.dateTime = message.dateTime;
            tempMessage.text = message.text;
            foreach (var friend in he.friends)
            {
                if (friend.deleted == false)
                    if (friend.myId == message.hisId)
                        friend.messages.Add(tempMessage);
            }
            // ja sam poslao zahtev
            _context.Messages.Add(tempMessage);

            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<ActionResult<IEnumerable<Message>>> GetUser(MAANPP20ContextFlight _context, string id)
        {
            if (id == null) return null;
            string myId = id.Split('|')[0];
            string hisId = id.Split('|')[1];

            var messages = await _context.Messages
                .Where(x => x.deleted == false && x.myId == myId && x.hisId == hisId)
                .ToListAsync();

            if (messages == null)
            {
                return null;
            }

            return messages;
        }
    }
}
