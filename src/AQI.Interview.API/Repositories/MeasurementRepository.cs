using System.Collections.Generic;
using AQI.Interview.Models;

namespace AQI.Interview.API.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private static readonly List<Measurement> _measurements = new List<Measurement>();

        public IEnumerable<Measurement> GetAll()
        {
            return _measurements;
        }

        public void Add(Measurement measurement)
        {
            _measurements.Add(measurement);
        }

        public bool Update(long id, Measurement measurement)
        {
            var existing = _measurements.FirstOrDefault(m => m.MeasurementId == id);
            if (existing == null) return false;
            existing.NumericValue = measurement.NumericValue;
            existing.StringValue = measurement.StringValue;
            existing.Precision = measurement.Precision;
            existing.Parameter = measurement.Parameter;
            existing.UTCCapturedTimestamp = measurement.UTCCapturedTimestamp;
            existing.UTCSavedTimestamp = measurement.UTCSavedTimestamp;
            return true;
        }

        public bool Delete(long id)
        {
            var existing = _measurements.FirstOrDefault(m => m.MeasurementId == id);
            if (existing == null) return false;
            _measurements.Remove(existing);
            return true;
        }
    }
}
