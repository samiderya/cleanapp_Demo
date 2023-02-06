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
    public class AgentRepository : IAgentRepository, IDisposable
    {
        private CleanerDBContext _context;

        public AgentRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Task<List<Agent>> getAll()
        {
            try
            {
                return _context.Agents.ToListAsync();

            }
            catch (System.Exception)
            {
                return null;
            }
        }
        public async Task<List<AgentDto>> getAgentNearest(double latitude, double longitude)
        {
            try
            {
                var coord = new GeoCoordinate(latitude, longitude);
                // DbGeography searchLocation = DbGeography.FromText(String.Format("POINT({0} {1})", longitude, latitude));

                var result = (from a in _context.Agents
                              join ar in _context.Agent_rate on a.Id equals ar.agentid
                              //join asr in _context.Agent_star_rate on a.Id equals asr.agentid
                              //                   let temp = Math.Sin(a.latitude.Value / latitude)
                              //    * Math.Sin(Convert.ToDouble(a.latitude.Value) / latitude)
                              //    + Math.Cos(Convert.ToDouble(a.latitude) / latitude)
                              //    * Math.Cos(Convert.ToDouble(a.latitude.Value) / latitude)
                              //    * Math.Cos((Convert.ToDouble(longitude) / latitude)
                              //    - (a.longitude.Value / latitude))
                              //                   let calMiles = (longitude * Math.Acos(temp > 1 ? 1 : (temp < -1 ? -1 : temp)))
                              //                   where (a.latitude > 0 && a.longitude > 0)
                              //                   orderby calMiles
                              select new AgentDto()
                              {
                                  // pin = new GeoCoordinate(a.latitude.Value, a.longitude.Value),
                                  agent_name = a.agent_name,
                                  address = a.agent_address,
                                  latitude = a.latitude,
                                  longitude = a.longitude,
                                  imgUrl = a.imgUrl,
                                  mile_range = common.distance(latitude, longitude, a.latitude.Value, a.longitude.Value, 'K'),
                                  //mile_range = 0.000621371*coord.GetDistanceTo(new GeoCoordinate(a.latitude.Value, a.longitude.Value)),
                                  phone_no = a.agent_phone,
                                  email = a.agent_email,
                                  rate = ar.hourly_rate
                                  // star = asr.agent_star
                                  // other assignments
                              });
                return await result.ToListAsync();
            }
            catch (System.Exception)
            {
                return null;
                throw;

            }

        }
        public async Task<int> Save(Agent model)
        {
            try
            {
                await _context.Agents.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public async Task<bool> SaveAgentUser(Agent_Users model)
        {
            try
            {
                await _context.Agent_Users.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public async Task<Agent> Update(Agent model)
        {
            try
            {
                var res = _context.Agents.Update(model);
                _context.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (System.Exception ex)
            {
                return null;
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