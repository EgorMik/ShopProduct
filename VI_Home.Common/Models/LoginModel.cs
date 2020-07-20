﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VI_Home.Common.Models
{
    public class LoginModel
    {
       
        public string Email { get; set; }
       
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}