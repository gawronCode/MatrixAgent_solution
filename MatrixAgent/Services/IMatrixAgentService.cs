using System.Threading.Tasks;
using MatrixAgent.Models;

namespace MatrixAgent.Services
{
    public interface IMatrixAgentService
    {
        Task<RowColMultiplicationDto> 
            CalculateScalar(RowColMultiplicationDto rowCol);
    }
}