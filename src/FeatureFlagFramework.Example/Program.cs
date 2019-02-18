using FeatureFlagFramework.Clients;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FeatureFlagFramework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IFeatureFlagClient client = FeatureFlagFramework.Client.Instance;

                if (client.Evaluate("example-feature-flag", false))
                {
                    Console.WriteLine(client.GetType().ToString() + " True");
                }
                else
                {
                    Console.WriteLine(client.GetType().ToString() + " False");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
