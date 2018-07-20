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

        // Get Customer Details in a non-async way
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

        // Trasform Customer details to Object
        public static dynamic CustomerDetails_To_Object(StructAnaContattoOut details)
        {
            dynamic Contact = new ExpandoObject();

            Contact.codice_cliente = details.anaContatto.VClienti.First().codCliente;
            Contact.tipoSoggetto = details.anaContatto.VSoggetti.First().tipoSoggetto;
            Contact.fonte_chiave = details.anaContatto.fonte.chiave;
            Contact.fonte_tipo = details.anaContatto.fonte.tipoFonte;

            // StructCrmAnaGeneraleRidotta
            Contact.nome = details.anaContatto.anaGenerale.nome;
            Contact.cognome = details.anaContatto.anaGenerale.cognome;
            Contact.ragioneSociale = details.anaContatto.anaGenerale.ragioneSociale;
            Contact.indirizzo = details.anaContatto.anaGenerale.indirizzo;
            Contact.citta = details.anaContatto.anaGenerale.citta;
            Contact.cap = details.anaContatto.anaGenerale.cap;
            Contact.codProvincia = details.anaContatto.anaGenerale.codProvincia;
            Contact.codRegione = details.anaContatto.anaGenerale.codRegione;
            Contact.codStato = details.anaContatto.anaGenerale.codStato;
            Contact.codNazione = details.anaContatto.anaGenerale.codNazione;
            Contact.agenziaDittaPrivato = details.anaContatto.anaGenerale.agenziaDittaPrivato;
            Contact.codiceFiscale = details.anaContatto.anaGenerale.codiceFiscale;
            Contact.partitaIva = details.anaContatto.anaGenerale.partitaIva;
            Contact.sesso = details.anaContatto.anaGenerale.sesso;
            Contact.statoRecord = details.anaContatto.anaGenerale.statoRecord;

            // StructCrmAnaGenerale
            Contact.informazioniAggiuntive = details.anaContatto.anaGenerale.informazioniAggiuntive;
            Contact.personaFisica = details.anaContatto.anaGenerale.personaFisica;
            Contact.dataNascita = details.anaContatto.anaGenerale.dataNascita;
            Contact.luogoNascita = details.anaContatto.anaGenerale.luogoNascita;
            Contact.statoCivile = details.anaContatto.anaGenerale.statoCivile;
            Contact.codProfessione = details.anaContatto.anaGenerale.codProfessione;
            Contact.codTitolo = details.anaContatto.anaGenerale.codTitolo;
            Contact.catMerceol = details.anaContatto.anaGenerale.catMerceol;
            Contact.sottoCatMerceol = details.anaContatto.anaGenerale.sottoCatMerceol;
            Contact.codGruppo = details.anaContatto.anaGenerale.codGruppo;
            Contact.codTitoloStudio = details.anaContatto.anaGenerale.codTitoloStudio;
            Contact.codNotePersona = details.anaContatto.anaGenerale.codNotePersona;
            Contact.codStatoOperativo = details.anaContatto.anaGenerale.codStatoOperativo;
            Contact.consensoPrivacyServizi = details.anaContatto.anaGenerale.consensoPrivacyServizi;
            Contact.consensoPrivacyMateriale = details.anaContatto.anaGenerale.consensoPrivacyMateriale;
            Contact.consensoPrivacyTerzi = details.anaContatto.anaGenerale.consensoPrivacyServizi;
            Contact.consensoPrivacySensibiliTerzi = details.anaContatto.anaGenerale.consensoPrivacySensibiliTerzi;
            Contact.unitaOperativa = details.anaContatto.anaGenerale.unitaOperativa;

            // Credenziali
            Contact.userIdSiap = details.anaContatto.credenziali.userIdSiap;
            Contact.codAccessoSiap = details.anaContatto.credenziali.codAccessoSiap;
            Contact.newUserIdSiap = details.anaContatto.credenziali.newUserIdSiap;
            Contact.newCodAccessoSiap = details.anaContatto.credenziali.newCodAccessoSiap;

            // Preferenze
            foreach (StructCrmAnaPreferenze pre in details.anaContatto.VPreferenze)
            {
                foreach (StructPreferenze pref in pre.VOpzioni)
                {
                    int count = 1;

                    if (pref.@checked == "Y")
                    {
                        string numeroprefer = "Preferenza" + count.ToString();
                        var preferen = new
                        {
                            numeroprefer, pref.codice,
                        };
                        count++;
                        Contact.Add(preferen);
                    }
                }
            }

            // Azioni (separate csv file for separate table)
            foreach (StructCrmAzione act in details.anaContatto.VAzioni)
            {
                dynamic azione = new ExpandoObject();

                azione.codGruOpeNotificaAzEseguita = act.codGruOpeNotificaAzEseguita;
                azione.codGruOpeNotificaAzSuccessiva = act.codGruOpeNotificaAzSuccessiva;
                azione.codOpeAzEseguita = act.codOpeAzEseguita;
                azione.codOpeAzSuccessiva = act.codOpeAzSuccessiva;
                azione.codOpeCreaz = act.codOpeCreaz;
                azione.codOpeNotificaAzEseguita = act.codOpeNotificaAzEseguita;
                azione.codOpeNotificaAzSuccessiva = act.codOpeNotificaAzSuccessiva;
                azione.codTipoApAzEseguita = act.codTipoApAzEseguita;
                azione.codTipoApAzSuccessiva = act.codTipoApAzSuccessiva;
                azione.dataAzEseguita = act.dataAzEseguita;
                azione.dataAzSuccessiva = act.dataAzSuccessiva;
                azione.dataCreaz = act.dataCreaz;
                azione.dataProgrammataAzEseguita = act.dataProgrammataAzEseguita;
                azione.dataProgrammataAzSuccessiva = act.dataProgrammataAzSuccessiva;
                azione.descAzEseguita = act.descAzEseguita;
                azione.descAzSuccessiva = act.descAzSuccessiva;
                azione.desRiferimento = act.desRiferimento;
                azione.emailNotificaAzEseguita = act.emailNotificaAzEseguita;
                azione.emailNotificaAzSuccessiva = act.emailNotificaAzSuccessiva;
                azione.flagNotificaAzEseguita = act.flagNotificaAzEseguita;
                azione.flagNotificaAzSuccessiva = act.flagNotificaAzSuccessiva;
                azione.flagTipoNotificaAzSuccessiva = act.flagTipoNotificaAzSuccessiva;
                azione.idAzione = act.idAzione;
                azione.oraAzEseguita = act.oraAzEseguita;
                azione.oraAzSuccessiva = act.oraAzSuccessiva;
                azione.oraCreaz = act.oraCreaz;
                azione.oraProgrammataAzEseguita = act.oraProgrammataAzEseguita;
                azione.oraProgrammataAzSuccessiva = act.oraProgrammataAzSuccessiva;
                azione.sottoAzioneL1 = act.sottoAzioneL1;
                azione.sottoAzioneL2 = act.sottoAzioneL2;
                azione.sottoAzioneL3 = act.sottoAzioneL3;
                azione.sottoAzioneL4 = act.sottoAzioneL4;
                azione.stato = act.stato;
                azione.statoRecord = act.statoRecord;
                azione.tipo = act.tipo;
                azione.tipoRiferimento = act.tipoRiferimento;

                Contact.Add(azione);
            }

            // Documenti Multimediali
            foreach (StructCrmAnaDocMult docm in details.anaContatto.VDocumentiMultimediali)
            {
                dynamic documento_multimediale = new ExpandoObject();

                documento_multimediale.descrizione = docm.descrizione;
                documento_multimediale.file = docm.file;
                documento_multimediale.nome = docm.nome;
                documento_multimediale.tipo = docm.tipo;
                documento_multimediale.stato = docm.stato;

                Contact.Add(documento_multimediale);

            }

            // Documenti Personali
            foreach (StructCrmAnaDocPers docp in details.anaContatto.VDocumentiPersonali)
            {
                dynamic documento_personale = new ExpandoObject();

                documento_personale.progre = docp.progre;
                documento_personale.tipo = docp.tipo;
                documento_personale.numero = docp.numero;
                documento_personale.dataScadenza = docp.dataScadenza;
                documento_personale.enteRilascio = docp.enteRilascio;
                documento_personale.dataRilascio = docp.dataRilascio;
                documento_personale.dataRinnovo = docp.dataRinnovo;
                documento_personale.codCittadinanza = docp.codCittadinanza;
                documento_personale.altriDati = docp.altriDati;
                documento_personale.codStatoOperativo = docp.codStatoOperativo;
                documento_personale.stato = docp.stato;

                Contact.Add(documento_personale);

                foreach (StructCrmAnaMovimentoPunti mov in docp.VMovimenti)
                {
                    dynamic mov_punti = new ExpandoObject();

                    mov_punti.codCausale = mov.codCausale;
                    mov_punti.progre = mov.progre;
                    mov_punti.punti = mov.punti;
                    mov_punti.noteInterne = mov.noteInterne;
                    mov_punti.statoRecord = mov.statoRecord;

                    Contact.Add(mov_punti);

                }
            }

            // Recapiti
            foreach (StructCrmAnaRecapiti rec in details.anaContatto.VRecapiti)
            {
                dynamic recapito = new ExpandoObject();

                recapito.idRecapito = rec.idRecapito;
                recapito.codRecapito = rec.codRecapito;
                recapito.indirizzo = rec.indirizzo;
                recapito.citta = rec.citta;
                recapito.cap = rec.cap;
                recapito.codProvincia = rec.codProvincia;
                recapito.codStato = rec.codStato;
                recapito.codNazione = rec.codNazione;
                recapito.note = rec.note;
                recapito.dataValiditaIn = rec.dataValiditaIn;
                recapito.dataValiditaFi = rec.dataValiditaFi;
                recapito.oraIniziale = rec.oraIniziale;
                recapito.oraFinale = rec.oraFinale;
                recapito.visibilita = rec.visibilita;
                recapito.valore = rec.valore;
                recapito.consensoContatto = rec.consensoContatto;
                recapito.livelloAccesso = rec.livelloAccesso;
                recapito.statoRecord = rec.statoRecord;

                Contact.Add(recapito);
            }

            // Convenzioni
            foreach (StructCrmAnaConvenzioni conv in details.anaContatto.VConvenzioni)
            {
                dynamic convenzione = new ExpandoObject();

                convenzione.idConvenzione = conv.idConvenzione;
                convenzione.codConvenzione = conv.codConvenzione;
                convenzione.statoRecord = conv.statoRecord;

                Contact.Add(convenzione);
            }

            // Estensioni
            foreach (StructCrmAnaEstensioni est in details.anaContatto.VEstensioni)
            {
                foreach (StructCampo campo in est.VCampi)
                {
                    dynamic estensione = new ExpandoObject();

                    estensione.id = est.id;
                    estensione.id_campo = campo.id;
                    estensione.label = campo.label;
                    estensione.descrizione = campo.descrizione;
                    estensione.tipoRaggruppamento = campo.tipoRaggruppamento;
                    estensione.tipoInput = campo.tipoInput;
                    estensione.tipoDato = campo.tipoDato;
                    estensione.lunghezza = campo.lunghezza;
                    estensione.decimali = campo.decimali;
                    estensione.valoriIniziali = campo.valoriIniziali;
                    estensione.helpContestuale = campo.helpContestuale;
                    estensione.risposte = campo.risposte;

                    Contact.Add(estensione);
                }
            }

            // Sottoscrizioni e Giocate
            foreach (StructSottoscrizioni sot in details.anaContatto.sottoscrizioni.VOpzioni)
            {
                dynamic sottoscrizione = new ExpandoObject();

                sottoscrizione.codice = sot.codice;
                sottoscrizione.descrizione = sot.descrizione;

                Contact.Add(sottoscrizione);


                foreach (StructCrmAnaGiocata gio in sot.VGiocate)
                {
                    dynamic giocata = new ExpandoObject();

                    giocata.progre = gio.progre;
                    giocata.giocato = gio.giocato;
                    giocata.data = gio.data;
                    giocata.ora = gio.ora;
                    giocata.vinto = gio.vinto;
                    giocata.codPremio = gio.codPremio;
                    giocata.statoRecord = gio.statoRecord;

                    Contact.Add(giocata);
                }
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

            if (all_customers.esito.stato == "OK")
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
                }
                
            }
            return customers_to_return;


        }

            
        
    }

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


}
























































