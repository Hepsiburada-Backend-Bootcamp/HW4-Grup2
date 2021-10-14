using Dapper;
using HW4_Grup4.Domain.Entities;
using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HW4_Grup4.Infrastructure.Repositories
{
    public class UserDapperRepository : DapperRepository<User>, IUserDapperRepository
    {
        private string Connectionstring = "default";
        private readonly IConfiguration _config;
        public UserDapperRepository(DapperContext context, IConfiguration config) : base(context)
        {
            _config = config;
        }

        public async Task<List<User>> GetUser(int id)
        {
            using IDbConnection db = new System.Data.SqlClient.SqlConnection(_config.GetConnectionString(Connectionstring));

            var query = "SELECT * FROM Users";

            var product = await db.QuerySingleOrDefaultAsync<User>(query);

            var list = new List<User>();
            list.Add(product);

            return list;
        }
    }
}
