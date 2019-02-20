using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncObjectCreation
{
    class ServiceFactory
    {
        public async Task<ProcessingService> CreateProcessingService()
        {
            ProcessingService service = new ProcessingService();
            await service.InitializeAsync();

            return service;
        }
    }
}
