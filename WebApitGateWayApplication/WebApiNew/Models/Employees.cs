﻿using System.ComponentModel.DataAnnotations;

namespace WebApiNew.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }    

    }
}
