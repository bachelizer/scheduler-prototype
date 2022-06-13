using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using backend.Model;
using backend.Contracts;

namespace backend.Repository
{
    public class AuthRepo : IAuth
    {
        private string connectionString;

        public AuthRepo()
        {
            connectionString = ConnectionStr.databaseConnection;
        }
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public async Task<User> Auth(string username, string password)
        {
            string qry = @"select b.instructor_id, c.lastname, c.firstname, c.middlename, c.designation, a.role, b.fkcourseidPC from tbl_is_useraccount a
                        left join tbl_instructor b on b.instructor_id = a.instructor_id
                        left join tblenrolsysusers c on c.staff_id = a.staff_id
                        where a.username = @username and a.`password` = EncryptPassword(@password);";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryFirstOrDefaultAsync<User>(qry, new { username = username, password = password});
                return data;
            }
        }
    }
}