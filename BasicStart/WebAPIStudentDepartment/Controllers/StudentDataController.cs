using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPIStudentDepartment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/xml")]
    public class StudentDataController : ControllerBase
    {
        public static List<Students> stud = new List<Students>();
        public static List<Department> dept = new List<Department>();
        [HttpPost]
        [Route("AddDepartment")]
        public IActionResult Post(int ID, string Name)
        {
            // Add new record
            bool IsExist = dept.Count > 0 && dept.Exists(x => x.deptID.Equals(ID));
            if(IsExist)
            {
                return BadRequest("Already Exist");
            }
            try
            {
                dept.Add(new Department
                {
                    deptID = ID,
                    departmentName = Name
                });
                return Ok("Added");
            }
            catch
            {
                return BadRequest("Already Exists");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public IActionResult UpdateDepartment(int ID, string Name)
        {
            // Add new record
            bool IsExist = dept.Count > 0 && dept.Exists(x => x.deptID.Equals(ID));
            if (!IsExist)
            {
                return BadRequest("No Department found");
            }
            try
            {
                dept.Find(d => d.deptID.Equals(ID)).departmentName = Name;
                return Ok("Updated");
            }
            catch
            {
                return BadRequest("No department found");
            }
        }
        [HttpPost]
        [Route("Addstudent")]

        public IActionResult Post(int ID, string Name, int deptID)
        {
            // Add new record
            bool IsStudentExist = (stud.Count > 0 && stud.Exists(x => x.studentID.Equals(ID))) ? false : true;
            bool IsExist = dept.Count > 0 && dept.Exists(x => x.deptID.Equals(deptID));
            if (!IsExist || ! IsStudentExist)
            {
                return BadRequest("Exists Student / No Department found");
            }
            try
            {
                stud.Add(new Students
                {
                    studentID = ID,
                    studentName = Name,
                    departmentID = deptID
                });
                return Ok("Added");
            }
            catch
            {
                return BadRequest("Add department");
            }
        }

        

        [HttpPut]
        [Route("UPdateStudent")]

        public IActionResult Put(int ID, string Name, int deptID)
        {
            bool IsExist = dept.Count > 0 && dept.Exists(x => x.deptID.Equals(deptID));
            if (!IsExist || !stud.Exists(x => x.studentID == ID))
            {
                return BadRequest("Not Exists");
            }
            try
            {
               stud.Find(emp => emp.studentID.Equals(ID)).studentName = Name;
               stud.Find(emp => emp.studentID.Equals(ID)).departmentID = deptID;
               return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletStudent")]

        public IActionResult Delete(int ID, string Name)
        {
            bool IsExist = stud.Count > 0 && stud.Exists(x => x.studentID.Equals(ID));
            if (!IsExist)
            {
                return BadRequest("Not Exists");
            }
            try
            {
                stud.Remove(stud.Find(emp => emp.studentID.Equals(ID)));
                return Ok("Removed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(stud);
        }
        [HttpGet]
        [Route("Getdepartment")]
        public IActionResult Getdepartment()
        {
            return Ok(dept);
        }
    }
}