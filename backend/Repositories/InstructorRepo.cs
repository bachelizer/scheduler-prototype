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
    public class InstructorRepo : IInstructor
    {
        private string connectionString;
        // private readonly StudentRepo _studentRepo;

        public InstructorRepo()
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

        public async Task<IEnumerable<Instructor>> Read()
        {
            // add your code here ***Fetching Instructors***
            string qry = "SELECT a.*, b.`institute_title` FROM tbl_instructor a JOIN tblinstitute b ON a.`institute_id` = b.`institute_id`;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<Instructor>(qry);
                return data;
            }
        }
        public async Task<IEnumerable<Instructor>> FetchPWDInstructors()
        {
            // add your code here ***Fetching Instructors***
            string qry = "SELECT a.*, b.`institute_title` FROM tbl_instructor a JOIN tblinstitute b ON a.`institute_id` = b.`institute_id` WHERE a.isPWD = TRUE;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<Instructor>(qry);
                return data;
            }
        }

        public async Task<IEnumerable<OfferedSubject>> FetchHandledSubjects(int instructor_id)
        {
            // add your code here ***Fetching Instructors***
            string qry = @"SELECT a.`offered_id`
                                , a.`subject_id`
                                , e.`subject`
                                , a.`course_id`
                                ,c.`course_title`
                                , a.`year_level`
                                ,a.`section`
                                ,b.`class`
                                ,b.`days`
                                ,b.`instructor_id`
                                ,CONCAT(d.`last_name`,', ',d.`first_name`,' ', LEFT(d.`middle_name`, 1)) instructor_name
                                , b.`room_id`
                                ,b.`time_in`
                                ,b.`time_out`
                            FROM tblofferedsubjects a
                            LEFT JOIN tblsubjectschedule b ON a.`offer_subject_id` = b.`offer_subject_id` AND b.`school_year_id` = a.`school_year_id` AND b.`semester_id` = a.`semester_id`
                            JOIN tblcourses c ON a.`course_id` = c.`course_id`
                            JOIN tbl_instructor d ON b.`instructor_id` = d.`instructor_id`
                            JOIN tblsubjects e ON e.`subject_id` = a.`subject_id`
                            WHERE a.school_year_id = 22 AND a.semester_id = 1 AND b.instructor_id = 5
                            GROUP BY a.offered_id;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<OfferedSubject>(qry, new { instructor_id = instructor_id });
                return data;
            }
        }

        public async Task Create(Instructor data)
        {
            string qry = @"insert into tbl_instructor(designation, UserStatus, first_name, middle_name, last_name, institute_id) values(@designation, @UserStatus, @first_name, @middle_name, @last_name, @institute_id)";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var transaction = dbConnection.BeginTransaction();
                try
                {
                    await dbConnection.ExecuteAsync(qry, data);
                    transaction.Commit();
                }
                catch(Exception ex)
                 {
                     transaction.Rollback();
                 }
                
            }
        }
        public async Task Update(Instructor data)
        {
            string qry = @"update tbl_instructor set designation = @designation, UserStatus = @UserStatus, first_name = @first_name, middle_name = @middle_name, last_name = @last_name, institute_id = @institute_id where instructor_id = @instructor_id;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var transaction = dbConnection.BeginTransaction();
                try
                {
                    await dbConnection.ExecuteAsync(qry, data);
                    transaction.Commit();
                }
                catch(Exception ex)
                 {
                     transaction.Rollback();
                 }
                
            }
        }

        public async Task Delete(int instuctor_id)
        {
            string qry = @"delete from tbl_instructor where instructor_id = @instuctor_id;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var transaction = dbConnection.BeginTransaction();
                try
                {
                    await dbConnection.ExecuteAsync(qry, new { instuctor_id = instuctor_id} );
                    transaction.Commit();
                }
                catch(Exception ex)
                 {
                     transaction.Rollback();
                 }
                
            }
        }
    }
}