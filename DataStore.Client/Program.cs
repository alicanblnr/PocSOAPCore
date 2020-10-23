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
                var binding = new BasicHttpBinding() { MaxReceivedMessageSize = 1000000 };
                var endpoint = new EndpointAddress(ConfigurationManager.AppSettings["ServerEndPoint"]);

                FileStoreService.OperationsClient client = new FileStoreService.OperationsClient(binding, endpoint);

                var result = client.Register(new FileStoreService.RegisterRequestModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "SoapCore Demo",
                    EmailId = "demo@daysharpner.com"
                });
                Console.WriteLine(result.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.Read();
        }
    }
}
