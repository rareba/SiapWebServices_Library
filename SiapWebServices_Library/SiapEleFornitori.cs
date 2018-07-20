using SiapWebServices_Library.EleFornitori_WSService;
using System.Collections.Generic;
using System.ServiceModel;
using System;

namespace SiapEleFornitori
{
    public class SiapEleFornitori_Methods
    {
        public static string Generate_Supplier_Code_String(int codice = 0, int sottoconto = 1, int conto = 1, string mastro = "30")
        {
            codice++;
            string string_conto = " ";
            string string_sottoconto = " ";
            string string_codice = "     ";

            if (conto > 9)
            {
                string_conto = "";
            }

            if (sottoconto > 9)
            {
                string_sottoconto = "";
            }

            if (codice > 9)
            {
                string_codice = "    ";
            }
            else if (codice > 99)
            {
                string_codice = "   ";
            }
            else if (codice > 999)
            {
                string_codice = "  ";
            }
            else if (codice > 9999)
            {
                string_codice = "  ";
            }
            else if (codice > 99999)
            {
                string_codice = " ";
            }
            else if (codice >= 999999)
            {
                string_codice = "";
            }

            string customercode = mastro + string_conto + conto + string_sottoconto + sottoconto + string_codice + codice;

            return customercode;
        }

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

        public static List<StructAnaFornitore> Get_All_Suppliers(EleFornitori_WSClient client, StructLogin loginCredentials, string showSuspended = "N", string searchType = "R")
        {
            var supplier_list = new List<StructAnaFornitore>();
            StructRicFornitoriOut supplier_retrived = new StructRicFornitoriOut() { risultatoCompleto = "" };
            int conto = 1;
            int sottoconto = 1;
            int codice = 0;
            string codFornitore12 = Generate_Supplier_Code_String(codice, sottoconto, conto);

            StructParamRicFornIn parameters = new StructParamRicFornIn
            {
                codFornitore12 = codFornitore12,
                visualSospesi = showSuspended
            };

            var search = new StructRicFornitoriIn
            {
                ILogin = loginCredentials,
                paramRicFornIn = parameters,
                tipoRicerca = searchType
            };

            supplier_retrived = client.ricerca(search);
            if (supplier_retrived.risultatoCompleto != "E")
            {
                foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
                {
                    supplier_list.Add(supplier);
                    codFornitore12 = Generate_Supplier_Code_String(codice);
                }
            }

            while (supplier_retrived.risultatoCompleto != "N")
            {
                supplier_retrived = client.ricerca(search);

                if (supplier_retrived.risultatoCompleto != "E")
                {
                    foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
                    {
                        supplier_list.Add(supplier);
                    }
                }


            }

















        }

          
}











































































    }



}

