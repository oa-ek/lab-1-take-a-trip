using System.ComponentModel.DataAnnotations.Schema;
using TakeTripAsp.Domain.Common;

namespace TakeTripAsp.Domain.Entity
{
    public class Reviews : BaseEntity<int>
    {
        public required string Comment { get; set; }

        public virtual AppUser? Client { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public int TourId { get; set; }

        public virtual Tour? Tour { get; set; }
    }
}