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
    public class UserRepository : IUserRepository, IDisposable
    {
        private CleanerDBContext _context;

        public UserRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<List<Users>> getUsers()
        {

            return await _context.Users.ToListAsync();
        }
        public async Task<List<Users>> getUsersByService(char serviceId)
        {
            // return await _context.Users.ToListAsync();
            return await _context.Users.Where(x => x.serviceId.Contains(serviceId)).ToListAsync();
        }
        public async Task<Users> getUserName(string email)
        {
            var res = await _context.Users.Where(u => u.email.Equals(email)).FirstOrDefaultAsync();
            return res != null ? res : null;
        }

        public async Task<Users> getAccount(string email, string password)
        {


            try
            {

                var result = await _context.Users
                             .FirstOrDefaultAsync(m => m.email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && m.password.Equals(password, StringComparison.InvariantCultureIgnoreCase));
                if (result != null)
                {
                    result.LastLogin = DateTime.Now;
                    result.IsLoggedIn = 1;
                    result.Token = GenerateUserAuthToken.GenerateTokenString();
                    _context.Users.Update(result);
                    await _context.SaveChangesAsync();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an internal error, please contact to technical support. with error={ex.Message}");

            }



        }
        public async Task<Users> Register(Users model)
        {
            try
            {
                model.Token = GenerateUserAuthToken.GenerateTokenString();
                var res = await _context.Users.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Users> Update(Users model)
        {
            try
            {
                model.LastLogin = DateTime.Now;
                model.IsLoggedIn = 1;
                model.Token = GenerateUserAuthToken.GenerateTokenString();
                _context.Users.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
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