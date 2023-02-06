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
    public class CleaningRepository : ICleaningRepository, IDisposable
    {
        private CleanerDBContext _context;

        public CleaningRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<List<Cleaning_type>> getAll()
        {

            return await _context.Cleaning_type.ToListAsync();
        }
        public async Task<bool> Save(Cleaning_type model)
        {
            try
            {
                await _context.Cleaning_type.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<int> CleaningDetailSave(Cleaning_details model)
        {
            try
            {
                await _context.Cleaning_details.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
          public async Task<List<Cleaning_details>> GetCleaningHistory(int agentid)
        {
            try
            {
                return await _context.Cleaning_details.Where(x => x.agentid == agentid).ToListAsync();

            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public async Task<bool> getCleaningTypes(string cleaning_type)
        {
            var res = await _context.Cleaning_type.Where(u => u.cleaning_type == cleaning_type).FirstOrDefaultAsync();
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