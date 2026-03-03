using AQI.Interview.Models;

namespace AQI.Interview.API.Validation
{
    public interface IMeasurementsValidator
    {
        string Validate(Measurement measurement);
    }
}
