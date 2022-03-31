using System;
using System.Configuration;
using System.ServiceModel;

namespace DataStore.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Client Started");
                for (int i = 0; i < 100; i++)
                {
                var binding = new BasicHttpBinding() { MaxReceivedMessageSize = 1000000 };
                var endpoint = new EndpointAddress(ConfigurationManager.AppSettings["ServerEndPoint"]);
                Console.WriteLine(endpoint);
                FileStoreService.OperationsClient client = new FileStoreService.OperationsClient(binding, endpoint);
                    var result = client.Register(new FileStoreService.RegisterRequestModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "We Are OnLinux Demo" + i,
                        EmailId = Guid.NewGuid().ToString() + "@gmail.com"
                    }) ;
                Console.WriteLine(result.Message +$" {i}.Try");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.Read();
        }
    }
}
