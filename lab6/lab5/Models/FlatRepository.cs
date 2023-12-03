
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace lab5.Models
{
    internal class FlatRepository:IRepository<Flat>
    {
        protected SqlConnection _connection;
        public FlatRepository(SqlConnection connection) { 
        _connection= connection;
        }
        public List<Flat> GetAll() {
            var flat = new List<Flat>();
            string query = $"SELECT * from [Table] ";
            
            using(SqlCommand cmd = new SqlCommand(query,_connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Flat item = new Flat()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Data = Convert.ToString(reader["data"]),
                            Square = Convert.ToInt32(reader["square"]),
                        };
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> A (int price)
        {
            var flat = new List<Flat>();
            string query = $"SELECT * from [Table] where [Table].price ={price}";
            
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Data = Convert.ToString(reader["data"]),
                            Square = Convert.ToInt32(reader["square"]),
                        };
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> B()
        {
            string query = $"select * from [Table] where data is null";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat();
                        item.Id = Convert.ToInt32(reader["id"]);
                        item.Data = Convert.ToString(reader["data"]);
                        item.Square = Convert.ToInt32(reader["square"]);
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> C(int price1,int floor)
        {
            string query = $"select [Table].floor,[Table].price from [Table] where price>{price1} and floor='{floor}'";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat
                        {
                            Price = Convert.ToInt32(reader["price"]),
                            Floor = Convert.ToInt32(reader["floor"])
                        };
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> D()
        {
            string query = $"select distinct price from [Table]";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat();
                        item.Price = Convert.ToInt32(reader["price"]);
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> E()
        {
            string query = $"select count(*) as count from [Table] group by price";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat
                        {
                            Price = Convert.ToInt32(reader["count"]),
                        };

                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> F(int number)
        {
            string query = $"select count(*) as area, price from [Table] group by price having count(*) >{number}";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat();
                        item.Area = Convert.ToString(reader["area"]);
                        item.Price = Convert.ToInt32(reader["price"]);
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public List<Flat> G()
        {
            string query = $"select count(*) ,price from [Table] group by price order by [Table].price ASC;";
            var flat = new List<Flat>();
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flat item = new Flat();
                        item.Price = Convert.ToInt32(reader["price"]);
                        flat.Add(item);

                    }
                }

            }
            return flat;

        }
        public int H(int from ,int to)
        {
            string query = $"update [Table] set price={to} where price={from}";
            
            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                return cmd.ExecuteNonQuery();

            }
            

        }
    }
}
