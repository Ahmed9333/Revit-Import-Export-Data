using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;

namespace cloudDB
{
    public class FireAlarmDevicesData : FireAlarmDevices
    {

        /// DoorData constructor to generate the data to serialise for REST POST request.

        public FireAlarmDevicesData(Element fireAlarmDevices)
        {
            //Get FireAlarmDevices Finish parameter
            Parameter SYMBVISIODEF = fireAlarmDevices.LookupParameter(name:"SYMB_VISIODEF");
            string SybVisoDef;

            //Check if Door Finish Paramater has a value
            if (SYMBVISIODEF.HasValue == true)
            {
                SybVisoDef = SYMBVISIODEF.AsString();
            }
            else
            {
                SybVisoDef = "";
            }

            _id = fireAlarmDevices.UniqueId;
            FamilyType = fireAlarmDevices.Name;
            ADRESSE = fireAlarmDevices.LookupParameter("ADRESSE").AsString();
            CENTRALE = fireAlarmDevices.LookupParameter("CENTRALE").AsString();
            GEST_HOR = fireAlarmDevices.LookupParameter("GEST_HOR").AsString();
            IA = fireAlarmDevices.LookupParameter("IA").AsString();
            ID_OPC = fireAlarmDevices.LookupParameter("ID_OPC").AsString();
            LIBELLE = fireAlarmDevices.LookupParameter("LIBELLE").AsString();
            LIBELLEZONE = fireAlarmDevices.LookupParameter("LIBELLEZONE").AsString();
            LIBELLE_BASE = fireAlarmDevices.LookupParameter("LIBELLE_BASE").AsString();
            METIER = fireAlarmDevices.LookupParameter("METIER").AsString();
            ORDRE_CABLAGE = fireAlarmDevices.LookupParameter("ORDRE_CABLAGE").AsString();
            SENSIBILITE = fireAlarmDevices.LookupParameter("SENSIBILITE").AsString();
            SYMB_GRAPH = fireAlarmDevices.LookupParameter("SYMB_GRAPH").AsString();
            VARIANTE = fireAlarmDevices.LookupParameter("VARIANTE").AsString();
            ZONE = fireAlarmDevices.LookupParameter("ZONE").AsString();
        }

    }
}
