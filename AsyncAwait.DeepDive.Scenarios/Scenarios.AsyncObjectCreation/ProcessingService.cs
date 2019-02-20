using System;
using System.Threading.Tasks;

namespace AsyncObjectCreation
{
    public class ProcessingService
    {
        internal async Task InitializeAsync()
        {
            await Task.Delay(1000);
        }
    }
}