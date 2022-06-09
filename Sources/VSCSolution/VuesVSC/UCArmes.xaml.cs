using BibliothequeClassesVSC;
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

namespace VuesVSC
{
    /// <summary>
    /// Interaction logic for Passive2.xaml
    /// </summary>
    public partial class UCArmes : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        
        public Navigator Navigator => (App.Current as App).Navigator;
        public UCArmes()
        {
            InitializeComponent();
            DataContext = Mgr;
        }
        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mgr.ArmeSélectionné = e.AddedItems[0] as ArmeActive;
        }

        private void ArmesPassives_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo(Navigator.PART_ARMES_PASSIVES);
        }

    }
}
