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
        public List<Flat> A(int price)
        {
            return _dbcontext.Flats
                .Where(flat => flat.Price == price)
                .Select(flat => new Flat
                {
                    Id = flat.Id,
                    Square = flat.Square,
                    Price = flat.Price
                })
                .ToList();
        }

        public List<Flat> B()
        {
          return _dbcontext.Flats.Where(flat=>flat.Data=="no").ToList();
        }
        public List<Flat> C(int price1, int floor)
        {
            return _dbcontext.Flats.Where(flat => flat.Price>price1&& flat.Floor==floor).ToList();

        }
        public List<int> D()
        {
           
           return _dbcontext.Flats.Select(x => x.Price).Distinct().ToList();

        }
        public List<Count> E()
        {
            return _dbcontext.Flats
        .GroupBy(flat => flat.Price)
        .Select(group => new Count { Price = group.Key, Count1 = group.Count() })
        .ToList();
        }
        public List<Count> F(int number)
        {
            string query = $"select count(*) as area, price from [Table] group by price having count(*) >{number}";
           return _dbcontext.Flats.GroupBy(flat => flat.Price)
        .Where(group => group.Count() > number)
        .Select(group => new Count { Price = group.Key, Count1 = group.Count() })
        .ToList();

        }
        public List<Count> G()
        {
            string query = $"select count(*) ,price from [Table] group by price order by [Table].price ASC;";
            return _dbcontext.Flats.GroupBy(t => t.Price)
    .Select(g => new Count { Price = g.Key, Count1 = g.Count() })
    .OrderBy(x => x.Price)
    .ToList();

        }
        public int H(int to ,int from) {
         _dbcontext.Flats.Where(flat => flat.Price == from).ToList().ForEach(flat => flat.Price = to);
            return _dbcontext.SaveChanges();
        }



    }
}
