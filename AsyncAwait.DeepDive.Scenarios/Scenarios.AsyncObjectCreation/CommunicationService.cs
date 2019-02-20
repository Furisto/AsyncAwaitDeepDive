using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncObjectCreation
{
    class CommunicationService
    {
        protected CommunicationService()
        { }

        protected async Task InitializeAsync()
        {
            await Task.Delay(1000);
        }

        public static async Task<CommunicationService> CreateAsync()
        {
            CommunicationService service = new CommunicationService();
            await service.InitializeAsync();

            return service;
        }
    }
}
