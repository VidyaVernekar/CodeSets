using Microsoft.AspNetCore.Mvc;

namespace WebApiFunction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static List<Employee> employees = new List<Employee>();

        [HttpPost]
        public IActionResult Post(int empNo, string empName)
        {
            // Add new record
            employees.Add(new Employee
            {
                EmpNo = empNo,
                EmpName = empName
            });
            return Ok("Added");
        }

        [HttpPost]
        [Route("AddEmp")]
        public IActionResult Post([FromBody] Employee emp)
        {
            // Add new record
            employees.Add(emp);
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Put(int empNo, string empName)
        {
            try
            {
                if (employees.Exists(x => x.EmpNo == empNo && x.EmpName.Contains(empName)))
                {
                    employees.Find(emp => emp.EmpNo.Equals(empNo)).EmpName = empName;
                    return Ok("Modified");
                }
                else
                {
                    return Ok("The List not present Employee");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int empNo, string empName)
        {
            try
            {
                if (employees.Exists(x => x.EmpNo == empNo && x.EmpName.Contains(empName)))
                {
                    employees.Remove(employees.Find(emp => emp.EmpNo.Equals(empNo)));
                    return Ok("Removed");
                }
                else
                {
                    return Ok("The List not present Employee}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }


        //[HttpGet]
        //public string GetTime()
        //{
        //    return DateTime.Now.ToString();
        //}
        [HttpGet]
        [Route("AddNumbers")]
        public string Add(int a,int b)
        {
            return (a+b).ToString();
        }
        [HttpGet]
        [Route("SubNumbers")]
        public string Sub(int a, int b)
        {
            return (a - b).ToString();
        }
        [HttpGet]
        [Route("divNumbers")]
        public string Div(int a, int b)
        {
            return (a / b).ToString();
        }
        [HttpGet]
        [Route("MulNumbers")]
        public string Multi(int a, int b)
        {
            return (a * b).ToString();
        }
    }
}
    #region
    //private static readonly string[] Summaries = new[]
    //    {
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet(Name = "GetWeatherForecast")]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
#endregion