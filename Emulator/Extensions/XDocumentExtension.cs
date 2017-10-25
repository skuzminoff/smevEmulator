using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emulator.Extensions
{
    public static class XDocumentExtension
    {
        private static readonly XNamespace Ns2 =
               "urn://x-artefacts-smev-gov-ru/services/message-exchange/types/1.1";

        public static bool IsMessageTypeOf(this XDocument message, string typeName)
        {
            var desc = (from el in message.Root.Descendants()
                        where el.Name == Ns2 + typeName
                        select el);
            return desc != null && desc.Any() ? desc.First() != null : false;
        }
    }
}
