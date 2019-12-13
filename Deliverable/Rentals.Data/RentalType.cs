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
    public class RentalType
    {
        
            [Key]
            public int RentalTypeID { get; set; }

              public string Description { get; set; }

    }
    }
