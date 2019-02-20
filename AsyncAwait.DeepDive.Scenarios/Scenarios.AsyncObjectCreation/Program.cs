using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncObjectCreation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ServiceFactory fctry = new ServiceFactory();
            ProcessingService service = await fctry.CreateProcessingService();

            CommunicationService comService = await CommunicationService.CreateAsync();
        }
    }
}
