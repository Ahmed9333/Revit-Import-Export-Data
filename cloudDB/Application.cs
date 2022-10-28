using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using System.IO;

namespace cloudDB
{
    //// Implements the Revit add-in interface IExternalApplication
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Application : IExternalApplication
    {

        /// Implements the OnShutdown event
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        /// Implements the OnStartup event
        public Result OnStartup(UIControlledApplication application)
        {
            // Creat the first split button ImportData and ExportData
            // First button's commands are defined in the split buttons creation
            RibbonPanel panel = RibbonPanel(application);
            AddSplitButtonGroup(panel);

            // Creat button to show Navigator Window
            RibbonPanel panel2 = RibbonPanel(application);
            string thisAssemblyPath2 = Assembly.GetExecutingAssembly().Location;
            if (panel2.AddItem(new PushButtonData("test Chrome Web Browser", "test Chrome Web Browser", thisAssemblyPath2, "cloudDB.ActiveViewManager"))
                is PushButton button2 )
            {
                button2.ToolTip = "test Navigator window";
                Uri uri = new Uri(@"C:\Users\ahmed\source\repos\Revit-Import-Export-Data\cloudDB\Resources\navigator.ico");
                BitmapImage bitmapImage = new BitmapImage(uri);
                button2.LargeImage = bitmapImage;
            }

            // Creat split button ImportData and ExportData: Fire Alram Device
            RibbonPanel panel3 = RibbonPanel(application);
            string thisAssemblyPath3 = Assembly.GetExecutingAssembly().Location;
            if (panel3.AddItem(new PushButtonData("Fire Alram Device Export", "Fire Alram Device Export", thisAssemblyPath3, "cloudDB.TestHello"))
                is PushButton button3)
            {
                button3.ToolTip = "Show Data to Export";

                Uri uri = new Uri(@"C:\Users\ahmed\source\repos\Revit-Import-Export-Data\cloudDB\Resources\element_properties.ico");
                BitmapImage bitmapImage = new BitmapImage(uri);
                button3.LargeImage = bitmapImage;
            }

            return Result.Succeeded;
        }

        /// Adds split button group with two push buttons: one to export door data and the other to import door data 
        private void AddSplitButtonGroup(RibbonPanel panel)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            SplitButtonData sbData = new SplitButtonData("SplitGroup", "SplitGroup");
            SplitButton splitButton = panel.AddItem(sbData) as SplitButton;

            PushButtonData exportData = new PushButtonData("ExportFireAlarmDevicesData", "ExportFireAlarmDevicesData", thisAssemblyPath, "cloudDB.ExportFireAlarmDevicesData");
            PushButton exportButton = splitButton.AddPushButton(exportData);
            exportButton.ToolTip = "Export Revit Fire Alarm Devices Data";

            Uri exportUri = new Uri(Path.Combine(Path.GetDirectoryName(thisAssemblyPath), "Resources", "mongoExp.ico"));
            BitmapImage expBitmapImage = new BitmapImage(exportUri);
            exportButton.LargeImage = expBitmapImage;

            splitButton.AddSeparator();

            PushButtonData importData = new PushButtonData("ImportDoorData", "ImportDoorData", thisAssemblyPath, "cloudDB.ImportCommand");
            PushButton importButton = splitButton.AddPushButton(importData);
            importButton.ToolTip = "Import Revit Door Data";

            Uri importUri = new Uri(Path.Combine(Path.GetDirectoryName(thisAssemblyPath), "Resources", "mongoImp.ico"));
            BitmapImage impBitmapImage = new BitmapImage(importUri);
            importButton.LargeImage = impBitmapImage;

        }

        /// Adds split button group with two push buttons: one to export FireAlarmDevices data and the other to import FireAlarmDevices data 
        private void AddSplitButtonGroupFireAlarmDevices(RibbonPanel panel1)
        {
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            SplitButtonData sbData = new SplitButtonData("SplitGroup", "SplitGroup");
            SplitButton splitButton = panel1.AddItem(sbData) as SplitButton;

            PushButtonData exportData = new PushButtonData("ExportFireAlarmDevicesData", "ExportFireAlarmDevicesData", thisAssemblyPath, "cloudDB.ExportCommandFireAlarmDevices");
            PushButton exportButton = splitButton.AddPushButton(exportData);
            exportButton.ToolTip = "Export Revit FireAlarmDevices Data";

            Uri exportUri = new Uri(Path.Combine(Path.GetDirectoryName(thisAssemblyPath), "Resources", "mongoExp.ico"));
            BitmapImage expBitmapImage = new BitmapImage(exportUri);
            exportButton.LargeImage = expBitmapImage;

            splitButton.AddSeparator();

            PushButtonData importData = new PushButtonData("ImportFireAlarmDevicesData", "ImportFireAlarmDevicesData", thisAssemblyPath, "cloudDB.ImportCommandFireAlarmDevices");
            PushButton importButton = splitButton.AddPushButton(importData);
            importButton.ToolTip = "Import Revit FireAlarmDevices Data";

            Uri importUri = new Uri(Path.Combine(Path.GetDirectoryName(thisAssemblyPath), "Resources", "mongoImp.ico"));
            BitmapImage impBitmapImage = new BitmapImage(importUri);
            importButton.LargeImage = impBitmapImage;

        }

        /// Function creates "Export/Import Data" tab and "Export & Import Data" ribbon panel

        public RibbonPanel RibbonPanel(UIControlledApplication a)
        {
            // Tab name
            string tab = "Export/Import Data";
            // Empty ribbon panel 
            RibbonPanel RibbonPanel = null;

            //Create ribbon Tab
            try
            {
                a.CreateRibbonTab(tab);
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.Message, ex.ToString());
            }

            //Create ribbon panel
            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tab, "Export & Import Data");
            }
            catch (Exception ex)
            {
                TaskDialog.Show(ex.Message, ex.ToString());
                // Or "Debug.WriteLine(ex.Message);" to create a dialog box with C#
                // TaskDialog.Show is a revit API
            }

            // Search existing tab for your panel.
            List<RibbonPanel> panels = a.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels.Where(p => p.Name == "Export & Import Data"))
            {
                RibbonPanel = p;
            }

            return RibbonPanel;
        }


    }
}
