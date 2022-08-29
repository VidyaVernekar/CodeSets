﻿using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }    

    }
}
