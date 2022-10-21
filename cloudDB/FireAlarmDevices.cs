using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace cloudDB
{

    /// FireAlarmDevices class with get/set autoproperties

    public class FireAlarmDevices
    {
        public string _id { get; set; }
        public string FamilyType { get; set; }
        public string Mark { get; set; }
        public string Name { get; set; }
        public string OwnerViewld { get; set; }
        public string SYMB_VISIODEF { get; set; }
        public string ADRESSE { get; set; }
        public string CENTRALE { get; set; }
        public string GEST_HOR { get; set; }
        public string IA { get; set; }
        public string ID_OPC { get; set; }
        public string LIBELLE { get; set; }
        public string LIBELLEZONE { get; set; }
        public string LIBELLE_BASE { get; set; }
        public string METIER { get; set; }
        public string ORDRE_CABLAGE { get; set; }
        public string SENSIBILITE { get; set; }
        public string SYMB_GRAPH { get; set; }
        public string VARIANTE { get; set; }
        public string ZONE { get; set; }

    }
}
