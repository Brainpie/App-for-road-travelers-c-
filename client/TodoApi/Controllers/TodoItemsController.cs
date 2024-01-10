using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Client.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;



namespace Client.Controllers
{
    //[Route("[controller]")]
    [Route("api/Client")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Client
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id as ""id"", name as ""name"",surname as ""surname"",lastname as ""lastname"",
dateborn as ""dateborn"",number as ""number"",pasport as ""pasport"",login as ""login"", password as ""password"" from Client";


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

        // GET: api/Client
        [HttpGet("{login}")]
        public JsonResult Get(string login)
        {
            string query = @"select id as ""id"", name as ""name"",surname as ""surname"",lastname as ""lastname"",
                           dateborn as ""dateborn"",number as ""number"",pasport as ""pasport"", login as ""login"", 
                           password as ""password"" from Client where login=@login";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@login", login);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult(table);
        }

        // PUT: api/Client
        [HttpPut("{id}")]
        public JsonResult Put(Models.Client dep)
        {
            string query = @"update Client set name=@name,surname=@surname,lastname=@lastname,dateborn=@dateborn,
number=@number,pasport=@pasport,login=@login,password=@password where login=@login";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@name", dep.Name);
                    myCommand.Parameters.AddWithValue("@surname", dep.Surname);
                    myCommand.Parameters.AddWithValue("@lastname", dep.Lastname);
                    myCommand.Parameters.AddWithValue("@dateborn", dep.Dateborn);
                    myCommand.Parameters.AddWithValue("@number", dep.Number);
                    myCommand.Parameters.AddWithValue("@pasport", dep.Pasport);
                    myCommand.Parameters.AddWithValue("@login", dep.Login);
                    myCommand.Parameters.AddWithValue("@password", dep.Password);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Client
        [HttpPost]
        public JsonResult Post(Models.Client dep)
        {
            string query = @"
                insert into Client(name,surname,lastname,dateborn,number,pasport,password,login)
                values (@name,@surname,@lastname,@dateborn,@number,@pasport,@password,@login)";
            //,pointofdeparture,pointofarrivale,price  ,@pointofdeparture,@pointofarrivale,@price

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@name", dep.Name);
                    myCommand.Parameters.AddWithValue("@surname", dep.Surname);
                    myCommand.Parameters.AddWithValue("@lastname", dep.Lastname);
                    myCommand.Parameters.AddWithValue("@dateborn", dep.Dateborn);
                    myCommand.Parameters.AddWithValue("@number", dep.Number);
                    myCommand.Parameters.AddWithValue("@pasport", dep.Pasport);
                    myCommand.Parameters.AddWithValue("@password", dep.Password);
                    myCommand.Parameters.AddWithValue("@login", dep.Login);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Client
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from Client where id=@id";

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
