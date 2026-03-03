using AQI.Interview.Models;

namespace AQI.Interview.API.Validation
{
    public class MeasurementsValidator : IMeasurementsValidator
    {
        public string Validate(Measurement measurement)
        {
            if (measurement == null)
                return "Measurement is required.";
            if (string.IsNullOrWhiteSpace(measurement.StringValue))
                return "StringValue is required.";
            if (!Enum.IsDefined(typeof(Parameter), measurement.Parameter))
                return "Parameter type is invalid.";
            if (measurement.Precision < 0)
                return "Precision must be non-negative.";
            if (measurement.UTCCapturedTimestamp == default)
                return "UTCCapturedTimestamp is required.";
            return null;
        }
    }
}
