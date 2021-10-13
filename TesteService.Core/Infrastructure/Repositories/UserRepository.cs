using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteService.Core.Entities;
using TesteService.Core.Infrastructure.Context;
using TesteService.Core.Interfaces;

namespace TesteService.Core.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<TUser>, IUserRepository
    {
        public UserRepository(TesteDb context) : base(context)
        {
        }

        public override Task<TUser> GetByIdAsync(Guid ID)
        {
            return _context.Set<TUser>().Where(x => x.ID == ID).Include(x => x.Account).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<TUser> FindByCpf(int cpf)
        {
            return _context.Set<TUser>().Where(x => x.CPF_CNPJ == cpf).Include(x => x.Account).FirstOrDefaultAsync();
        }

        public Task<TUser> FindByEmail(string email)
        {
            return _context.Set<TUser>().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

    }
}
