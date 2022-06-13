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
    public class RoomRepo : IRoom
    {
        private string connectionString;
        // private readonly StudentRepo _studentRepo;

        public RoomRepo()
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

        public async Task<IEnumerable<Room>> Read()
        {
            string qry = "SELECT * FROM tblrooms JOIN tblinstitute ON tblrooms.`institute_id` = tblinstitute.`institute_id`;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<Room>(qry);
                return data;
            }
        }

    }
}