
using DAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VI_Home.Common.DTO;
using VI_Home.Common.Entities;

namespace DAL.EF
{
    public class ProductContext : IdentityDbContext<ApplicationUser>
    {
        public ProductContext() : base("DbConnection")
        { }
 
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<UserDTO> UserDTO { get; set; }



    }
}
