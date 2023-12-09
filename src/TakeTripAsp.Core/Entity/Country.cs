using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Country : BaseEntity<int>
    {
        public required string CountryName { get; set; }

        public virtual ICollection<City>? Cities { get; set; }
    }
}
