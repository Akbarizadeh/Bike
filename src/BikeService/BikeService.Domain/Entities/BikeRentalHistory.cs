
using System;

namespace BikeService.Domain.Entities
{
    public class BikeRentalHistory
    {
        public Guid Id { get; private set; }
        public Guid BikeId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime RentedAt { get; private set; }
        public DateTime? ReturnedAt { get; private set; }

        public BikeRentalHistory(Guid bikeId, Guid userId, DateTime rentedAt)
        {
            Id = Guid.NewGuid();
            BikeId = bikeId;
            UserId = userId;
            RentedAt = rentedAt;
        }

        public void MarkAsReturned()
        {
            ReturnedAt = DateTime.UtcNow;
        }
    }
}
