using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Text;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Data;
using System.Data.SqlClient;
using WebApiForAzure.Model;

namespace WebApiForAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string name)
        {
            var Url = "https://firstazurehttpfunction.azurewebsites.net/api/FirstAzureFunctionHttpTrigger1?code=Pzmx5S8_Cj8ihWqbLBrQdX7GDm4sAg1nOqfELcqrKIbxAzFuY8o4NQ==";

            dynamic content = new { name = name };
            var msg = PostName(name);
            var json = JsonConvert.SerializeObject(content); 
            var data = new StringContent(json, Encoding.UTF8, "application/json"); using (var client = new HttpClient())
            {
                var response = await client.PostAsync(Url, data);

                var result = await response.Content.ReadAsStringAsync() + " " + msg;

                return Ok(result);

            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<NameList> taskList = new List<NameList>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("conn")))
                {
                    connection.Open();
                    var query = @"Select * from dbo.NameList";
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        //bc_wallet_220901_u2ypt7boei@BuilderCloudProvisioning.onmicrosoft.com
                        //kEqZdimS!

                        NameList name = new NameList()
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                        };
                        taskList.Add(name);
                    }
                }
            }
            catch (Exception e)
            {
            }
            if (taskList.Count > 0)
            {
                return new OkObjectResult(taskList);
            }
            else
            {
                return new NotFoundResult();
            }
        }
        public static async Task<IActionResult> PostName(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    if (String.IsNullOrEmpty(name))
                    {
                        var query = $"INSERT INTO [dbo].[NameList] (name) VALUES('{name}')";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
            return new OkResult();
        }
    }
}