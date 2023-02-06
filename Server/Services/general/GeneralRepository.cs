using System;
using Server.Contexts;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Microsoft.EntityFrameworkCore;
using Server.Helpers;
using Server.Models.Dto;
using GeoCoordinatePortable;

namespace Server.Services
{
    public class GeneralRepository : IGeneralRepository, IDisposable
    {
        private CleanerDBContext _context;

        public GeneralRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<bool> Save(List<General_info_answer> model)
        {
            try
            {

                await _context.General_info_answer.AddRangeAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
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