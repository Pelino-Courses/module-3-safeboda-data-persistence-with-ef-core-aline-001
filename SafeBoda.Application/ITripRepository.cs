using System.Collections;
namespace SafeBoda.Application
{
    public interface ITripRepository
    {
        public IEnumerable GetActiveTrips();
    }
}