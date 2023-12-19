using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace WebApplication1.Models
{
    internal class FlatRepository
    {
        protected AppDbcontext _dbcontext;
        public FlatRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Flat> Create(Flat value)
        {
            var flat = await _dbcontext.AddAsync(value);
            await _dbcontext.SaveChangesAsync();
            return flat.Entity;
        }

        public async Task<List<Flat>> GetAll()
        {
            return await _dbcontext.Flats.ToListAsync();
        }
        public async Task<Flat> GetById(int id)
        {
            var flat = await _dbcontext.Flats.FindAsync(id);
            return flat;
        }
        public async Task<Flat> Delete(int id)
        {
            var flat = await _dbcontext.Flats.FindAsync(id);
            if (flat == null)
            {
                return null;
            }
            _dbcontext.Flats.Remove(flat);
            await _dbcontext.SaveChangesAsync();
            return flat;
        }
        public async Task<Flat> Update(int id, Flat value)
        {
            var flat = await _dbcontext.Flats.FindAsync(id);
            if (flat == null)
            {
                return null;
            }
            flat.Area = value.Area;
            flat.Floor = value.Floor;
            flat.Square = value.Square;
            flat.Number = value.Number;
            flat.Data = value.Data;
            flat.Price = value.Price;
            _dbcontext.Flats.Entry(flat).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return flat;
        }



    }
}
