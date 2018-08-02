using System;
using System.Collections.Generic;
using System.ServiceModel;
using SiapWebServices_Library.WebServicesFornitoreService;


namespace SiapWSFornitore
{
    public class SiapServicesFornitore_Methods
    {
        // Generate Webservices Client
        public static WebServicesFornitoreClient WebServicesFornitore_client()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "WebServicesFornitore_client",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                SendTimeout = new TimeSpan(0, 180, 0)
            };

            var endpoint = new EndpointAddress("http://85.46.89.115/standard-atlante-plus/services/WebServicesFornitore?wsdl");
            var client = new WebServicesFornitoreClient(binding, endpoint);

            return client;
        }

        public static List<StructAnaFornitoreOut> Get_All_Suppliers(WebServicesFornitoreClient client, StructLogin loginCredentials, string showSuspended = "N", string searchType = "R")
        {
            var supplier_list = new List<StructAnaFornitoreOut>();
            var supplier_retrived = new StructAnaFornitoreOut
            {
                esito = new StructEsito
                {
                    stato = "OK",
                }
            };

            int KO_Count = 0;
            int conto = 1;
            int sottoconto = 1;
            int codice = 0;
            string codFornitore = Generate_Supplier_Code_String(codice, sottoconto, conto);

            var search = new StructAnaFornitoreIn
            {
                IAnaFornitore = new StructAnaFornitore
                {
                    codice = codFornitore
                },
                IAzione = "C",
                //vModRicerca = new string[] { "COD_FIS","PAR_IVA","ALT_SIS" }
            };
            while (KO_Count < 10)
            {
                while (KO_Count < 10)
                {
                    while (KO_Count < 10)
                    {
                        supplier_retrived = client.gestioneAnagraficaFornitore(loginCredentials, search);

                        if (supplier_retrived.esito.stato == "KO")
                        {
                            KO_Count++;
                        }
                        else
                        {
                            supplier_list.Add(supplier_retrived);
                            codFornitore = Generate_Supplier_Code_String(codice, sottoconto, conto);
                            Console.WriteLine(codFornitore);
                            codice++;
                            search.IAnaFornitore.codice = codFornitore;
                        }
                    }
                    KO_Count = 0;
                    sottoconto++;
                }
                KO_Count = 0;
                conto++;
            }























            return supplier_list;
        }

        // Returns a supplier code string increased by 1
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










    }
}
