using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Reviews.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Reviews.Controllers
{
    //[Route("[controller]")]
    [Route("api/Reviews")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Reviews
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id as ""id"",CityFrom as ""CityFrom"", DateFrom as ""DateFrom"",CityTo as ""CityTo"",
DateTo as ""DateTo"",Comment as ""Comment"",Rate as ""Rate"",Clientid as ""Clientid"" from Reviews";
            // string query = @"SELECT * FROM ROUTE";

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

        // GET: api/ReviewsId
        [HttpGet("{ClientID}")]
        public JsonResult Get(string ClientID)
        {
            string query = @"select id as ""id"", CityFrom as ""CityFrom"", DateFrom as ""DateFrom"",CityTo as ""CityTo"",
DateTo as ""DateTo"",Comment as ""Comment"",Rate as ""Rate"",Clientid as ""Clientid"" from Reviews where ClientID=@ClientID";


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

            var reviewsDTOList = new List<TodoItemDTO>();

            foreach (DataRow row in table.Rows)
            {
                TodoItemDTO reviewsDTO = new TodoItemDTO();
                reviewsDTO.Id = (int)row.ItemArray[0];
                reviewsDTO.CityFrom = (string?)row.ItemArray[1];
                reviewsDTO.DateFrom = (DateTime?)row.ItemArray[2];
                reviewsDTO.CityTo = (string?)row.ItemArray[3];
                reviewsDTO.DateTo = (DateTime?)row.ItemArray[4];
                reviewsDTO.Comment = (string?)row.ItemArray[5];
                reviewsDTO.Rate = (int?)row.ItemArray[6];
                reviewsDTO.Name = (string?)json[0]["name"];
                reviewsDTO.Surname = (string?)json[0]["surname"];
                reviewsDTO.Lastname = (string?)json[0]["lastname"];
                reviewsDTO.Dateborn = (DateTime?)json[0]["dateborn"];
                reviewsDTO.Number = (string?)json[0]["number"];
                reviewsDTO.Pasport = (string?)json[0]["pasport"];
                reviewsDTOList.Add(reviewsDTO);
            }
            return new JsonResult(reviewsDTOList);
        }

        // PUT: api/ReviewsId
        [HttpPut("{id}")]
        public JsonResult Put(Models.Reviews dep)
        {
            string query = @"update Reviews set cityfrom=@cityfrom, datefrom=@datefrom,cityto=@cityto,dateto=@dateto,
comment=@comment,rate=@rate,clientid=@clientid where id=@id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@cityfrom", dep.CityFrom);
                    myCommand.Parameters.AddWithValue("@datefrom", dep.DateFrom);
                    myCommand.Parameters.AddWithValue("@cityto", dep.CityTo);
                    myCommand.Parameters.AddWithValue("@dateto", dep.DateTo);
                    myCommand.Parameters.AddWithValue("@comment", dep.Comment);
                    myCommand.Parameters.AddWithValue("@rate", dep.Rate);
                    myCommand.Parameters.AddWithValue("@clientid", dep.ClientId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Reviews
        [HttpPost]
        public JsonResult Post(Models.Reviews dep)
        {
            string query = @"insert into Reviews (cityfrom,datefrom,cityto,dateto,comment,rate,clientid)
                values (@cityfrom,@datefrom,@cityto,@dateto,@comment,@rate,@clientid)";
            //,pointofdeparture,pointofarrivale,price  ,@pointofdeparture,@pointofarrivale,@price

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@cityfrom", dep.CityFrom);
                    myCommand.Parameters.AddWithValue("@datefrom", dep.DateFrom);
                    myCommand.Parameters.AddWithValue("@cityto", dep.CityTo);
                    myCommand.Parameters.AddWithValue("@dateto", dep.DateTo);
                    myCommand.Parameters.AddWithValue("@comment", dep.Comment);
                    myCommand.Parameters.AddWithValue("@rate", dep.Rate);
                    myCommand.Parameters.AddWithValue("@clientid", dep.ClientId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Reviews
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Reviews where id=@id";

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
