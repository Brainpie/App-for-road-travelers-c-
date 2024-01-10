using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Tiket.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Tiket.Controllers
{
    //[Route("[controller]")]
    [Route("api/Tiket")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Tiket
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id as ""id"", Data1 as ""Data1"",CityId1 as ""CityId1"",Data2 as ""Data2"",
CityId2 as ""CityId2"",Price as ""Price"",Typetransport as ""Typetransport"",LoginClient as ""LoginClient"" from Tiket";
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

        // GET: api/TiketId
       [HttpGet("{LoginClient}")]
        public JsonResult Get(string LoginClient)
        {
            string query = @"select id as ""id"", Data1 as ""Data1"",CityId1 as ""CityId1"",CityName1 as ""CityName1"",Data2 as ""Data2"",
CityId2 as ""CityId2"",CityName2 as ""CityName2"",Price as ""Price"",Typetransport as ""Typetransport"",LoginClient as ""LoginClient""
from Tiket where LoginClient=@LoginClient";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@LoginClient", LoginClient);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            var client = new RestClient("https://localhost:7122/api/Client");
            var request = new RestRequest($"{LoginClient}");
            RestResponse response = client.Execute(request);

           /* var client1 = new RestClient("https://localhost:7123/api/City");
            var request1 = new RestRequest($"{table.Rows[0].ItemArray[2]}");
            RestResponse response1 = client1.Execute(request1);
            var request2 = new RestRequest($"{table.Rows[0].ItemArray[4]}");
            RestResponse response2 = client1.Execute(request2);*/

            var jsonText = response.Content.ToString();
            var json = JArray.Parse(jsonText);
            /* var jsonText1 = response1.Content.ToString();
             var json1 = JArray.Parse(jsonText1);
             var jsonText2 = response2.Content.ToString();
             var json2 = JArray.Parse(jsonText2);*/

            var tiketDTOList = new List<TiketDTO>();
            
            foreach (DataRow row in table.Rows)
            {

                /*tiketDTO.Data1 = (DateTime?)table.Rows[0].ItemArray[1];
                tiketDTO.NameC1 = (string?)table.Rows[0].ItemArray[3];
                tiketDTO.Data2 = (DateTime?)table.Rows[0].ItemArray[4];
                tiketDTO.NameC2 = (string?)table.Rows[0].ItemArray[6];
                tiketDTO.Price = (int?)table.Rows[0].ItemArray[7];
                tiketDTO.Typetransport = (string?)table.Rows[0].ItemArray[8];
                tiketDTO.Name = (string?)json[0]["name"];
                tiketDTO.Surname = (string?)json[0]["surname"];
                tiketDTO.Lastname = (string?)json[0]["lastname"];
                tiketDTO.Dateborn = (DateTime?)json[0]["dateborn"];
                tiketDTO.Number = (string?)json[0]["number"];
                tiketDTO.Pasport = (string?)json[0]["pasport"];*/

                TiketDTO tiketDTO = new TiketDTO();
                tiketDTO.Data1 = (DateTime?)row.ItemArray[1];
                tiketDTO.NameC1 = (string?)row.ItemArray[3];
                tiketDTO.Data2 = (DateTime?)row.ItemArray[4];
                tiketDTO.NameC2 = (string?)row.ItemArray[6];
                tiketDTO.Price = (int?)row.ItemArray[7];
                tiketDTO.Typetransport = (string?)row.ItemArray[8];
                tiketDTO.Name = (string?)json[0]["name"];
                tiketDTO.Surname = (string?)json[0]["surname"];
                tiketDTO.Lastname = (string?)json[0]["lastname"];
                tiketDTO.Dateborn = (DateTime?)json[0]["dateborn"];
                tiketDTO.Number = (string?)json[0]["number"];
                tiketDTO.Pasport = (string?)json[0]["pasport"];
                tiketDTOList.Add(tiketDTO);
            }

                return new JsonResult(tiketDTOList);
            
        }

        // PUT: api/TiketId
        [HttpPut("{id}")]
        public JsonResult Put(Models.Tiket dep)
        {
            string query = @"update Tiket set data1=@data1,cityid1=@cityid1,data2=@data2,cityid2=@cityid2,price=@price,
                           typetransport=@typetransport,loginClient=@loginClient where id=@id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@id", dep.Id);
                    myCommand.Parameters.AddWithValue("@data1", dep.Data1);
                    myCommand.Parameters.AddWithValue("@cityid1", dep.CityId1);
                    myCommand.Parameters.AddWithValue("@data2", dep.Data2);
                    myCommand.Parameters.AddWithValue("@cityid2", dep.CityId2);
                    myCommand.Parameters.AddWithValue("@price", dep.Price);
                    myCommand.Parameters.AddWithValue("@typetransport", dep.Typetransport);
                    myCommand.Parameters.AddWithValue("@loginClient", dep.LoginClient);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Tiket
        [HttpPost]
        public JsonResult Post(Models.Tiket dep)
        {
            string query = @"insert into tiket(data1,cityid1,cityname1,data2,cityid2,cityname2,price,typetransport,loginClient)
                values (@data1,@cityid1,@cityname1,@data2,@cityid2,@cityname2,@price,@typetransport,@loginClient)";
            //,pointofdeparture,pointofarrivale,price  ,@pointofdeparture,@pointofarrivale,@price

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TravelAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@data1", dep.Data1);
                    myCommand.Parameters.AddWithValue("@cityid1", dep.CityId1);
                    myCommand.Parameters.AddWithValue("@cityname1", dep.CityName1);
                    myCommand.Parameters.AddWithValue("@data2", dep.Data2);
                    myCommand.Parameters.AddWithValue("@cityid2", dep.CityId2);
                    myCommand.Parameters.AddWithValue("@cityname2", dep.CityName2);
                    myCommand.Parameters.AddWithValue("@price", dep.Price);
                    myCommand.Parameters.AddWithValue("@typetransport", dep.Typetransport);
                    myCommand.Parameters.AddWithValue("@loginClient", dep.LoginClient);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Added Successfully");
        }

        // DELETE: api/Tiket
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from tiket where id=@id";

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
