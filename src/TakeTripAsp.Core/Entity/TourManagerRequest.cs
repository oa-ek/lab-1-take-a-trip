using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Core.Entity
{
    public class TourManagerRequest: BaseEntity
    {
        public virtual AppUser? Client { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public DateTime RequestDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsCompanyMember { get; set; }

        public bool IsSeller { get; set; }
    }
}
