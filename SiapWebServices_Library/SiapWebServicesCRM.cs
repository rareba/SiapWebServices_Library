using SiapWebServices_Library.WebServicesCRMService;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using System;
using System.IO;
using ExcelDataReader;
using System.Data;
using SiapWebServices_Library;

namespace SiapWebServicesCRM
{
    public class SiapWebServicesCRM_Methods
    {
        // Generate WebservicesCliente
        public static WebServicesCRMClient SiapWebServicesCRMClient()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "SiapWebServicesCRMClient",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                SendTimeout = new TimeSpan(0, 60, 0)
            };

            var endpoint = new EndpointAddress("http://85.46.89.115/standard-atlante-plus/services/WebServicesCRM?wsdl");
            var client = new WebServicesCRMClient(binding, endpoint);

            return client;
        }

        // Return all Customers in a Asyncronous way
        public static async Task<List<StructRisultatoRicercaAnaOut>> GetCustomersAsync(WebServicesCRMClient client, StructLogin loginCredentials, string customer_type)
        {

            List<StructRisultatoRicercaAnaOut> customers = new List<StructRisultatoRicercaAnaOut> { };

            var AllCustomers = new StructRisultatiRicercaAnaOut { numTotAna = 1 };

            var Find_All_Customers = new StructParamRicercaAnaCrm
            {
                soggetto = customer_type,
                codKeyUnitaOp = "-1",
                indiceIniziale = 0,
                indiceFinale = 2147483647,
                statoRecord = " "
            };

            while (AllCustomers.numTotAna > 0)
            {
                AllCustomers = await client.ricercaAnagraficaCRMAsync(loginCredentials, Find_All_Customers);

                if (AllCustomers.numTotAna != 0)
                {
                    foreach (StructRisultatoRicercaAnaOut customerobject in AllCustomers.risultati)
                    {
                        customers.Add(customerobject);
                    }
                    Find_All_Customers.indiceIniziale = Find_All_Customers.indiceIniziale + 30000;
                    Find_All_Customers.indiceFinale = Find_All_Customers.indiceFinale + 30000;
                }
            }
            return customers;
        }

        // Return all Customers in a non-async way
        public static List<StructRisultatoRicercaAnaOut> GetCustomers(WebServicesCRMClient client, StructLogin loginCredentials, string customer_type)
        {

            List<StructRisultatoRicercaAnaOut> customers = new List<StructRisultatoRicercaAnaOut> { };

            var AllCustomers = new StructRisultatiRicercaAnaOut { numTotAna = 1 };

            var Find_All_Customers = new StructParamRicercaAnaCrm
            {
                soggetto = customer_type,
                codKeyUnitaOp = "-1",
                indiceIniziale = 0,
                indiceFinale = 2147483647,
                statoRecord = " "
            };

            while (AllCustomers.numTotAna > 0)
            {
                AllCustomers = client.ricercaAnagraficaCRM(loginCredentials, Find_All_Customers);

                if (AllCustomers.numTotAna != 0)
                {
                    foreach (StructRisultatoRicercaAnaOut customerobject in AllCustomers.risultati)
                    {
                        customers.Add(customerobject);
                    }
                    Find_All_Customers.indiceIniziale = Find_All_Customers.indiceIniziale + 30000;
                    Find_All_Customers.indiceFinale = Find_All_Customers.indiceFinale + 30000;
                }
            }
            return customers;
        }

        // Get Customer Details in a normal way
        public static StructAnaContattoOut GetCustomerDetails(WebServicesCRMClient client, StructLogin loginCredentials, string key, string cf, string vatn, string source_type, string userIdSiap)
        {
            StructAzioni AzioniY = new StructAzioni { gestioneAzioni = "Y" };

            StructKeyAnaContatto search = new StructKeyAnaContatto
            {
                chiave = key,
                codFiscale = cf,
                partitaIva = vatn,
                tipoFonte = source_type,
                userIdSiap = userIdSiap
            };

            StructAnaContattoOut contact_details = client.interrogazioneAnagraficaContatto(loginCredentials, search, AzioniY);

            return contact_details;
        }

        // Get Customer Details async
        public static async Task<StructAnaContattoOut> GetCustomerDetailsAsync(WebServicesCRMClient client, StructLogin loginCredentials, string key, string cf, string vatn, string source_type, string userIdSiap)
        {
            StructAzioni AzioniY = new StructAzioni { gestioneAzioni = "Y" };

            StructKeyAnaContatto search = new StructKeyAnaContatto
            {
                chiave = key,
                codFiscale = cf,
                partitaIva = vatn,
                tipoFonte = source_type,
                userIdSiap = userIdSiap
            };

            StructAnaContattoOut contact_details = await client.interrogazioneAnagraficaContattoAsync(loginCredentials, search, AzioniY);

            return contact_details;
        }

        // Trasform Customer details to Object
        public static Complete_CustomerObject CustomerDetails_To_Object(StructAnaContattoOut details)
        {
            Complete_CustomerObject Contact = new Complete_CustomerObject();

            Contact.Codice_cliente = details.anaContatto.VClienti.First().codCliente;
            Contact.TipoSoggetto = details.anaContatto.VSoggetti.First().tipoSoggetto;
            Contact.Fonte_chiave = string.IsNullOrEmpty(details.anaContatto.fonte.chiave) ? "" : details.anaContatto.fonte.chiave; 
            Contact.Fonte_tipo = string.IsNullOrEmpty(details.anaContatto.fonte.tipoFonte) ? "" : details.anaContatto.fonte.tipoFonte;

            // StructCrmAnaGeneraleRidotta
            Contact.Nome = details.anaContatto.anaGenerale.nome;
            Contact.Cognome = details.anaContatto.anaGenerale.cognome;
            Contact.RagioneSociale = details.anaContatto.anaGenerale.ragioneSociale;
            Contact.Indirizzo = details.anaContatto.anaGenerale.indirizzo;
            Contact.Citta = details.anaContatto.anaGenerale.citta;
            Contact.Cap = details.anaContatto.anaGenerale.cap;
            Contact.CodProvincia = details.anaContatto.anaGenerale.codProvincia;
            Contact.CodRegione = details.anaContatto.anaGenerale.codRegione;
            Contact.CodStato = details.anaContatto.anaGenerale.codStato;
            Contact.CodNazione = details.anaContatto.anaGenerale.codNazione;
            Contact.AgenziaDittaPrivato = details.anaContatto.anaGenerale.agenziaDittaPrivato;
            Contact.CodiceFiscale = details.anaContatto.anaGenerale.codiceFiscale;
            Contact.PartitaIva = details.anaContatto.anaGenerale.partitaIva;
            Contact.Sesso = details.anaContatto.anaGenerale.sesso;
            Contact.StatoRecord = details.anaContatto.anaGenerale.statoRecord;

            // StructCrmAnaGenerale
            Contact.InformazioniAggiuntive = details.anaContatto.anaGenerale.informazioniAggiuntive;
            Contact.PersonaFisica = details.anaContatto.anaGenerale.personaFisica;
            Contact.DataNascita = details.anaContatto.anaGenerale.dataNascita;
            Contact.LuogoNascita = details.anaContatto.anaGenerale.luogoNascita;
            Contact.StatoCivile = details.anaContatto.anaGenerale.statoCivile;
            Contact.CodProfessione = details.anaContatto.anaGenerale.codProfessione;
            Contact.CodTitolo = details.anaContatto.anaGenerale.codTitolo;
            Contact.CatMerceol = details.anaContatto.anaGenerale.catMerceol;
            Contact.SottoCatMerceol = details.anaContatto.anaGenerale.sottoCatMerceol;
            Contact.CodGruppo = details.anaContatto.anaGenerale.codGruppo;
            Contact.CodTitoloStudio = details.anaContatto.anaGenerale.codTitoloStudio;
            Contact.CodNotePersona = details.anaContatto.anaGenerale.codNotePersona;
            Contact.CodStatoOperativo = details.anaContatto.anaGenerale.codStatoOperativo;
            Contact.ConsensoPrivacyServizi = details.anaContatto.anaGenerale.consensoPrivacyServizi;
            Contact.ConsensoPrivacyMateriale = details.anaContatto.anaGenerale.consensoPrivacyMateriale;
            Contact.ConsensoPrivacyTerzi = details.anaContatto.anaGenerale.consensoPrivacyServizi;
            Contact.ConsensoPrivacySensibiliTerzi = details.anaContatto.anaGenerale.consensoPrivacySensibiliTerzi;
            Contact.UnitaOperativa = details.anaContatto.anaGenerale.unitaOperativa;

            // Credenziali
            Contact.UserIdSiap = details.anaContatto.credenziali.userIdSiap;
            Contact.CodAccessoSiap = details.anaContatto.credenziali.codAccessoSiap;
            Contact.NewUserIdSiap = details.anaContatto.credenziali.newUserIdSiap;
            Contact.NewCodAccessoSiap = details.anaContatto.credenziali.newCodAccessoSiap;

            // Preferenze
            foreach (StructCrmAnaPreferenze pre in details.anaContatto.VPreferenze)
            {
                    Contact.Preferenze.Add(pre);
            }

            // Azioni
            foreach (StructCrmAzione act in details.anaContatto.VAzioni)
            {
                Contact.Azioni.Add(act);
            }

            // Documenti Multimediali
            foreach (StructCrmAnaDocMult docm in details.anaContatto.VDocumentiMultimediali)
            {
                Contact.DocumentiMultimediali.Add(docm);
            }

            // Documenti Personali & movimento punti
            foreach (StructCrmAnaDocPers docp in details.anaContatto.VDocumentiPersonali)
            {
                Contact.DocumentiPersonali.Add(docp);
            }

            // Recapiti
            foreach (StructCrmAnaRecapiti rec in details.anaContatto.VRecapiti)
            {
                Contact.Recapiti.Add(rec);
            }

            // Convenzioni
            foreach (StructCrmAnaConvenzioni conv in details.anaContatto.VConvenzioni)
            {
                Contact.Convenzioni.Add(conv);
            }

            // Estensioni e campi
            foreach (StructCrmAnaEstensioni est in details.anaContatto.VEstensioni)
            {
                Contact.Estensioni.Add(est);
            }

            // Sottoscrizioni e Giocate
            foreach (StructSottoscrizioni sot in details.anaContatto.sottoscrizioni.VOpzioni)
            {
                Contact.Sottoscrizioni.Add(sot);
            }

            // Referenti & recapiti referenti
            foreach (StructCrmAnaReferenti referent in details.anaContatto.VReferenti)
            {
                Contact.Referenti.Add(referent);
            }

            return Contact;

        }

        // Return only one Customer in a Asyncronous way for test purposes
        public static async Task<List<StructRisultatoRicercaAnaOut>> TEST_GetCustomersAsync(WebServicesCRMClient client, StructLogin loginCredentials, string customer_type)
        {

            var rnd = new Random();
            int customerindex = rnd.Next(0, 3000);

            List<StructRisultatoRicercaAnaOut> customers = new List<StructRisultatoRicercaAnaOut> { };

            var AllCustomers = new StructRisultatiRicercaAnaOut { numTotAna = 1 };

            var Find_All_Customers = new StructParamRicercaAnaCrm
            {
                soggetto = customer_type,
                codKeyUnitaOp = "-1",
                indiceIniziale = customerindex,
                indiceFinale = customerindex + 1,
                statoRecord = " "
            };

            AllCustomers = await client.ricercaAnagraficaCRMAsync(loginCredentials, Find_All_Customers);

            if (AllCustomers.numTotAna != 0)
            {
                foreach (StructRisultatoRicercaAnaOut customerobject in AllCustomers.risultati)
                {
                    customers.Add(customerobject);
                }
            }

            return customers;
        }

        public static List<CustomerExportObject> Export_Customers_Base64(WebServicesCRMClient client, StructLogin loginCredentials, string customer_type)
        {
            var customers_to_return = new List<CustomerExportObject>();

            var Find_All_Customers = new StructParamRicercaAnaCrm
            {
                soggetto = customer_type,
                codKeyUnitaOp = "-1",
                indiceIniziale = 0,
                indiceFinale = 2147483647,
                statoRecord = " "
            };

            var all_customers = client.exportAnagraficheCRM(loginCredentials, Find_All_Customers);

            if (all_customers.esito.stato == "OK" && all_customers.numTotAna != 0)
            {
                DataSet excel;
                string customers_to_convert = all_customers.contentBase64;
                Byte[] customers_base64_converted = Convert.FromBase64String(customers_to_convert);
                MemoryStream ms = new MemoryStream(customers_base64_converted);

                using (var reader = ExcelReaderFactory.CreateReader(ms))
                {
                    var result = reader.AsDataSet();
                    excel = result;
                }

                DataTable excel_data = excel.Tables[0];

                // Delete first 4 rows
                for (int i = 4; i >= 0; i--)
                {
                    excel_data.Rows[i].Delete();
                }
                excel_data.AcceptChanges();

                foreach (DataRow rw in excel_data.AsEnumerable())
                {
                    var customer = new CustomerExportObject()
                    {
                        _Nome_ = Convert.ToString(rw[0]),
                        _Cognome_ = Convert.ToString(rw[1]),
                        _Ragione_Sociale_ = Convert.ToString(rw[2]),
                        _Indirizzo_ = Convert.ToString(rw[3]),
                        _Città_ = Convert.ToString(rw[4]),
                        _CAP_ = Convert.ToString(rw[5]),
                        _Provincia_ = Convert.ToString(rw[6]),
                        _Codice_Stato_ = Convert.ToString(rw[7]),
                        _Codice_Nazione_ = Convert.ToString(rw[8]),
                        _Agenzia_Ditta_Privato_ = Convert.ToString(rw[9]),
                        _Codice_Fiscale_ = Convert.ToString(rw[10]),
                        _Partita_IVA_ = Convert.ToString(rw[11]),
                        _Sesso_ = Convert.ToString(rw[12]),
                        _Stato_Record_ = Convert.ToString(rw[13]),
                        _Regione_ = Convert.ToString(rw[14]),
                        _Categoria_ = Convert.ToString(rw[15]),
                        _Informazioni_Aggiuntive_ = Convert.ToString(rw[16]),
                        _Persona_Fisica_ = Convert.ToString(rw[17]),
                        _Data_Nascita_ = Convert.ToString(rw[18]),
                        _Luogo_Nascita_ = Convert.ToString(rw[19]),
                        _Stato_Civile_ = Convert.ToString(rw[20]),
                        _Codice_Professione_ = Convert.ToString(rw[21]),
                        _Codice_Titolo_ = Convert.ToString(rw[22]),
                        _Categoria_Merceologica_ = Convert.ToString(rw[23]),
                        _Sottocategoria_Merceologica_ = Convert.ToString(rw[24]),
                        _Codice_Gruppo_ = Convert.ToString(rw[25]),
                        _Codice_Titolo_Studio_ = Convert.ToString(rw[26]),
                        _Codice_Note_Persona_ = Convert.ToString(rw[27]),
                        _Codice_Stato_Operativo_ = Convert.ToString(rw[28]),
                        _Unità_Operativa_ = Convert.ToString(rw[29]),
                        _Consenso_Privacy_Servizi_ = Convert.ToString(rw[30]),
                        _Consenso_Privacy_Materiale_ = Convert.ToString(rw[31]),
                        _Consenso_Privacy_Elettronica_Email_ = Convert.ToString(rw[32]),
                        _Consenso_Privacy_Terzi_ = Convert.ToString(rw[33]),
                        _Consenso_Privacy_Sensibili_Terzi_ = Convert.ToString(rw[34]),
                        _Telefono_ = Convert.ToString(rw[35]),
                        _Cellulare_ = Convert.ToString(rw[36]),
                        _E_mail_ = Convert.ToString(rw[37]),
                        _Soggetti_Per_Anagrafica_ = Convert.ToString(rw[38]),
                    };
                    customers_to_return.Add(customer);
                }

            }
            return customers_to_return;


        }



    }

    // Object to export customer
    public class CustomerExportObject
    {
        public string _Nome_ { get; set; }
        public string _Cognome_ { get; set; }
        public string _Ragione_Sociale_ { get; set; }
        public string _Indirizzo_ { get; set; }
        public string _Città_ { get; set; }
        public string _CAP_ { get; set; }
        public string _Provincia_ { get; set; }
        public string _Codice_Stato_ { get; set; }
        public string _Codice_Nazione_ { get; set; }
        public string _Agenzia_Ditta_Privato_ { get; set; }
        public string _Codice_Fiscale_ { get; set; }
        public string _Partita_IVA_ { get; set; }
        public string _Sesso_ { get; set; }
        public string _Stato_Record_ { get; set; }
        public string _Regione_ { get; set; }
        public string _Categoria_ { get; set; }
        public string _Informazioni_Aggiuntive_ { get; set; }
        public string _Persona_Fisica_ { get; set; }
        public string _Data_Nascita_ { get; set; }
        public string _Luogo_Nascita_ { get; set; }
        public string _Stato_Civile_ { get; set; }
        public string _Codice_Professione_ { get; set; }
        public string _Codice_Titolo_ { get; set; }
        public string _Categoria_Merceologica_ { get; set; }
        public string _Sottocategoria_Merceologica_ { get; set; }
        public string _Codice_Gruppo_ { get; set; }
        public string _Codice_Titolo_Studio_ { get; set; }
        public string _Codice_Note_Persona_ { get; set; }
        public string _Codice_Stato_Operativo_ { get; set; }
        public string _Unità_Operativa_ { get; set; }
        public string _Consenso_Privacy_Servizi_ { get; set; }
        public string _Consenso_Privacy_Materiale_ { get; set; }
        public string _Consenso_Privacy_Elettronica_Email_ { get; set; }
        public string _Consenso_Privacy_Terzi_ { get; set; }
        public string _Consenso_Privacy_Sensibili_Terzi_ { get; set; }
        public string _Telefono_ { get; set; }
        public string _Cellulare_ { get; set; }
        public string _E_mail_ { get; set; }
        public string _Soggetti_Per_Anagrafica_ { get; set; }

    }

    // Object to export all customer data
    public class Complete_CustomerObject
    {
        public string Codice_cliente { get; set; }
        public string TipoSoggetto { get; set; }
        public string Fonte_chiave { get; set; }
        public string Fonte_tipo { get; set; }

        // StructCrmAnaGeneraleRidotta
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string CodProvincia { get; set; }
        public string CodRegione { get; set; }
        public string CodStato { get; set; }
        public string CodNazione { get; set; }
        public string AgenziaDittaPrivato { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public string Sesso { get; set; }
        public string StatoRecord { get; set; }

        // StructCrmAnaGenerale
        public string InformazioniAggiuntive { get; set; }
        public string PersonaFisica { get; set; }
        public string DataNascita { get; set; }
        public string LuogoNascita { get; set; }
        public string StatoCivile { get; set; }
        public string CodProfessione { get; set; }
        public string CodTitolo { get; set; }
        public string CatMerceol { get; set; }
        public string SottoCatMerceol { get; set; }
        public string CodGruppo { get; set; }
        public string CodTitoloStudio { get; set; }
        public string CodNotePersona { get; set; }
        public string CodStatoOperativo { get; set; }
        public string ConsensoPrivacyServizi { get; set; }
        public string ConsensoPrivacyMateriale { get; set; }
        public string ConsensoPrivacyTerzi { get; set; }
        public string ConsensoPrivacySensibiliTerzi { get; set; }
        public string UnitaOperativa { get; set; }

        // Credenziali
        public string UserIdSiap { get; set; }
        public string CodAccessoSiap { get; set; }
        public string NewUserIdSiap { get; set; }
        public string NewCodAccessoSiap { get; set; }

        public List<StructCrmAnaPreferenze> Preferenze { get; set; }
        public List<StructCrmAzione> Azioni { get; set; }
        public List<StructCrmAnaDocMult> DocumentiMultimediali { get; set; }
        public List<StructCrmAnaDocPers> DocumentiPersonali { get; set; }
        public List<StructCrmAnaRecapiti> Recapiti { get; set; }
        public List<StructCrmAnaConvenzioni> Convenzioni { get; set; }
        public List<StructCrmAnaEstensioni> Estensioni { get; set; }
        public List<StructSottoscrizioni> Sottoscrizioni { get; set; }
        public List<StructCrmAnaGiocata> Giocate { get; set; }
        public List<StructCrmAnaReferenti> Referenti { get; set; }

    }


}
























































