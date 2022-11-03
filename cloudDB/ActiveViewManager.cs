using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace cloudDB
{
    [Transaction (TransactionMode.Manual)]

    public class ActiveViewManager : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                var v = doc.ActiveView;
                var vName = v.Name;

                MainWindow window = new MainWindow(uidoc);
                window.label_Name.Content = $"Name: {vName}";

                window.ShowDialog();

                return Result.Succeeded;
            }

            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
