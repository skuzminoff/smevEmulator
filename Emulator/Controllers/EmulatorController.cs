using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using Emulator.Extensions;

namespace Emulator.Controllers
{
    [Route("api/[controller]")]
    public class EmulatorController : Controller
    {
        private RequestHandlers _requestHandlers;

        public EmulatorController()
        {
            _requestHandlers = new RequestHandlers();
        }


        [HttpPost]
        public async Task<Stream> Post([FromBody] string body)
        {
            var requestData = body;

            var doc = XDocument.Parse(body);

            Stream result = null;

            if (doc.IsMessageTypeOf("GetRequestRequest"))
                result = await _requestHandlers.GetRequest(body);

            if (doc.IsMessageTypeOf("GetResponseRequest"))
                result = await _requestHandlers.GetResponse(body);

            return result;
        }
       
    }
}
