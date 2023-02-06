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
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private CleanerDBContext _context;

        public TransactionRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<List<Transactions>> getTransactionByUserId(short userId)
        {
            var res = _context.Transactions.Where(u => u.user_id.Equals(userId));
            return res != null ? await res.ToListAsync() : null;
        }
        public async Task<bool> Save(Transactions model)
        {
            try
            {
                var res = await _context.Transactions.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
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