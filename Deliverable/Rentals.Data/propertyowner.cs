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
    [Table("Propertowners")]
    public class PropertyOwner
    {
       
        [Key]
        public int landorlordID { get; set; }

        public string name { get; set; }

        public char ContactNumber { get; set; }

        public int ActiveContract { get; set; }
   

    }
}
