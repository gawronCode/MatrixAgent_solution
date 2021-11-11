using System;
using System.Linq;
using System.Threading.Tasks;
using MatrixAgent.Models;


namespace MatrixAgent.Services
{
    public class MatrixAgentService : IMatrixAgentService
    {

        public async Task<RowColMultiplicationDto> 
            CalculateScalar(RowColMultiplicationDto rowCol)
        {

            var random = new Random(DateTime.Now.Millisecond);
            var sleepTime = random.Next(500, 2000);


            return await Task.Run(async () =>
            {
                Console.WriteLine($"Obliczenia potrwają {sleepTime}ms");

                await Task.Delay(sleepTime);
                
                rowCol.ResultScalar = rowCol.VectorRowA.Zip(rowCol.VectorColB)
                    .Select(q => q.First * q.Second).Sum();

                return rowCol;
            });
        }

    }
}
