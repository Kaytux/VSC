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
        public Navigator Nav => (App.Current as App).Navigator;
        public UCArmes()
        {
            InitializeComponent();
            DataContext = Mgr;
            if(Mgr.ArmeSélectionné as ArmeActive == default)
            {
                Mgr.ArmeSélectionné = Mgr.LesArmesActives[0];
            }
            Mgr.StatsSelectionne = Mgr.ArmeSélectionné.stats.ToList();
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mgr.StatsSelectionne = Mgr.ArmeSélectionné.stats.ToList();
            Mgr.ArmeSélectionné = e.AddedItems[0] as ArmeActive;
        }

        private void Passive_Click(object sender,RoutedEventArgs e)
        {
            Mgr.ArmeSélectionné = (Mgr.ArmeSélectionné as ArmeActive).ArmePass;
            Nav.NavigateTo(Navigator.PART_ARMES, Navigator.PART_PASS);
        }

        private void Amelio_Click(object sender, RoutedEventArgs e)
        {
            Mgr.ArmeSélectionné = (Mgr.ArmeSélectionné as ArmeActive).Amelioration;
            Nav.NavigateTo(Navigator.PART_ARMES,Navigator.PART_AMELIO);
        }
    }
}
