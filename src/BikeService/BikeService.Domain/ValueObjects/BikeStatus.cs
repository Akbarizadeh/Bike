
namespace BikeService.Domain.ValueObjects
{
    public record BikeStatus
    {
        public static readonly BikeStatus Available = new("Available");
        public static readonly BikeStatus Rented = new("Rented");
        public static readonly BikeStatus InMaintenance = new("InMaintenance");

        public string Value { get; }

        private BikeStatus(string value) => Value = value;

        public override string ToString() => Value;
    }
}
