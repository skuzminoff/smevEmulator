using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
namespace Grad.Smev.SmevEmulator.Client
{
	public class Program
	{
		public static void Main(string[] args)
		{
            var hs = new HttpSender();

            var text = Resources.GetResponseWithFilter;
            string uri = " http://localhost:62789/api/emulator";
            var resp = hs.Send(text, uri, "");
            Console.WriteLine(resp.ToString());
            Console.ReadLine();
        }
	}
}
