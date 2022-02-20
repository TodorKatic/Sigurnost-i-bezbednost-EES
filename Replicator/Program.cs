using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Replicator
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            NetTcpBinding binding2 = new NetTcpBinding();
            string decryptedData;
            byte[] data = null;

            while (true)
            {
                try
                {
                    ChannelFactory<IReplicate> cfService = new ChannelFactory<IReplicate>(binding, "net.tcp://localhost:9998/IReplicate");
                    ChannelFactory<IReplicate> cfReplicator = new ChannelFactory<IReplicate>(binding2, "net.tcp://localhost:9998/IReplicate");
                    IReplicate kService = cfService.CreateChannel();
                    IReplicate kReplicator = cfReplicator.CreateChannel();

                    

                    data = kService.ReadCryptedData();


                    //cryptedData = kService.ReadCryptedData();
                    decryptedData=kReplicator.WriteDecryptedData(data);
                    File.WriteAllText("Kikiriki.txt", decryptedData);

                    Console.WriteLine("Podaci replicirani");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(10000);
            }

            Console.ReadKey();
        }
    }
}
