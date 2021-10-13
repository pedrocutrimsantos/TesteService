using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteService.Core.Entities;

namespace TesteService.Core.Interfaces
{
    public interface IUserRepository : IRepository<TUser>
    {
        Task<TUser> FindByCpf(int cpf);
        Task<TUser> FindByEmail(string email);
    }
}
