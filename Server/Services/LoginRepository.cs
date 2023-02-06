using System;
using Server.Contexts;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Microsoft.EntityFrameworkCore;
using Server.Helpers;

namespace Server.Services
{
    public class LoginRepository : ILoginRepository, IDisposable
    {
        private CleanerDBContext _context;

        public LoginRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<List<Login_Types>> getLoginTypes()
        {

            return await _context.Login_Types.ToListAsync();
        }
        public async Task<bool> Save(Login_Types model)
        {
            try
            {
                await _context.Login_Types.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<bool> getLoginTypes(string login_type)
        {
            var res = await _context.Login_Types.Where(u => u.login_type == login_type).FirstOrDefaultAsync();
            return res != null ? true : false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }


    }
}