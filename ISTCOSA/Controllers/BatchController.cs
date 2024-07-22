using ISTCOSA.Application.CommandAndQuries.Batches.Commands.CreateBatch;
using ISTCOSA.Application.CommandAndQuries.Batches.Commands.DeleteBatch;
using ISTCOSA.Application.CommandAndQuries.Batches.Commands.UpdateBatch;
using ISTCOSA.Application.CommandAndQuries.Batches.Queries.GetBatchById;
using ISTCOSA.Application.CommandAndQuries.Batches.Queries.GetBatches;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BatchController:BaseAPIController
    {
        
        [HttpGet("GetAllBatches")]
        [ProducesResponseType(typeof(List<BatchDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllBatches()
        {
            var batchList = await Mediator.Send(new GetAllBatchQuery());
            if (batchList == null || !batchList.Any())
            {
                return NotFound("No batches found.");
            }
            return Ok(batchList);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBatch(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid batch ID.");
            }
            var batch = await Mediator.Send(new GetBatchByIdQuery { BatchId = id });
            if (batch == null)
            {
                return NotFound("Batch not found.");
            }
            return Ok(batch);
        }

        [HttpPost("CreateBatch")]
        public async Task<IActionResult> CreateBatch([FromBody] CreateBatchCommand createBatchCommand)
        {
            if (createBatchCommand == null)
            {
                return BadRequest("Batch data is null.");
            }
            var createdBatch = await Mediator.Send(createBatchCommand);
            if (createdBatch == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating batch.");
            }
            return CreatedAtAction(nameof(GetBatch), new { id = createdBatch.BatchId }, createdBatch);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid batch ID.");
            }
            var result = await Mediator.Send(new DeleteCommand { BatchId = id });
            if (result == null)
            {
                return NotFound("Batch not found.");
            }
            return Ok("Batch deleted successfully.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] UpdateBatchCommand updateBatchCommand)
        {
            if (id <= 0 || updateBatchCommand == null)
            {
                return BadRequest("Invalid batch ID or batch data.");
            }
            if (updateBatchCommand.BatchId != id)
            {
                return BadRequest("Batch ID mismatch.");
            }
            var updatedBatch = await Mediator.Send(updateBatchCommand);
            if (updatedBatch == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating batch.");
            }
            return Ok(updatedBatch);
        }
    }
}
