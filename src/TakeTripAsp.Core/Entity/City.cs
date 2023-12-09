using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class City : BaseEntity<int>
    {
        public required string CityName { get; set; }

        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public virtual ICollection<Tour>? Tours { get; set; }
    }
}
