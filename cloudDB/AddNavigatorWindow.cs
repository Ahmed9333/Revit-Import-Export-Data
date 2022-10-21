using System;
using System.Reflection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using System.Windows.Controls;

namespace cloudDB
{
    [Transaction(TransactionMode.ReadOnly)]

    public class AddNavigatorWindow : IExternalCommand
    {
        

        // Show Dockable dialog
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DockablePaneId dpid = new DockablePaneId(new Guid("{41C7A686-1F30-49BE-A9BC-05EF09F5E64F}"));
            DockablePane dp = commandData.Application.GetDockablePane(dpid);
            dp.Show();
            return Result.Succeeded;
        }
    }
}
