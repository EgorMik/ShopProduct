﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VI_Home.Common.Entities;

namespace VI_Home.Common.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}