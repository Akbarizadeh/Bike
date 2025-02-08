public record CreateBikeRequest(
    string Name,
    string SerialNumber,
    decimal Latitude,
    decimal Longitude
);

public record RentBikeRequest(
    string Name,
    string SerialNumber,
    decimal Latitude,
    decimal Longitude
);
