using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ContactsRestAPI.Models;
using Newtonsoft.Json;

namespace ContactsRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public TagController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                SELECT idTag, caption
                FROM dbo.Tag
                ORDER BY caption
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");

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

            return new JsonResult(JsonConvert.SerializeObject(table));
        }


        [HttpPost]
        public JsonResult Post(Tag tag)
        {
            string query = @"
                INSERT INTO dbo.Tag
                VALUES (@Caption)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Caption", tag.Caption);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("New tag added successfully");
        }

        [HttpPut]
        public JsonResult Put(Tag tag)
        {
            string query = @"
                UPDATE dbo.Tag
                SET
                    caption = @Caption
                WHERE idTag = @IdTag
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdTag", tag.IdTag);
                    myCommand.Parameters.AddWithValue("@Caption", tag.Caption);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Tag updated successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                DELETE from dbo.Tag
                WHERE idTag=@IdTag
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdTag", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Tag deleted successfully");
        }

    }
}
