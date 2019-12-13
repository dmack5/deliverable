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
    public class Adress
    {

        [Key]
        public int AdressID { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }
        public string Community { get; set; }

        public string Unit { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string PostalCodeZip { get; set; }
        public char CountryCode { get; set; }
        public int LandlordID { get; set; }

        [NotMapped]

        public string FullAddress
        {
            get
            {
                return Number + " " + Street + " " + Unit;
            }
        }
        
    }
}