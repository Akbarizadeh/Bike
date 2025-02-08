# 🚲 Bike Rental Service

## Overview
The **Bike Rental Service** is a microservice-based application designed using **Clean Architecture** and **Domain-Driven Design (DDD)**. It ensures scalability, maintainability, and clear separation of concerns. The service manages bike rentals, availability, and status tracking while following best software design principles.

## 📌 Features
- **Bike Management**: Add, update, and track the status of bikes.
- **Rental Management**: Rent and return bikes with controlled state transitions.
- **CQRS (Command Query Responsibility Segregation)**: Separating read and write operations for better performance.
- **Event-Driven Architecture**: Services communicate asynchronously via domain events.
- **Extensible Infrastructure**: Easily replaceable database and messaging implementations.

## 🏗 Architecture
This project follows **Clean Architecture**, ensuring each layer has a well-defined responsibility:

### 1️⃣ **Domain Layer**
- Contains business logic, entities, and domain events.
- Example:
```csharp
  public class Bike: Aggregate<Guid>
  {
      public string SerialNumber { get; private set; }
      public BikeStatus Status { get; private set; }
      public BikeLocation Location { get; private set; }
      private readonly List<BikeRentalHistory> _rentalHistory = new();

      public IReadOnlyCollection<BikeRentalHistory> RentalHistory => _rentalHistory.AsReadOnly();

      private Bike() { } 

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
```

### 2️⃣ **Application Layer**
- Implements use cases with **CQRS** (Commands & Queries).
- Example:
```csharp
 public class CreateBikeCommandHandler: IRequestHandler<CreateBikeCommand, FluentResults.Result<CreateBikeResult>>
 {
     public async Task<FluentResults.Result<CreateBikeResult>> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
     {
         var bike = new Bike(request.SerialNumber, new BikeLocation(request.Latitude, request.Longitude));
         return await Task.FromResult(new CreateBikeResult(bike.Id, bike.SerialNumber ));
     }
 }
```

### 3️⃣ **Infrastructure Layer**
- Handles database operations, external services, and messaging.

### 4️⃣ **API Layer**
- Provides RESTful APIs for interacting with the system.

## 🚀 Getting Started
### Prerequisites
- .NET 8.0
- SQL Server or PostgreSQL
- Docker (optional for containerized deployment)

### Installation
1. **Clone the Repository**
```bash
git clone https://github.com/yourusername/bike-rental-service.git
cd bike-rental-service
```

2. **Install Dependencies**
```bash
dotnet restore
```

3. **Set Up Database**
- Update `appsettings.json` with your database connection string.
- Run migrations:
```bash
dotnet ef database update
```

4. **Run the Application**
```bash
dotnet run --project src/BikeRental.Api
```

## 🛠 API Endpoints
### 🔹 Bike Management
- **GET** `/api/bikes` → Get all bikes
- **POST** `/api/bikes` → Add a new bike
- **PUT** `/api/bikes/{id}/status` → Change bike status

### 🔹 Rental Operations
- **POST** `/api/rentals/{bikeId}` → Rent a bike
- **POST** `/api/returns/{bikeId}` → Return a bike

## 🏗 Event-Driven Communication
The system uses **Domain Events** to notify other services asynchronously.

Example:
```csharp
public class BikeRentedEvent : IDomainEvent
{
    public Guid BikeId { get; }
    public BikeRentedEvent(Guid bikeId) => BikeId = bikeId;
}
```

## 🤝 Contribution Guidelines
1. **Fork the repository**
2. **Create a feature branch**
3. **Commit your changes**
4. **Push the branch and create a PR**

## 📜 License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📧 Contact
For any questions, feel free to reach out at **akbarizadeh57@gmail.com**.
