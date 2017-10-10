﻿// 
// Main website for TVRename is http://tvrename.com
// 
// Source code available at http://code.google.com/p/tvrename/
// 
// This code is released under GPLv3 http://www.gnu.org/licenses/gpl.html
// 

// 
// The initial version of this source code was auto-generated by xsd, Version=2.0.50727.1432.
// 
// Save http://localhost:8080/sabnzbd/api?mode=queue&apikey=...&start=0&limit=9999&output=xml as sab.xml
// xsd.exe sab.xml
// xsd.exe sab.xsd /c /edb

using System;
using Alphaleonis.Win32.Filesystem;
using System.Xml.Serialization;
using System.IO;

namespace TVRename.SAB
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class queue : object, System.ComponentModel.INotifyPropertyChanged
    {
        public static queue Deserialize(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            XmlSerializer serializer = new XmlSerializer(typeof (queue));
            try
            {
                queue r = (queue) serializer.Deserialize(ms);
                return r;
            }
            catch
            {
                return null;
            }
        }

        private string uniconfigField;

        private string cache_sizeField;

        private string active_langField;

        private string pausedField;

        private string sessionField;

        private string restart_reqField;

        private string power_optionsField;

        private string speedField;

        private string helpuriField;

        private string sizeField;

        private string uptimeField;

        private string refresh_rateField;

        private string my_homeField;

        private string limitField;

        private string have_quotaField;

        private string isverboseField;

        private string startField;

        private string finishField;

        private string versionField;

        private string new_rel_urlField;

        private string my_lcldataField;

        private string color_schemeField;

        private string diskspacetotal1Field;

        private string ntField;

        private string statusField;

        private string last_warningField;

        private string have_warningsField;

        private string cache_artField;

        private string sizeleftField;

        private string finishactionField;

        private string paused_allField;

        private string quotaField;

        private string newzbin_urlField;

        private string new_releaseField;

        private string pause_intField;

        private string mbleftField;

        private string diskspace1Field;

        private string scriptsField;

        private string darwinField;

        private string timeleftField;

        private string mbField;

        private string noofslotsField;

        private string etaField;

        private string diskspacetotal2Field;

        private string nzb_quotaField;

        private string loadavgField;

        private string cache_maxField;

        private string kbpersecField;

        private string speedlimitField;

        private string webdirField;

        private string queue_detailsField;

        private string left_quotaField;

        private string diskspace2Field;

        private queueSlotsSlot[] slotsField;

        private queueCategories[] categoriesField;

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uniconfig
        {
            get { return this.uniconfigField; }
            set
            {
                this.uniconfigField = value;
                this.RaisePropertyChanged("uniconfig");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cache_size
        {
            get { return this.cache_sizeField; }
            set
            {
                this.cache_sizeField = value;
                this.RaisePropertyChanged("cache_size");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string active_lang
        {
            get { return this.active_langField; }
            set
            {
                this.active_langField = value;
                this.RaisePropertyChanged("active_lang");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string paused
        {
            get { return this.pausedField; }
            set
            {
                this.pausedField = value;
                this.RaisePropertyChanged("paused");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string session
        {
            get { return this.sessionField; }
            set
            {
                this.sessionField = value;
                this.RaisePropertyChanged("session");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string restart_req
        {
            get { return this.restart_reqField; }
            set
            {
                this.restart_reqField = value;
                this.RaisePropertyChanged("restart_req");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string power_options
        {
            get { return this.power_optionsField; }
            set
            {
                this.power_optionsField = value;
                this.RaisePropertyChanged("power_options");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string speed
        {
            get { return this.speedField; }
            set
            {
                this.speedField = value;
                this.RaisePropertyChanged("speed");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string helpuri
        {
            get { return this.helpuriField; }
            set
            {
                this.helpuriField = value;
                this.RaisePropertyChanged("helpuri");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string size
        {
            get { return this.sizeField; }
            set
            {
                this.sizeField = value;
                this.RaisePropertyChanged("size");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string uptime
        {
            get { return this.uptimeField; }
            set
            {
                this.uptimeField = value;
                this.RaisePropertyChanged("uptime");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string refresh_rate
        {
            get { return this.refresh_rateField; }
            set
            {
                this.refresh_rateField = value;
                this.RaisePropertyChanged("refresh_rate");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string my_home
        {
            get { return this.my_homeField; }
            set
            {
                this.my_homeField = value;
                this.RaisePropertyChanged("my_home");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string limit
        {
            get { return this.limitField; }
            set
            {
                this.limitField = value;
                this.RaisePropertyChanged("limit");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string have_quota
        {
            get { return this.have_quotaField; }
            set
            {
                this.have_quotaField = value;
                this.RaisePropertyChanged("have_quota");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string isverbose
        {
            get { return this.isverboseField; }
            set
            {
                this.isverboseField = value;
                this.RaisePropertyChanged("isverbose");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string start
        {
            get { return this.startField; }
            set
            {
                this.startField = value;
                this.RaisePropertyChanged("start");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string finish
        {
            get { return this.finishField; }
            set
            {
                this.finishField = value;
                this.RaisePropertyChanged("finish");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string version
        {
            get { return this.versionField; }
            set
            {
                this.versionField = value;
                this.RaisePropertyChanged("version");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string new_rel_url
        {
            get { return this.new_rel_urlField; }
            set
            {
                this.new_rel_urlField = value;
                this.RaisePropertyChanged("new_rel_url");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string my_lcldata
        {
            get { return this.my_lcldataField; }
            set
            {
                this.my_lcldataField = value;
                this.RaisePropertyChanged("my_lcldata");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string color_scheme
        {
            get { return this.color_schemeField; }
            set
            {
                this.color_schemeField = value;
                this.RaisePropertyChanged("color_scheme");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string diskspacetotal1
        {
            get { return this.diskspacetotal1Field; }
            set
            {
                this.diskspacetotal1Field = value;
                this.RaisePropertyChanged("diskspacetotal1");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nt
        {
            get { return this.ntField; }
            set
            {
                this.ntField = value;
                this.RaisePropertyChanged("nt");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string status
        {
            get { return this.statusField; }
            set
            {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string last_warning
        {
            get { return this.last_warningField; }
            set
            {
                this.last_warningField = value;
                this.RaisePropertyChanged("last_warning");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string have_warnings
        {
            get { return this.have_warningsField; }
            set
            {
                this.have_warningsField = value;
                this.RaisePropertyChanged("have_warnings");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cache_art
        {
            get { return this.cache_artField; }
            set
            {
                this.cache_artField = value;
                this.RaisePropertyChanged("cache_art");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sizeleft
        {
            get { return this.sizeleftField; }
            set
            {
                this.sizeleftField = value;
                this.RaisePropertyChanged("sizeleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string finishaction
        {
            get { return this.finishactionField; }
            set
            {
                this.finishactionField = value;
                this.RaisePropertyChanged("finishaction");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string paused_all
        {
            get { return this.paused_allField; }
            set
            {
                this.paused_allField = value;
                this.RaisePropertyChanged("paused_all");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string quota
        {
            get { return this.quotaField; }
            set
            {
                this.quotaField = value;
                this.RaisePropertyChanged("quota");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string newzbin_url
        {
            get { return this.newzbin_urlField; }
            set
            {
                this.newzbin_urlField = value;
                this.RaisePropertyChanged("newzbin_url");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string new_release
        {
            get { return this.new_releaseField; }
            set
            {
                this.new_releaseField = value;
                this.RaisePropertyChanged("new_release");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string pause_int
        {
            get { return this.pause_intField; }
            set
            {
                this.pause_intField = value;
                this.RaisePropertyChanged("pause_int");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mbleft
        {
            get { return this.mbleftField; }
            set
            {
                this.mbleftField = value;
                this.RaisePropertyChanged("mbleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string diskspace1
        {
            get { return this.diskspace1Field; }
            set
            {
                this.diskspace1Field = value;
                this.RaisePropertyChanged("diskspace1");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string scripts
        {
            get { return this.scriptsField; }
            set
            {
                this.scriptsField = value;
                this.RaisePropertyChanged("scripts");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string darwin
        {
            get { return this.darwinField; }
            set
            {
                this.darwinField = value;
                this.RaisePropertyChanged("darwin");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string timeleft
        {
            get { return this.timeleftField; }
            set
            {
                this.timeleftField = value;
                this.RaisePropertyChanged("timeleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string mb
        {
            get { return this.mbField; }
            set
            {
                this.mbField = value;
                this.RaisePropertyChanged("mb");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string noofslots
        {
            get { return this.noofslotsField; }
            set
            {
                this.noofslotsField = value;
                this.RaisePropertyChanged("noofslots");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string eta
        {
            get { return this.etaField; }
            set
            {
                this.etaField = value;
                this.RaisePropertyChanged("eta");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string diskspacetotal2
        {
            get { return this.diskspacetotal2Field; }
            set
            {
                this.diskspacetotal2Field = value;
                this.RaisePropertyChanged("diskspacetotal2");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nzb_quota
        {
            get { return this.nzb_quotaField; }
            set
            {
                this.nzb_quotaField = value;
                this.RaisePropertyChanged("nzb_quota");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string loadavg
        {
            get { return this.loadavgField; }
            set
            {
                this.loadavgField = value;
                this.RaisePropertyChanged("loadavg");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cache_max
        {
            get { return this.cache_maxField; }
            set
            {
                this.cache_maxField = value;
                this.RaisePropertyChanged("cache_max");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kbpersec
        {
            get { return this.kbpersecField; }
            set
            {
                this.kbpersecField = value;
                this.RaisePropertyChanged("kbpersec");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string speedlimit
        {
            get { return this.speedlimitField; }
            set
            {
                this.speedlimitField = value;
                this.RaisePropertyChanged("speedlimit");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string webdir
        {
            get { return this.webdirField; }
            set
            {
                this.webdirField = value;
                this.RaisePropertyChanged("webdir");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string queue_details
        {
            get { return this.queue_detailsField; }
            set
            {
                this.queue_detailsField = value;
                this.RaisePropertyChanged("queue_details");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string left_quota
        {
            get { return this.left_quotaField; }
            set
            {
                this.left_quotaField = value;
                this.RaisePropertyChanged("left_quota");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string diskspace2
        {
            get { return this.diskspace2Field; }
            set
            {
                this.diskspace2Field = value;
                this.RaisePropertyChanged("diskspace2");
            }
        }

       
        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("slot", typeof (queueSlotsSlot),
            Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public queueSlotsSlot[] slots
        {
            get { return this.slotsField; }
            set
            {
                this.slotsField = value;
                this.RaisePropertyChanged("slots");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute("categories", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public queueCategories[] categories
        {
            get { return this.categoriesField; }
            set
            {
                this.categoriesField = value;
                this.RaisePropertyChanged("categories");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class queueSlotsSlot : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string statusField;

        private string indexField;

        private string etaField;

        private string missingField;

        private string avg_ageField;

        private string scriptField;

        private string msgidField;

        private string verbosityField;

        private double mbField;

        private string sizeleftField;

        private string filenameField;

        private string priorityField;

        private string catField;

        private double mbleftField;

        private string timeleftField;

        private string percentageField;

        private string nzo_idField;

        private string unpackoptsField;

        private string sizeField;

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string status
        {
            get { return this.statusField; }
            set
            {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string index
        {
            get { return this.indexField; }
            set
            {
                this.indexField = value;
                this.RaisePropertyChanged("index");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string eta
        {
            get { return this.etaField; }
            set
            {
                this.etaField = value;
                this.RaisePropertyChanged("eta");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string missing
        {
            get { return this.missingField; }
            set
            {
                this.missingField = value;
                this.RaisePropertyChanged("missing");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string avg_age
        {
            get { return this.avg_ageField; }
            set
            {
                this.avg_ageField = value;
                this.RaisePropertyChanged("avg_age");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string script
        {
            get { return this.scriptField; }
            set
            {
                this.scriptField = value;
                this.RaisePropertyChanged("script");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string msgid
        {
            get { return this.msgidField; }
            set
            {
                this.msgidField = value;
                this.RaisePropertyChanged("msgid");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string verbosity
        {
            get { return this.verbosityField; }
            set
            {
                this.verbosityField = value;
                this.RaisePropertyChanged("verbosity");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double mb
        {
            get { return this.mbField; }
            set
            {
                this.mbField = value;
                this.RaisePropertyChanged("mb");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sizeleft
        {
            get { return this.sizeleftField; }
            set
            {
                this.sizeleftField = value;
                this.RaisePropertyChanged("sizeleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string filename
        {
            get { return this.filenameField; }
            set
            {
                this.filenameField = value;
                this.RaisePropertyChanged("filename");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string priority
        {
            get { return this.priorityField; }
            set
            {
                this.priorityField = value;
                this.RaisePropertyChanged("priority");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string cat
        {
            get { return this.catField; }
            set
            {
                this.catField = value;
                this.RaisePropertyChanged("cat");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double mbleft
        {
            get { return this.mbleftField; }
            set
            {
                this.mbleftField = value;
                this.RaisePropertyChanged("mbleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string timeleft
        {
            get { return this.timeleftField; }
            set
            {
                this.timeleftField = value;
                this.RaisePropertyChanged("timeleft");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string percentage
        {
            get { return this.percentageField; }
            set
            {
                this.percentageField = value;
                this.RaisePropertyChanged("percentage");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nzo_id
        {
            get { return this.nzo_idField; }
            set
            {
                this.nzo_idField = value;
                this.RaisePropertyChanged("nzo_id");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string unpackopts
        {
            get { return this.unpackoptsField; }
            set
            {
                this.unpackoptsField = value;
                this.RaisePropertyChanged("unpackopts");
            }
        }

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string size
        {
            get { return this.sizeField; }
            set
            {
                this.sizeField = value;
                this.RaisePropertyChanged("size");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class queueCategories : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string categoryField;

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string category
        {
            get { return this.categoryField; }
            set
            {
                this.categoryField = value;
                this.RaisePropertyChanged("category");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class result : object, System.ComponentModel.INotifyPropertyChanged
    {
        public static result Deserialize(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            XmlSerializer serializer = new XmlSerializer(typeof(result));
            try
            {
                result r = (result)serializer.Deserialize(ms);
                return r;
            }
            catch
            {
                return null;
            }
        }

        private string statusField;
        private string errorField;

       
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string status
        {
            get { return this.statusField; }
            set
            {
                this.statusField = value;
                this.RaisePropertyChanged("status");
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string error
        {
            get { return this.errorField; }
            set
            {
                this.errorField = value;
                this.RaisePropertyChanged("error");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class NewDataSet : object, System.ComponentModel.INotifyPropertyChanged
    {

        private queue[] itemsField;

       
        [System.Xml.Serialization.XmlElementAttribute("queue")]
        public queue[] Items
        {
            get { return this.itemsField; }
            set
            {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
} // namespace