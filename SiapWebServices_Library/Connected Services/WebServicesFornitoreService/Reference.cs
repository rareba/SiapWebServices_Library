﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiapWebServices_Library.WebServicesFornitoreService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Servizi.Anagrafiche.APWebServices", ConfigurationName="WebServicesFornitoreService.WebServicesFornitore")]
    public interface WebServicesFornitore {
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="gestioneAnagraficaFornitoreReturn")]
        SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreOut gestioneAnagraficaFornitore(SiapWebServices_Library.WebServicesFornitoreService.StructLogin iLogin, SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreIn iAnaFornitoreIn);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="gestioneAnagraficaFornitoreReturn")]
        System.Threading.Tasks.Task<SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreOut> gestioneAnagraficaFornitoreAsync(SiapWebServices_Library.WebServicesFornitoreService.StructLogin iLogin, SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreIn iAnaFornitoreIn);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://Strutture.WebServices.siap.com")]
    public partial class StructLogin : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string passwordField;
        
        private string utenteField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string utente {
            get {
                return this.utenteField;
            }
            set {
                this.utenteField = value;
                this.RaisePropertyChanged("utente");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://Strutture.WebServices.siap.com")]
    public partial class StructEsito : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messaggioField;
        
        private string statoField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string messaggio {
            get {
                return this.messaggioField;
            }
            set {
                this.messaggioField = value;
                this.RaisePropertyChanged("messaggio");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string stato {
            get {
                return this.statoField;
            }
            set {
                this.statoField = value;
                this.RaisePropertyChanged("stato");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://Strutture.Anagrafiche.APWebServices")]
    public partial class StructAnaFornitoreOut : object, System.ComponentModel.INotifyPropertyChanged {
        
        private StructAnaFornitore anaFornitoreField;
        
        private string azioneEseguitaField;
        
        private StructEsito esitoField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public StructAnaFornitore anaFornitore {
            get {
                return this.anaFornitoreField;
            }
            set {
                this.anaFornitoreField = value;
                this.RaisePropertyChanged("anaFornitore");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string azioneEseguita {
            get {
                return this.azioneEseguitaField;
            }
            set {
                this.azioneEseguitaField = value;
                this.RaisePropertyChanged("azioneEseguita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public StructEsito esito {
            get {
                return this.esitoField;
            }
            set {
                this.esitoField = value;
                this.RaisePropertyChanged("esito");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://Strutture.Anagrafiche.APWebServices")]
    public partial class StructAnaFornitore : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string abiField;
        
        private string cabField;
        
        private string capField;
        
        private string codAgenziaRifField;
        
        private string codBancaField;
        
        private string codBancaClienteCorrispondenteField;
        
        private string codCategoriaField;
        
        private string codCheckDigitField;
        
        private string codCheckDigitClienteCorrispondenteField;
        
        private string codCinField;
        
        private string codCinClienteCorrispondenteField;
        
        private string codClienteCorrispondenteField;
        
        private string codFiscaleField;
        
        private string codFornitoreAltroSistemaField;
        
        private string codGruppoField;
        
        private string codModPagamentoField;
        
        private string codNazIsoPerPagamIntrastatField;
        
        private string codNazioneField;
        
        private string codNsBancaField;
        
        private string codNsBancaClienteCorrispondenteField;
        
        private string codRiconoscimentoField;
        
        private string codValutaField;
        
        private string codZonaField;
        
        private string codiceField;
        
        private string contoContropartitaField;
        
        private string contoCorrenteBancarioField;
        
        private string contoCorrenteBancarioClienteCorrispondenteField;
        
        private string cpdc_personalizzatoField;
        
        private string cpdc_personalizzatoClienteCorrispondenteField;
        
        private string dataNascitaField;
        
        private string descrizioneBancaField;
        
        private string emailField;
        
        private string flagAllegatoIvaField;
        
        private string flagAllegatoParadFiscField;
        
        private string flagGeneraClienteCorrispondenteField;
        
        private string flagInvioDocEmailField;
        
        private string flagObbNumVouAggField;
        
        private string flagTipoPersField;
        
        private string flagTipologiaVenditaPrtField;
        
        private string flagTipologiaVenditaVouField;
        
        private string flagTourOperatorField;
        
        private string flagVenditaBloccataField;
        
        private string indirizzoField;
        
        private string locNascitaField;
        
        private string localitaField;
        
        private string numeroCelField;
        
        private string numeroFaxField;
        
        private string numeroTel1Field;
        
        private string numeroTel2Field;
        
        private string numeroTel3Field;
        
        private string paeseField;
        
        private string partitaIvaField;
        
        private string prefissoInternazField;
        
        private string provNascitaField;
        
        private string provinciaField;
        
        private string ragioneSocialeField;
        
        private string ragioneSocialeCortaField;
        
        private string sitoField;
        
        private string statoRecordField;
        
        private string swiftField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string abi {
            get {
                return this.abiField;
            }
            set {
                this.abiField = value;
                this.RaisePropertyChanged("abi");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cab {
            get {
                return this.cabField;
            }
            set {
                this.cabField = value;
                this.RaisePropertyChanged("cab");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cap {
            get {
                return this.capField;
            }
            set {
                this.capField = value;
                this.RaisePropertyChanged("cap");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codAgenziaRif {
            get {
                return this.codAgenziaRifField;
            }
            set {
                this.codAgenziaRifField = value;
                this.RaisePropertyChanged("codAgenziaRif");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codBanca {
            get {
                return this.codBancaField;
            }
            set {
                this.codBancaField = value;
                this.RaisePropertyChanged("codBanca");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codBancaClienteCorrispondente {
            get {
                return this.codBancaClienteCorrispondenteField;
            }
            set {
                this.codBancaClienteCorrispondenteField = value;
                this.RaisePropertyChanged("codBancaClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codCategoria {
            get {
                return this.codCategoriaField;
            }
            set {
                this.codCategoriaField = value;
                this.RaisePropertyChanged("codCategoria");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codCheckDigit {
            get {
                return this.codCheckDigitField;
            }
            set {
                this.codCheckDigitField = value;
                this.RaisePropertyChanged("codCheckDigit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codCheckDigitClienteCorrispondente {
            get {
                return this.codCheckDigitClienteCorrispondenteField;
            }
            set {
                this.codCheckDigitClienteCorrispondenteField = value;
                this.RaisePropertyChanged("codCheckDigitClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codCin {
            get {
                return this.codCinField;
            }
            set {
                this.codCinField = value;
                this.RaisePropertyChanged("codCin");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codCinClienteCorrispondente {
            get {
                return this.codCinClienteCorrispondenteField;
            }
            set {
                this.codCinClienteCorrispondenteField = value;
                this.RaisePropertyChanged("codCinClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codClienteCorrispondente {
            get {
                return this.codClienteCorrispondenteField;
            }
            set {
                this.codClienteCorrispondenteField = value;
                this.RaisePropertyChanged("codClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codFiscale {
            get {
                return this.codFiscaleField;
            }
            set {
                this.codFiscaleField = value;
                this.RaisePropertyChanged("codFiscale");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codFornitoreAltroSistema {
            get {
                return this.codFornitoreAltroSistemaField;
            }
            set {
                this.codFornitoreAltroSistemaField = value;
                this.RaisePropertyChanged("codFornitoreAltroSistema");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codGruppo {
            get {
                return this.codGruppoField;
            }
            set {
                this.codGruppoField = value;
                this.RaisePropertyChanged("codGruppo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codModPagamento {
            get {
                return this.codModPagamentoField;
            }
            set {
                this.codModPagamentoField = value;
                this.RaisePropertyChanged("codModPagamento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codNazIsoPerPagamIntrastat {
            get {
                return this.codNazIsoPerPagamIntrastatField;
            }
            set {
                this.codNazIsoPerPagamIntrastatField = value;
                this.RaisePropertyChanged("codNazIsoPerPagamIntrastat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codNazione {
            get {
                return this.codNazioneField;
            }
            set {
                this.codNazioneField = value;
                this.RaisePropertyChanged("codNazione");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codNsBanca {
            get {
                return this.codNsBancaField;
            }
            set {
                this.codNsBancaField = value;
                this.RaisePropertyChanged("codNsBanca");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codNsBancaClienteCorrispondente {
            get {
                return this.codNsBancaClienteCorrispondenteField;
            }
            set {
                this.codNsBancaClienteCorrispondenteField = value;
                this.RaisePropertyChanged("codNsBancaClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codRiconoscimento {
            get {
                return this.codRiconoscimentoField;
            }
            set {
                this.codRiconoscimentoField = value;
                this.RaisePropertyChanged("codRiconoscimento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codValuta {
            get {
                return this.codValutaField;
            }
            set {
                this.codValutaField = value;
                this.RaisePropertyChanged("codValuta");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codZona {
            get {
                return this.codZonaField;
            }
            set {
                this.codZonaField = value;
                this.RaisePropertyChanged("codZona");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string codice {
            get {
                return this.codiceField;
            }
            set {
                this.codiceField = value;
                this.RaisePropertyChanged("codice");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string contoContropartita {
            get {
                return this.contoContropartitaField;
            }
            set {
                this.contoContropartitaField = value;
                this.RaisePropertyChanged("contoContropartita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string contoCorrenteBancario {
            get {
                return this.contoCorrenteBancarioField;
            }
            set {
                this.contoCorrenteBancarioField = value;
                this.RaisePropertyChanged("contoCorrenteBancario");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string contoCorrenteBancarioClienteCorrispondente {
            get {
                return this.contoCorrenteBancarioClienteCorrispondenteField;
            }
            set {
                this.contoCorrenteBancarioClienteCorrispondenteField = value;
                this.RaisePropertyChanged("contoCorrenteBancarioClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cpdc_personalizzato {
            get {
                return this.cpdc_personalizzatoField;
            }
            set {
                this.cpdc_personalizzatoField = value;
                this.RaisePropertyChanged("cpdc_personalizzato");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string cpdc_personalizzatoClienteCorrispondente {
            get {
                return this.cpdc_personalizzatoClienteCorrispondenteField;
            }
            set {
                this.cpdc_personalizzatoClienteCorrispondenteField = value;
                this.RaisePropertyChanged("cpdc_personalizzatoClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string dataNascita {
            get {
                return this.dataNascitaField;
            }
            set {
                this.dataNascitaField = value;
                this.RaisePropertyChanged("dataNascita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string descrizioneBanca {
            get {
                return this.descrizioneBancaField;
            }
            set {
                this.descrizioneBancaField = value;
                this.RaisePropertyChanged("descrizioneBanca");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagAllegatoIva {
            get {
                return this.flagAllegatoIvaField;
            }
            set {
                this.flagAllegatoIvaField = value;
                this.RaisePropertyChanged("flagAllegatoIva");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagAllegatoParadFisc {
            get {
                return this.flagAllegatoParadFiscField;
            }
            set {
                this.flagAllegatoParadFiscField = value;
                this.RaisePropertyChanged("flagAllegatoParadFisc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagGeneraClienteCorrispondente {
            get {
                return this.flagGeneraClienteCorrispondenteField;
            }
            set {
                this.flagGeneraClienteCorrispondenteField = value;
                this.RaisePropertyChanged("flagGeneraClienteCorrispondente");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagInvioDocEmail {
            get {
                return this.flagInvioDocEmailField;
            }
            set {
                this.flagInvioDocEmailField = value;
                this.RaisePropertyChanged("flagInvioDocEmail");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagObbNumVouAgg {
            get {
                return this.flagObbNumVouAggField;
            }
            set {
                this.flagObbNumVouAggField = value;
                this.RaisePropertyChanged("flagObbNumVouAgg");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagTipoPers {
            get {
                return this.flagTipoPersField;
            }
            set {
                this.flagTipoPersField = value;
                this.RaisePropertyChanged("flagTipoPers");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagTipologiaVenditaPrt {
            get {
                return this.flagTipologiaVenditaPrtField;
            }
            set {
                this.flagTipologiaVenditaPrtField = value;
                this.RaisePropertyChanged("flagTipologiaVenditaPrt");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagTipologiaVenditaVou {
            get {
                return this.flagTipologiaVenditaVouField;
            }
            set {
                this.flagTipologiaVenditaVouField = value;
                this.RaisePropertyChanged("flagTipologiaVenditaVou");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagTourOperator {
            get {
                return this.flagTourOperatorField;
            }
            set {
                this.flagTourOperatorField = value;
                this.RaisePropertyChanged("flagTourOperator");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string flagVenditaBloccata {
            get {
                return this.flagVenditaBloccataField;
            }
            set {
                this.flagVenditaBloccataField = value;
                this.RaisePropertyChanged("flagVenditaBloccata");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string indirizzo {
            get {
                return this.indirizzoField;
            }
            set {
                this.indirizzoField = value;
                this.RaisePropertyChanged("indirizzo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string locNascita {
            get {
                return this.locNascitaField;
            }
            set {
                this.locNascitaField = value;
                this.RaisePropertyChanged("locNascita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string localita {
            get {
                return this.localitaField;
            }
            set {
                this.localitaField = value;
                this.RaisePropertyChanged("localita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string numeroCel {
            get {
                return this.numeroCelField;
            }
            set {
                this.numeroCelField = value;
                this.RaisePropertyChanged("numeroCel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string numeroFax {
            get {
                return this.numeroFaxField;
            }
            set {
                this.numeroFaxField = value;
                this.RaisePropertyChanged("numeroFax");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string numeroTel1 {
            get {
                return this.numeroTel1Field;
            }
            set {
                this.numeroTel1Field = value;
                this.RaisePropertyChanged("numeroTel1");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string numeroTel2 {
            get {
                return this.numeroTel2Field;
            }
            set {
                this.numeroTel2Field = value;
                this.RaisePropertyChanged("numeroTel2");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string numeroTel3 {
            get {
                return this.numeroTel3Field;
            }
            set {
                this.numeroTel3Field = value;
                this.RaisePropertyChanged("numeroTel3");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string paese {
            get {
                return this.paeseField;
            }
            set {
                this.paeseField = value;
                this.RaisePropertyChanged("paese");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string partitaIva {
            get {
                return this.partitaIvaField;
            }
            set {
                this.partitaIvaField = value;
                this.RaisePropertyChanged("partitaIva");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string prefissoInternaz {
            get {
                return this.prefissoInternazField;
            }
            set {
                this.prefissoInternazField = value;
                this.RaisePropertyChanged("prefissoInternaz");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string provNascita {
            get {
                return this.provNascitaField;
            }
            set {
                this.provNascitaField = value;
                this.RaisePropertyChanged("provNascita");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string provincia {
            get {
                return this.provinciaField;
            }
            set {
                this.provinciaField = value;
                this.RaisePropertyChanged("provincia");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ragioneSociale {
            get {
                return this.ragioneSocialeField;
            }
            set {
                this.ragioneSocialeField = value;
                this.RaisePropertyChanged("ragioneSociale");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ragioneSocialeCorta {
            get {
                return this.ragioneSocialeCortaField;
            }
            set {
                this.ragioneSocialeCortaField = value;
                this.RaisePropertyChanged("ragioneSocialeCorta");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string sito {
            get {
                return this.sitoField;
            }
            set {
                this.sitoField = value;
                this.RaisePropertyChanged("sito");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string statoRecord {
            get {
                return this.statoRecordField;
            }
            set {
                this.statoRecordField = value;
                this.RaisePropertyChanged("statoRecord");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string swift {
            get {
                return this.swiftField;
            }
            set {
                this.swiftField = value;
                this.RaisePropertyChanged("swift");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://Strutture.Anagrafiche.APWebServices")]
    public partial class StructAnaFornitoreIn : object, System.ComponentModel.INotifyPropertyChanged {
        
        private StructAnaFornitore iAnaFornitoreField;
        
        private string iAzioneField;
        
        private string provenienzaField;
        
        private string[] vModRicercaField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public StructAnaFornitore IAnaFornitore {
            get {
                return this.iAnaFornitoreField;
            }
            set {
                this.iAnaFornitoreField = value;
                this.RaisePropertyChanged("IAnaFornitore");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string IAzione {
            get {
                return this.iAzioneField;
            }
            set {
                this.iAzioneField = value;
                this.RaisePropertyChanged("IAzione");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string provenienza {
            get {
                return this.provenienzaField;
            }
            set {
                this.provenienzaField = value;
                this.RaisePropertyChanged("provenienza");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string[] vModRicerca {
            get {
                return this.vModRicercaField;
            }
            set {
                this.vModRicercaField = value;
                this.RaisePropertyChanged("vModRicerca");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebServicesFornitoreChannel : SiapWebServices_Library.WebServicesFornitoreService.WebServicesFornitore, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServicesFornitoreClient : System.ServiceModel.ClientBase<SiapWebServices_Library.WebServicesFornitoreService.WebServicesFornitore>, SiapWebServices_Library.WebServicesFornitoreService.WebServicesFornitore {
        
        public WebServicesFornitoreClient() {
        }
        
        public WebServicesFornitoreClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServicesFornitoreClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicesFornitoreClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServicesFornitoreClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreOut gestioneAnagraficaFornitore(SiapWebServices_Library.WebServicesFornitoreService.StructLogin iLogin, SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreIn iAnaFornitoreIn) {
            return base.Channel.gestioneAnagraficaFornitore(iLogin, iAnaFornitoreIn);
        }
        
        public System.Threading.Tasks.Task<SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreOut> gestioneAnagraficaFornitoreAsync(SiapWebServices_Library.WebServicesFornitoreService.StructLogin iLogin, SiapWebServices_Library.WebServicesFornitoreService.StructAnaFornitoreIn iAnaFornitoreIn) {
            return base.Channel.gestioneAnagraficaFornitoreAsync(iLogin, iAnaFornitoreIn);
        }
    }
}
