#region NameSpace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace InsulationTool
{
    /// <summary>
    /// Interaction logic for InsulationWPF.xaml
    /// </summary>
    public partial class InsulationWPF : Window
    {
        UIDocument uidoc;
        Document doc;
        IList<Element> syspi;
        IList<Element> sysdt;


        public InsulationWPF(UIDocument uidoc)
        {
            InitializeComponent();
            this.uidoc = uidoc;
            doc = uidoc.Document;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IList<Element> level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .ToElements();

            syspi = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_PipingSystem)
                .WhereElementIsElementType()
                .ToElements();

            sysdt = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_DuctSystem)
                .WhereElementIsElementType()
                .ToElements();


            comlv.SelectedIndex = 0;
            comlv.ItemsSource = level;
            comlv.DisplayMemberPath = "Name";

            comsys.ItemsSource = sysdt;
            comsys.DisplayMemberPath = "Name";

        }

        private void butCan_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void raMa_Click(object sender, RoutedEventArgs e)
        {
            visFil(false);
        }

        private void raAu_Click(object sender, RoutedEventArgs e)
        {
            visFil(true);
        }

        public void visFil(bool a)
        {
            if(a == true)
            {
                comlv.IsEnabled = true;
                comsys.IsEnabled = true;
            }
            else
            {
                comlv.IsEnabled = false;
                comsys.IsEnabled = false;
            }
        }

        private void raDt_Click(object sender, RoutedEventArgs e)
        {
            comsys.ItemsSource = sysdt;
            comsys.DisplayMemberPath = "Name";
        }

        private void raPi_Click(object sender, RoutedEventArgs e)
        {
            comsys.ItemsSource = sysdt;
            comsys.DisplayMemberPath = "Name";
        }
    }
}
