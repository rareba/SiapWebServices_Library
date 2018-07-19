using SiapWebServices_Library.EleClienti_WSService;
using System.Collections.Generic;
using System.ServiceModel;
using System;

namespace SiapEleClienti
{
    public class SiapEleClienti_Methods
    {
        // Generate WebservicesCliente
        public static EleClienti_WSClient EleClienti_client()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "SiapEleClientClient",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                SendTimeout = new TimeSpan(0, 60, 0)
            };

            var endpoint = new EndpointAddress("http://85.46.89.115/standard-atlante-plus/services/EleClienti_WS?wsdl");
            var client = new EleClienti_WSClient(binding, endpoint);

            return client;
        }

        public static List<StructAnaCliente> Get_Customer_List(EleClienti_WSClient client, StructLogin loginCredentials, StructParamRicCliIn parameters = null,  string searchType = "E")
        {
            if (parameters == null)
            {
                parameters.codCliente12 = "20";
            }

            var customer_list = new List<StructAnaCliente>();

            var search = new StructRicClientiIn {
                ILogin = loginCredentials,
                paramRicCliIn = parameters,
                tipoRicerca = searchType
            };
            try
            {
                var customers_retrived = client.ricerca(search);

                switch (customers_retrived.risultatoCompleto)
                {
                    case "E":
                        {
                            return customer_list;
                        }
                    case "N":
                        {
                            return customer_list;
                        }

                    default:
                        {
                            foreach (StructAnaCliente customer in customers_retrived.eleClienti)
                            {
                                customer_list.Add(customer);
                            }
                            return customer_list;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR! - " + ex);
                return customer_list;
            }

        }











































    }



}

