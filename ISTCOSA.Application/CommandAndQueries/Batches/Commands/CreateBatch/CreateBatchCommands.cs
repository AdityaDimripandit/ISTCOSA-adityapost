

namespace ISTCOSA.Application.CommandAndQuries.Batches.Commands.CreateBatch
{
    public class CreateBatchCommand : IRequest<BatchDTO>
    {
        public int BatchNumber { get; set; }


    }
}
