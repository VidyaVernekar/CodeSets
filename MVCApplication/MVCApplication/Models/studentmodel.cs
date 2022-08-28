using System.ComponentModel.DataAnnotations;
namespace MVCApplication.Models
{
    public class studentmodel
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string StudentSub { get; set; }
    }
}
