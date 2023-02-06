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
    public class RateRepository : IRateRepository, IDisposable
    {
        private CleanerDBContext _context;

        public RateRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<List<Star_rate_detail>> getAllRates()
        {

            return await _context.Star_rate_details.ToListAsync();
        }
        public async Task<List<Star_rate_detail>> getRateByUserId(short userId)
        {
            var res = _context.Star_rate_details.Where(u => u.user_id.Equals(userId));
            return res != null ? await res.ToListAsync() : null;
        }
        public async Task<bool> RateStarSave(Star_rate_detail model)
        {
            try
            {
                await _context.Star_rate_details.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
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