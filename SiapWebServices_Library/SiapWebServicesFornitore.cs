using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<StructAnaFornitoreOut> Get_All_Suppliers(WebServicesFornitoreClient client, StructLogin loginCredentials)
        {
            //0 30 1 1    ITALIA
            //0 30 1 2    ESTERO
            //0 30 1 3    FORNITORI CDC
            //0 30 2 1    TOUR OPERATOR
            //0 30 2 2    COMPAGNIE AEREE
            //0 30 2 3    HOTEL
            //0 30 2 4    AGENZIE DI VIAGGIO
            //0 30 2 5    ALTRI CORRISPONDENTI
            //0 30 2 6    FOR CORR DI APP

            var supplier_list = new List<StructAnaFornitoreOut>();
            var supplier_retrived = new StructAnaFornitoreOut
            {
                esito = new StructEsito
                {
                    stato = "OK",
                }
            };

            int conto = 1;
            int sottoconto = 1;
            bool conto_increased = false;
            bool sottoconto_increased = false;

            RESTART:
            var suppliers_to_add = Loop_over_Supplier_Code(client, loginCredentials, sottoconto, conto);
            // Add found suppliers, increase sottoconto and start again
            if (suppliers_to_add.Count() > 0)
            {
                foreach (StructAnaFornitoreOut r in suppliers_to_add)
                {
                    supplier_list.Add(r);
                }
                sottoconto++;
                sottoconto_increased = true;
                goto RESTART;
            }
            // If no suppliers are found...
            else if (suppliers_to_add.Count() == 0)
            { 
                // if sottoconto has been increased and no suppliers are found: increase conto, set sottoconto to 1 and start again
                if (sottoconto_increased == true & conto_increased == false)
                {
                    sottoconto = 1;
                    conto++;
                    conto_increased = true;
                    goto RESTART;
                }
                else
                {
                    return supplier_list;
                }

            }

            return supplier_list;
        }

        // Returns a supplier code string increased by 1
        public static string Generate_Supplier_Code_String(int codice = 0, int sottoconto = 1, int conto = 1, string mastro = "30")
        {
            codice++;
            string string_conto = "";
            string string_sottoconto = "" ;
            string string_codice = "";
        
            if (conto.ToString().Length == 1)
            {
                string_conto = " " + conto.ToString();
            }
            else
            {
                string_conto = conto.ToString();
            }

            if (sottoconto.ToString().Length == 1)
            {
                string_sottoconto = " " + sottoconto.ToString();
            }
            else
            {
                string_sottoconto = sottoconto.ToString();
            }

            switch (codice.ToString().Length)
            {
                case 1:
                    string_codice = "     " + codice.ToString();
                    break;
                case 2:
                    string_codice = "    " + codice.ToString();
                    break;
                case 3:
                    string_codice = "   " + codice.ToString();
                    break;
                case 4:
                    string_codice = "  " + codice.ToString();
                    break;
                case 5:
                    string_codice = " " + codice.ToString();
                    break;
                case 6:
                    string_codice = codice.ToString();
                    break;
                default:
                    string_codice = "";
                    break;
            }

            string customercode = mastro + string_conto + string_sottoconto + string_codice;

            return customercode;
        }


        public static List<StructAnaFornitoreOut> Loop_over_Supplier_Code(WebServicesFornitoreClient client, StructLogin loginCredentials, int sottoconto, int conto, string mastro = "30")
        {
            var supplier_list = new List<StructAnaFornitoreOut>();
            int KO_Count = 0;
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
                var supplier_retrived = client.gestioneAnagraficaFornitore(loginCredentials, search);

                if (supplier_retrived.esito.stato == "KO")
                {
                    KO_Count++;
                }
                else
                {
                    codice = codice + 1;
                    supplier_list.Add(supplier_retrived);
                    Console.WriteLine(codFornitore + " - Status: " + supplier_retrived.esito.stato);
                    codFornitore = Generate_Supplier_Code_String(codice, sottoconto, conto);
                    KO_Count = 0;
                    search.IAnaFornitore.codice = codFornitore;
                }
            }

            return supplier_list;
        }




























    }
}










