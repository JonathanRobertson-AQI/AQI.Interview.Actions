using Microsoft.AspNetCore.Mvc;
using AQI.Interview.Models;
using System.Collections.Generic;
using System.Linq;

namespace AQI.Interview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {

        private readonly AQI.Interview.API.Repositories.IMeasurementRepository _repository;
        private readonly AQI.Interview.API.Validation.IMeasurementsValidator _validator;

        public MeasurementsController(
            AQI.Interview.API.Repositories.IMeasurementRepository repository,
            AQI.Interview.API.Validation.IMeasurementsValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Measurement>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]


        public ActionResult<Measurement> Post([FromBody] Measurement measurement)
        {
            var error = _validator.Validate(measurement);
            if (error != null)
                return BadRequest(error);
            _repository.Add(measurement);
            return CreatedAtAction(nameof(Get), new { id = measurement.MeasurementId }, measurement);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Measurement measurement)
        {
            var error = _validator.Validate(measurement);
            if (error != null)
                return BadRequest(error);
            var updated = _repository.Update(id, measurement);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleted = _repository.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
