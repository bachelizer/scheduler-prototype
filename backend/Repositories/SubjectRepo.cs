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
    public class SubjectRepo : ISubject
    {
        private string connectionString;
        // private readonly StudentRepo _studentRepo;

        public SubjectRepo()
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

        public async Task<IEnumerable<OfferedSubject>> FetchOfferedSubjects()
        {
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
                                ,f.room
                            FROM tblofferedsubjects a
                            LEFT JOIN tblsubjectschedule b ON a.`offer_subject_id` = b.`offer_subject_id` AND b.`school_year_id` = a.`school_year_id` AND b.`semester_id` = a.`semester_id`
                            JOIN tblcourses c ON a.`course_id` = c.`course_id`
                            JOIN tbl_instructor d ON b.`instructor_id` = d.`instructor_id`
                            JOIN tblsubjects e ON e.`subject_id` = a.`subject_id`
                            LEFT JOIN tblrooms f ON b.`room_id` = f.`room_id`
                            WHERE a.school_year_id = 22 AND a.semester_id = 1;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<OfferedSubject>(qry);
                return data;
            }
        }

        public async Task<IEnumerable<OfferedSubject>> FetchLaboratorySubjects()
        {
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
                                ,f.room
                            FROM tblofferedsubjects a
                            LEFT JOIN tblsubjectschedule b ON a.`offer_subject_id` = b.`offer_subject_id` AND b.`school_year_id` = a.`school_year_id` AND b.`semester_id` = a.`semester_id`
                            JOIN tblcourses c ON a.`course_id` = c.`course_id`
                            JOIN tbl_instructor d ON b.`instructor_id` = d.`instructor_id`
                            JOIN tblsubjects e ON e.`subject_id` = a.`subject_id`
                            LEFT JOIN tblrooms f ON b.`room_id` = f.`room_id`
                            WHERE a.school_year_id = 22 AND a.semester_id = 1 AND e.laboratory_units > 0
                            GROUP BY a.offered_id;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<OfferedSubject>(qry);
                return data;
            }
        }
        public async Task<IEnumerable<OfferedSubject>> FetchLectureSubjects()
        {
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
                                ,f.room
                            FROM tblofferedsubjects a
                            LEFT JOIN tblsubjectschedule b ON a.`offer_subject_id` = b.`offer_subject_id` AND b.`school_year_id` = a.`school_year_id` AND b.`semester_id` = a.`semester_id`
                            JOIN tblcourses c ON a.`course_id` = c.`course_id`
                            JOIN tbl_instructor d ON b.`instructor_id` = d.`instructor_id`
                            JOIN tblsubjects e ON e.`subject_id` = a.`subject_id`
                            LEFT JOIN tblrooms f ON b.`room_id` = f.`room_id`
                            WHERE a.school_year_id = 22 AND a.semester_id = 1
                            GROUP BY a.offered_id;";
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var data = await dbConnection.QueryAsync<OfferedSubject>(qry);
                return data;
            }
        }

    }
}