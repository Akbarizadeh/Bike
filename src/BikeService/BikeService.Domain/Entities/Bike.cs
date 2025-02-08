using BikeService.Domain.ValueObjects;
using MsftFramework.Core.Domain.Model;

namespace BikeService.Domain.Entities
{
    public class Bike : Aggregate<Guid>
    {
        public string SerialNumber { get; private set; }
        public BikeStatus Status { get; private set; }
        public BikeLocation Location { get; private set; }
        private readonly List<BikeRentalHistory> _rentalHistory = new();

        public IReadOnlyCollection<BikeRentalHistory> RentalHistory => _rentalHistory.AsReadOnly();

        private Bike() { } // برای ORM

        public Bike(string serialNumber, BikeLocation location)
        {
            Id = Guid.NewGuid();
            SerialNumber = serialNumber;
            Status = BikeStatus.Available;
            Location = location;
        }

        public void Rent(Guid userId)
        {
            if (Status != BikeStatus.Available)
                throw new InvalidOperationException("Bike is not available for rent.");

            Status = BikeStatus.Rented;
            _rentalHistory.Add(new BikeRentalHistory(Id, userId, DateTime.UtcNow));

            AddDomainEvent(new BikeRentedDomainEvent(Id, userId, DateTime.UtcNow));
        }

        public void ReturnBike()
        {
            if (Status != BikeStatus.Rented)
                throw new InvalidOperationException("Bike is not currently rented.");

            Status = BikeStatus.Available;

            AddDomainEvent(new BikeReturnedDomainEvent(Id, DateTime.UtcNow));
        }

        public void SendForMaintenance()
        {
            if (Status == BikeStatus.InMaintenance)
                throw new InvalidOperationException("Bike is already in maintenance.");

            Status = BikeStatus.InMaintenance;

            AddDomainEvent(new BikeSentForMaintenanceDomainEvent(Id, DateTime.UtcNow));
        }
    }

}
