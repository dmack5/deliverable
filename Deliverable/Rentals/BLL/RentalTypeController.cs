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
    public class RentalTypeController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<RentalType> RentalType_List()
        {
            using (var context = new Context())
            {
                return context.RentalTypes.ToList();
            }
        }


    }
}
