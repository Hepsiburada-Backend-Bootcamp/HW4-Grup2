using Dapper;
using HW4_Grup2.Domain.Entities;
using HW4_Grup2.Domain.Repositories;
using HW4_Grup2.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HW4_Grup2.Infrastructure.Repositories
{
    public class ProductDapperRepository : DapperRepository<Product>, IProductDapperRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;
        public ProductDapperRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task AddProductAsync(Product product)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                
                var query = "Insert into Products (Name, Price)" +
                $" Values('{product.Name}',  {product.Price})";

                await db.ExecuteAsync(query);
            }
        }
        

        public async Task<List<Product>> GetProductsAsync()
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var query = $"select * from Products";

                var productList = await db.QueryAsync<Product>(query);

                return productList.ToList();
            }
        }

        public async Task<List<Product>> GetProductsById(List<int> productIdList)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var query = $"select * from Products where Id in ( { string.Join(',', productIdList)} )";

                var productList = await db.QueryAsync<Product>(query);

                return productList.ToList();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
               
                var query = "Delete from products where Id = @Id";

                db.Execute(query, new { Id = id });
            }
        }

    }
}
