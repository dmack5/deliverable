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
    public class PropertyOwnersController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<PropertyOwner> PropertyOwners_List()
        {
            using (var context = new Context())
            {
                return context.Propertyowners.ToList();
            }
        }



    }
}
