using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SiapWebServices_Library.WebServicesFornitoreService;


namespace SiapWebServices_Library
{
    class SiapWebServicesFornitore
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

        //public static List<StructAnaFornitore> Get_All_Suppliers(WebServicesFornitoreClient client, StructLogin loginCredentials, string showSuspended = "N", string searchType = "R")
        //{
        //    var supplier_list = new List<StructAnaFornitore>();
        //    StructAnaFornitoreOut supplier_retrived = new StructAnaFornitoreOut() { };
        //    int conto = 1;
        //    int sottoconto = 1;
        //    int codice = 0;
        //    bool increase_conto;
        //    bool increase_sottoconto;
        //    string codFornitore12 = Generate_Supplier_Code_String(codice, sottoconto, conto);

        //    StructAnaFornitoreIn parameters = new StructAnaFornitoreIn
        //    {
        //        IAzione = "C",

        //    };
            
            

        //    var search = new StructRicFornitoriIn
        //    {
        //        ILogin = loginCredentials,
        //        paramRicFornIn = parameters,
        //        tipoRicerca = searchType
        //    };

        //    while (supplier_retrived.risultatoCompleto != "E")
        //    {
        //        supplier_retrived = client.ricerca(search);

        //        // If now supplier is returned...
        //        if (supplier_retrived.risultatoCompleto == "N")
        //        {
        //            // increase sottoconto and try again
        //            search.paramRicFornIn.codFornitore12 = Generate_Supplier_Code_String(0, sottoconto++);
        //            supplier_retrived = client.ricerca(search);

        //            // if still no supplier...
        //            if (supplier_retrived.risultatoCompleto == "N")
        //            {
        //                // increase conto and try again
        //                search.paramRicFornIn.codFornitore12 = Generate_Supplier_Code_String(0, 1, conto++);
        //                supplier_retrived = client.ricerca(search);

        //                // if it still doesnt' work end the loop!
        //                if (supplier_retrived.risultatoCompleto == "N")
        //                {
        //                    return supplier_list;
        //                }
        //            }
        //            else
        //            {
        //                foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
        //                {
        //                    supplier_list.Add(supplier);
        //                    search.paramRicFornIn.codFornitore12 = Generate_Supplier_Code_String(codice);
        //                }
        //            }
        //        }

        //        else
        //        {
        //            foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
        //            {
        //                supplier_list.Add(supplier);
        //                search.paramRicFornIn.codFornitore12 = Generate_Supplier_Code_String(codice);
        //            }
        //        }











        //    }
        //        else // Add the supplier to the list
        //        {
        //        foreach (StructAnaFornitore supplier in supplier_retrived.eleFornitori)
        //        {
        //            supplier_list.Add(supplier);
        //            search.paramRicFornIn.codFornitore12 = Generate_Supplier_Code_String(codice);
        //        }
        //    }





















        //}

        //    return supplier_list;

        //}














}
}
