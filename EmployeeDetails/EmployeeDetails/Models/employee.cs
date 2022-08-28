using System.ComponentModel.DataAnnotations;
namespace EmployeeDetails.Models
{
    public class employee
    {
        [Key]
        public int employeeID { get; set; }
        public string employeeName { get; set; }

        public string employeeDesign { get; set; }

        public int Salary { get; set; }

    }
}
