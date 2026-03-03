using System.Collections.Generic;
using AQI.Interview.Models;

namespace AQI.Interview.API.Repositories
{
    public interface IMeasurementRepository
    {
        IEnumerable<Measurement> GetAll();
        void Add(Measurement measurement);
        bool Update(long id, Measurement measurement);
        bool Delete(long id);
    }
}
