using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace ConsoleApp11
{
    internal class FlatRepository
    {
        protected AppDbcontext _dbcontext;
        public FlatRepository (AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        

       public async Task<List<Flat>> A(int price)
        {
            return await _dbcontext.Flats
                .Where(flat => flat.Price == price)
                .Select(flat => new Flat
                {
                    Id = flat.Id,
                    Square = flat.Square,
                    Price = flat.Price
                })
                .ToListAsync();
        }

        public async Task<List<Flat>> B()
        {
          return await _dbcontext.Flats.Where(flat=>flat.Data=="no").ToListAsync();
        }
        public async Task<List<Flat>> C(int price1, int floor)
        {
            return await _dbcontext.Flats.Where(flat => flat.Price>price1&& flat.Floor==floor).ToListAsync();

        }
        public async Task<List<int>> D()
        {
           
           return await _dbcontext.Flats.Select(x => x.Price).Distinct().ToListAsync();

        }
        public async Task<List<Count>> E()
        {
            return await _dbcontext.Flats
        .GroupBy(flat => flat.Price)
        .Select(group => new Count { Price = group.Key, Count1 = group.Count() })
        .ToListAsync();
        }
        public async Task<List<Count>> F(int number)
        {
            
           return await _dbcontext.Flats.GroupBy(flat => flat.Price)
        .Where(group => group.Count() > number)
        .Select(group => new Count { Price = group.Key, Count1 = group.Count() })
        .ToListAsync();

        }
        public async Task<List<Count>> G()
        {
            
            return await _dbcontext.Flats.GroupBy(t => t.Price)
    .Select(g => new Count { Price = g.Key, Count1 = g.Count() })
    .OrderBy(x => x.Price)
    .ToListAsync();

        }
        public async Task<int> H(int to ,int from) {
         (await _dbcontext.Flats.Where(flat => flat.Price == from).ToListAsync()).ForEach(flat => flat.Price = to);
            return await _dbcontext.SaveChangesAsync();
        }



    }
}
