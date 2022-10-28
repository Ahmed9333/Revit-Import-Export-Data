
using System.Windows;
using Autodesk.Revit.Creation;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Document = Autodesk.Revit.DB.Document;

namespace cloudDB
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UIDocument uidoc { get; } 
        public Document doc { get; }
        public MainWindow(UIDocument UiDoc)
        {
            uidoc = UiDoc;
            doc = UiDoc.Document;
            InitializeComponent();
            Title = "TEST FOR REVIT INTEGRATION";
        }

    }
}
