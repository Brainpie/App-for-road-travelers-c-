using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Grades.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Grades.Controllers
{
    //[Route("[controller]")]
    [Route("api/Grades")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Grades
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id as ""id"", Place as ""Place"",Rate as ""Rate"",
                           CityFrom as ""CityFrom"", DateFrom as ""DateFrom"",CityTo as ""CityTo"",
                           DateTo as ""DateTo"" from GradePlace";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        // GET: api/GradesId
        [HttpGet("{ClientID}")]
        public JsonResult Get(string ClientID)
        {
            string query = @"select id as ""id"", Place as ""Place"",Rate as ""Rate"",CityFrom as ""CityFrom"", 
DateFrom as ""DateFrom"",CityTo as ""CityTo"",DateTo as ""DateTo"" from GradePlace where ClientID=@ClientID";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ClientID", ClientID);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            var client = new RestClient("https://localhost:7122/api/Client");
            var request = new RestRequest($"{ClientID}");
            RestResponse response = client.Execute(request);

            var jsonText = response.Content.ToString();
            var json = JArray.Parse(jsonText);

            var gradesDTOList = new List<TodoItemDTO>();

            foreach (DataRow row in table.Rows)
            {
                TodoItemDTO gradesDTO = new TodoItemDTO();
                gradesDTO.Place = (string?)row.ItemArray[1];
                gradesDTO.Rate = (int?)row.ItemArray[2];
                gradesDTO.Data1 = (DateTime?)row.ItemArray[4];
                gradesDTO.NameC1 = (string?)row.ItemArray[3];
                gradesDTO.Data2 = (DateTime?)row.ItemArray[6];
                gradesDTO.NameC2 = (string?)row.ItemArray[5];
                gradesDTO.Name = (string?)json[0]["name"];
                gradesDTO.Surname = (string?)json[0]["surname"];
                gradesDTO.Lastname = (string?)json[0]["lastname"];
                gradesDTOList.Add(gradesDTO);
            }
            return new JsonResult(gradesDTOList);
        }

        // PUT: api/GradesId
        [HttpPut("{id}")]
        public JsonResult Put(Models.Grades dep)
        {
            string query = @"update GradePlace set title=@title,rate=@rate,reviewid=@reviewid where id=@id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@place", dep.Place);
                    myCommand.Parameters.AddWithValue("@rate", dep.Rate);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Grades
        [HttpPost]
        public JsonResult Post(Models.Grades dep)
        {
            string query = @"insert into GradePlace(place,rate,cityfrom,datefrom,cityto,dateto,clientid)
                values (@place,@rate,@cityfrom,@datefrom,@cityto,@dateto,@clientid)";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@place", dep.Place);
                    myCommand.Parameters.AddWithValue("@rate", dep.Rate);
                    myCommand.Parameters.AddWithValue("@cityfrom", dep.CityFrom);
                    myCommand.Parameters.AddWithValue("@datefrom", dep.DateFrom);
                    myCommand.Parameters.AddWithValue("@cityto", dep.CityTo);
                    myCommand.Parameters.AddWithValue("@dateto", dep.DateTo);
                    myCommand.Parameters.AddWithValue("@clientid", dep.ClientId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Grades
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from GradePlace where id=@id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
