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
    [DataObject]
    public class RentalController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]

        public List<Rental> Rental_List()
        {
            using (var context = new Context())
            {
                return context.Rentals.ToList();
            }
        }

        public List<Rental> Rentals_FindByLandLord(int landlordid)
        {
            using (var context = new Context())
            {
                IEnumerable<Rental> results = 
                    context.Database.SqlQuery<Rental>("Rentals_FindByLandLord @landlordid"
                    , new SqlParameter("landlordid", landlordid));
                return results.ToList();

            }
        }

        public List<Rental> Rentals_FindByMonthlyRateRange(int minrange, int maxrange)
        {
            using (var context = new Context())
            {
                IEnumerable<Rental> results =
                    context.Database.SqlQuery<Rental>("Rentals_FindByMonthlyRateRange @minrange @maxrange"
                    , new SqlParameter("minrange", minrange)
                    , new SqlParameter("maxrange", maxrange));
                return results.ToList();
            }
        }

        
    }
}
