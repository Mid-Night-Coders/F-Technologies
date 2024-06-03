using FTech.Domain.Entities.Chats;
using FTech.Infrastructure.Data;
using FTech.Infrastructure.Repositories.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTech.Infrastructure.Repositories.ChatUsers
{
    public interface IChatUserRepository : IBaseRepository<ChatUser>
    {
    }
}
