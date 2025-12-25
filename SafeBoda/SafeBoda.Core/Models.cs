namespace SafeBoda.Core
{

    public record Location(double Latitude, double Longitude);

    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber{ get; set; }="";
    }

    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string MotoPlateNumber { get; set; } = "";
    }

    public class Trip
    {
        public int Id{ get; set; }
        public int RiderId { get; set; }
        public Rider? Rider { get; set; }

        public int DriverId { get; set; }
        public Driver? Driver { get; set; }

        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }

        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }

        public decimal Fare { get; set; }
        public DateTime RequestTime { get; set; }
    }
}