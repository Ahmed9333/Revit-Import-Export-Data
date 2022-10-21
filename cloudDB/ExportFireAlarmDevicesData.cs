using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Net;


namespace cloudDB
{

    /// Implements the Revit add-in interface IExternalCommand

    [Transaction(TransactionMode.ReadOnly)]
    public class ExportFireAlarmDevicesData : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get the Current Session / Project from Revit
            UIApplication uiapp = commandData.Application;

            //Get the Current Document from the Current Session
            Document doc = uiapp.ActiveUIDocument.Document;

            //Get all Fire Alarm Devices from project
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_FireAlarmDevices);

            Result result = ExportBatch(collector, ref message);

            if (result == Result.Succeeded)
            {
                TaskDialog.Show("Fire Alarm Devices Data Export", "Fire Alarm Devices Data successfuly exported");
            }
            else
            {
                TaskDialog.Show("Fire Alarm Devices Data Export", "Something went wrong...");
            }

            return result;

        }


        /// Function to batch export Fire Alarm Devices Data
        public static Result ExportBatch(FilteredElementCollector equipements, ref string message)
        {
            List<FireAlarmDevices> fireAlarmData = new List<FireAlarmDevices>();

            HttpStatusCode statusCode;
            string jsonResponse, errorMessage;
            Result result = Result.Succeeded;

            foreach (Element element in equipements)
            {
                fireAlarmData.Add(new FireAlarmDevicesData(element));
            }

            //REST request to batch post Fire Alarm Devices data
            statusCode = FireAlarmDevicesAPI.PostBatch(out jsonResponse, out errorMessage, "equipements", fireAlarmData);

            if ((int)statusCode == 0)
            {
                message = errorMessage;
                result = Result.Failed;
            }

            return result;

        }


    }
}
