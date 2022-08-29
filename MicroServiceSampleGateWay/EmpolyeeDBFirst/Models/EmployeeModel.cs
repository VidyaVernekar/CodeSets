using System.ComponentModel.DataAnnotations;

namespace EmpolyeeDBFirst.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Adress { get; set; }

    }
}
