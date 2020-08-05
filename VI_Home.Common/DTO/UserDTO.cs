﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.Entities;

namespace VI_Home.Common.DTO
{
    public class UserDTO
    {
        
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
