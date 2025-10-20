namespace SafeBoda.Core
{

    public record Location(double Latitude, double Longitude);

    public class Rider
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber{ get; set; }="";
    }

    public class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string MotoPlateNumber { get; set; } = "";
    }

    public class Trip
    {
        public Guid Id{ get; set; }
        public Guid RiderId { get; set; }
        public Rider? Rider { get; set; }

        public Guid DriverId { get; set; }
        public Driver? Driver { get; set; }

        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }

        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }

        public decimal Fare { get; set; }
        public DateTime RequestTime { get; set; }
    }
}