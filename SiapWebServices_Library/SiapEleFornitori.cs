using SiapWebServices_Library.EleFornitori_WSService;
using System.Collections.Generic;
using System.ServiceModel;
using System;

namespace SiapEleFornitori
{
    public class SiapEleFornitori_Methods
    {

        // Generate Webservices Client
        public static EleFornitori_WSClient EleFornitori_client()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "EleFornitori_client",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                SendTimeout = new TimeSpan(0, 60, 0)
            };

            var endpoint = new EndpointAddress("http://85.46.89.115/standard-atlante-plus/services/EleFornitori_WS?wsdl");
            var client = new EleFornitori_WSClient(binding, endpoint);

            return client;
        }

        // Remember that retunrs only 30 suppliers max!
        public static List<StructAnaFornitore> Search_Supplier(EleFornitori_WSClient client, StructLogin loginCredentials, StructParamRicFornIn parameters = null, string showSuspended = "N", string searchType = "E")
        {
            if (parameters == null)
            {
                parameters = new StructParamRicFornIn
                {
                    codFornitore12 = "3"
                };
            }

            parameters.visualSospesi = showSuspended;

            var supplier_list = new List<StructAnaFornitore>();

            var search = new StructRicFornitoriIn
            {
                ILogin = loginCredentials,
                paramRicFornIn = parameters,
                tipoRicerca = searchType
            };
            try
            {
                var supplier_retrived = client.ricerca(search);

                switch (supplier_retrived.risultatoCompleto)
                {
                    case "E":
                        {
                            return supplier_list;
                        }
                    case "N":
                        {
                            return supplier_list;
                        }

                    default:
                        {
                            foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
                            {
                                supplier_list.Add(supplier);
                            }
                            return supplier_list;
                        }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR - " + ex);
                return supplier_list;
            }
        }

   






























































    }
          
}











































































    





