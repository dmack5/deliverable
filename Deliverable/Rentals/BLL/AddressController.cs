using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rentals.Data;
using Rentals.DAL;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Rentals.BLL
{
    [DataObject(true)]
    public class AddressController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]

        public List<Adress> Adress_List()
        {
            using( var context = new Context())
            {
                return context.Adresses.ToList();
            }
        }

        public List<Adress> Adresses_FindByLandLord(int landlordid)
        {
            using (var context = new Context())
            {
                IEnumerable<Adress> results =
                    context.Database.SqlQuery<Adress>("Rentals_FindByLandLord @landlordid"
                    , new SqlParameter("landlordid", landlordid));
                return results.ToList();
            }
        }


        public List<Adress> Addresses_FindByPartialStreetAddress(int number, string street)
        {
            using (var context = new Context())
            {
                IEnumerable<Adress> results =
                    context.Database.SqlQuery<Adress>("Adresses_FindByPartialStreetAddress @number @street"
                    , new SqlParameter("number", number)
                    , new SqlParameter("street", street));
                return results.ToList();

            }
        }
    }
}
