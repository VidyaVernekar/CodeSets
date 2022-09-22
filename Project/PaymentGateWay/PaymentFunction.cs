using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PaymentGateWay.Model;

namespace PaymentGateWay
{
    public static class PaymentFunction
    {
        [FunctionName("CreatePay")]
        public static async Task<IActionResult> CreatePay(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "pay")] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<CreatePaymentmodel>(requestBody);
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    if (!String.IsNullOrEmpty(input.EmailId))
                    {
                        var query = $"INSERT INTO dbo.[Purchase] (EmailId,BookId,PurchaseDate,PaymentMode) VALUES('{input.EmailId}', '{input.BookId}','{input.PurchaseDate}' ,'{input.PaymentMode}')";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
                return new BadRequestResult();
            }
            return new OkResult();
        }

        [FunctionName("GetPay")]
        public static async Task<IActionResult> GetPay(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "pay")] HttpRequest req, ILogger log)
        {
            List<Paymentmodel> PayList = new List<Paymentmodel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"Select * from dbo.Purchase";
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Paymentmodel pay = new Paymentmodel()
                        {
                            PurchaseId = (int)reader["PurchaseId"],
                            EmailId = reader["EmailId"].ToString(),
                            PurchaseDate = (DateTime)reader["PurchaseDate"],
                            PaymentMode = reader["PaymentMode"].ToString(),
                            BookId = (int)reader["BookId"]
                        };
                        PayList.Add(pay);
                    }
                }
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            if (PayList.Count > 0)
            {
                return new OkObjectResult(PayList);
            }
            else
            {
                return new NotFoundResult();
            }
        }

    }
}
