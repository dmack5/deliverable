using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additonal namespaces 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Rentals.Data
{
    [Table("Addresses")]
    public class Rental
    {
   
   
        

            [Key]
            public int RentalID { get; set; }

            public int AddressID { get; set; }

            public int RentalTypeID { get; set; }
            public double MonthlyRent { get; set; }

            public int Vancancies { get; set; }
            public int MaxVacancy { get; set; }
            public double DamageDeposit{ get; set; }
            public DateTime AvailableDate { get; set; }
            public DateTime LastModified { get; set; }



    }

  }


