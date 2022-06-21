using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employesControl_V2.Data;
using employesControl_V2.Models;
using employesControl_V2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace employesControl_V2.Repository
{
    public class LiderRepository : ILiderRepository
    {
        private readonly DataContext _context;
        public LiderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lider>> Get()
        {
            return await _context.Lideres.ToListAsync();
        }
        public async Task<Lider> GetById(int id)
        {
            return await _context.Lideres.
                Where(x => x.id == id).FirstOrDefaultAsync();
        }
        public void Put(Lider entity)
        {
            _context.Update(entity);
        }
        public void Post(Lider entity)
        {
            _context.Add(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Delete(Lider entity)
        {
            _context.Remove(entity);
        }
    }
}