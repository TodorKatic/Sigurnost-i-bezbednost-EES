using Contracts;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ClientApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string srvCertCN = "HP";
            NetTcpBinding binding = new NetTcpBinding();
            

            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);
           

            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:9999/DatabaseManagement"),
                                      new X509CertificateEndpointIdentity(srvCert));
           


            using (ClientProxy proxy = new ClientProxy(binding, address))
            {
                proxy.TestCommunication();
                Console.WriteLine("Test com");

                Consumer cons = new Consumer();
               

                int ch;
                string read;
                float meanVal = 0;
                int id = 0;
                
                while ((ch = Menu()) != 9)
                {
                    switch (ch)
                    {

                        case 1:
                            proxy.CreateDatabase();
                            break;
                        case 2:
                            if (proxy.ArchiveDatabase())
                            {
                                Console.WriteLine("Uspesno arhivirano");
                            }
                            else
                            {
                                Console.WriteLine("Arhiviranje nije uspelo");
                            }
                            break;
                        case 3:
                            proxy.DeleteDatabase();
                            break;
                        case 4:
                            Console.WriteLine("Unesite ime regiona:");
                            read = Console.ReadLine();
                            cons = proxy.FindMaxInRegion(read, out id);
                            if(id!=0)
                            {
                                Console.WriteLine("Najveci potrosac:{0}, {1}",id , cons);
                                Console.WriteLine();
                            }
                            else { 
                                Console.WriteLine("Ne postoji potrosac iz tog regiona");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Unesite ime regiona:");
                            read = Console.ReadLine();
                            meanVal = proxy.MeanValByRegion(read);
                            if(meanVal!= 0)
                            {
                                Console.WriteLine("Srednja potrosnja za region {0} iznosi {1}", read, meanVal);
                            }
                            else
                            {
                                Console.WriteLine("Ne postoje potrosaci u navedenom regionu");
                            }
                            break;
                        case 6:
                            Console.WriteLine("Unesite ime grada:");
                            read = Console.ReadLine();
                            meanVal = proxy.MeanValByCity(read);
                            if (meanVal != 0)
                            {
                                Console.WriteLine("Srednja potrosnja za grad {0} iznosi {1}", read, meanVal);
                            }
                            else
                            {
                                Console.WriteLine("Ne postoje potrosaci u navedenom gradu");
                            }
                            break;
                        case 7:
                            Consumer potrosac = new Consumer();
                            Console.WriteLine("Unesite ID potrosaca:");
                            id = int.Parse(Console.ReadLine());
                            if (proxy.CheckID(id))
                            {
                                Console.WriteLine("Potrosac sa tim ID-em vec postoji u bazi");
                                break;
                            }
                            Console.WriteLine("Unesite ime regiona:");
                            read = Console.ReadLine();
                            potrosac.Region = read;
                            Console.WriteLine("Unesite ime grada:");
                            read = Console.ReadLine();
                            potrosac.City = read;
                            Console.WriteLine("Unesite godinu:");
                            potrosac.Year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Unesite potrosnju po mesecima");
                            List<int> lista = new List<int>();

                            for (int i = 0; i<12; i++)
                            {
                                Console.WriteLine("{0}. mesec", i);
                                lista.Add(int.Parse(Console.ReadLine()));
                            }
                            potrosac.Amount = lista;
                            if (proxy.Write(id, potrosac))
                            {
                                Console.WriteLine("Uspesno upisano u bazu");
                            }
                            else
                            {
                                Console.WriteLine("Upis neuspesan");
                            }
                            break;

                        case 8:
                            potrosac = new Consumer();
                            Console.WriteLine("Unesite ID potrosaca:");
                            id = int.Parse(Console.ReadLine());
                            if (!proxy.CheckID(id))
                            {
                                Console.WriteLine("Potrosac sa tim ID-em ne postoji u bazi");
                                break;
                            }
                            Console.WriteLine("Unesite ime regiona:");
                            read = Console.ReadLine();
                            potrosac.Region = read;
                            Console.WriteLine("Unesite ime grada:");
                            read = Console.ReadLine();
                            potrosac.City = read;
                            Console.WriteLine("Unesite godinu:");
                            potrosac.Year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Unesite potrosnju po mesecima");
                            lista = new List<int>();

                            for (int i = 0; i < 12; i++)
                            {
                                Console.WriteLine("{0}. mesec", i+1);
                                lista.Add(int.Parse(Console.ReadLine()));
                            }
                            potrosac.Amount = lista;
                            if (proxy.Modify(id, potrosac))
                            {
                                Console.WriteLine("Uspesno modifikovan");
                            }
                            else
                            {
                                Console.WriteLine("Modifikacija neuspesna");
                            }
                            break;
                        case 9:
                            break;

                    }
                }

                // proxy.CreateDatabase();
                Console.ReadKey();

            }

            Console.ReadLine();


        }
        static int Menu()
        {
            int x;

            do
            {
                Console.WriteLine("1.Kreiraj bazu");
                Console.WriteLine("2.Arhiviraj bazu");
                Console.WriteLine("3.Obrisi bazu");
                Console.WriteLine("4.Nadji najveceg potrosaca za region");
                Console.WriteLine("5.Srednja potrosnja za odredjeni region");
                Console.WriteLine("6.Srednja potronja za odredjeni grad");
                Console.WriteLine("7.Upis u bazu");
                Console.WriteLine("8.Modifikovanje baze");
                Console.WriteLine("X.Exit");

                string read = Console.ReadLine();
                if (read == "X")
                {
                    x = 9;
                }
                else if (!int.TryParse(read, out x))
                {
                    x = 0;
                }
            } while (x < 1 || x > 9);

            return x;
        }
    }
}
