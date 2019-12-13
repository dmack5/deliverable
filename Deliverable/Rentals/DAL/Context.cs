using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using Rentals.Data;
#endregion

namespace Rentals.DAL
{
    internal class Context : DbContext
    {
        public Context() : base("StarTED")
        {

        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<PropertyOwner> Propertyowners { get; set; }
        public DbSet<Rental> Rentals { get; set; } 

        public DbSet<RentalType> RentalTypes {get; set;}
       
      

    }
}
