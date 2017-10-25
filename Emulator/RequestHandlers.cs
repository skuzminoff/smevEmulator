using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator
{
    public class RequestHandlers
    {
        private static int _messageResponseCount = 0;
        private static int _messageRequestCount = 0;

        public async Task<Stream> GetResponse(string body)
        {
            string resp = "";
            resp = _messageResponseCount % 2 == 0 ? Resource.fl_gpzu : Resource.isogd_request;

            _messageResponseCount++;
            return _generateStreamFromString(resp);
        }

        public async Task<Stream> GetRequest(string body)
        {
            string resp = "";
            resp = _messageRequestCount % 2 == 0 ? Resource.fl_gpzu : Resource.isogd_request;

            _messageRequestCount++;
            return _generateStreamFromString(resp);
        }

        private MemoryStream _generateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
