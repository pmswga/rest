using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using ContactsRestAPI.Models;
using Newtonsoft.Json;

namespace ContactsRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                SELECT idPerson, 
                       secondName, 
                       firstName, 
                       patronymic, 
                       email, 
                       telephone, 
                       idTag
                FROM dbo.Person
                ORDER BY secondName, firstName, patronymic
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
        public JsonResult Post(Person person)
        {
            string query = @"
                INSERT INTO dbo.Person
                VALUES (@SecondName, @FirstName, @Patronymic, @Email, @Telephone, @IdTag)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SecondName", person.SecondName);
                    myCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
                    myCommand.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                    myCommand.Parameters.AddWithValue("@Email", person.Email);
                    myCommand.Parameters.AddWithValue("@Telephone", person.Telephone);
                    myCommand.Parameters.AddWithValue("@IdTag", person.IdTag);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("New contact added successfully");
        }

        [HttpPut]
        public JsonResult Put(Person person)
        {
            string query = @"
                UPDATE dbo.Person
                SET
                    secondName = @SecondName,
                    firstName  = @FirstName,
                    patronymic = @Patronymic,
                    email      = @Email,
                    telephone  = @Telephone,
                    idTag      = @IdTag
                WHERE idPerson = @IdPerson
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdPerson", person.IdPerson);
                    myCommand.Parameters.AddWithValue("@SecondName", person.SecondName);
                    myCommand.Parameters.AddWithValue("@FirstName", person.FirstName);
                    myCommand.Parameters.AddWithValue("@Patronymic", person.Patronymic);
                    myCommand.Parameters.AddWithValue("@Email", person.Email);
                    myCommand.Parameters.AddWithValue("@Telephone", person.Telephone);
                    myCommand.Parameters.AddWithValue("@IdTag", person.IdTag);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Contact updated successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                DELETE from dbo.Person
                WHERE idPerson=@IdPerson
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ContactsCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdPerson", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Contact deleted successfully");
        }


    }
}
