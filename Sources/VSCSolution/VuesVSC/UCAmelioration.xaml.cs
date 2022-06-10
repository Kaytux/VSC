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
    /// Interaction logic for UCAmelioration.xaml
    /// </summary>
    public partial class UCAmelioration : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        public Navigator Nav => (App.Current as App).Navigator;
        public UCAmelioration()
        {
            InitializeComponent();
            DataContext = Mgr;
            if (Mgr.ArmeSélectionné as Amelioration == default)
            {
                Mgr.ArmeSélectionné = Mgr.LesAmeliorations[0];
            }
            Mgr.StatsSelectionne = Mgr.ArmeSélectionné.stats.ToList();
        }
        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mgr.ArmeSélectionné = e.AddedItems[0] as Arme;
            Mgr.StatsSelectionne = Mgr.ArmeSélectionné.stats.ToList();
        }
        private void Passive_Click(object sender, RoutedEventArgs e)
        {
            Mgr.ArmeSélectionné = (Mgr.ArmeSélectionné as Amelioration).ArmePass;
            Nav.NavigateTo(Navigator.PART_ARMES, Navigator.PART_PASS);
        }

        private void Active_Click(object sender, RoutedEventArgs e)
        {
            Mgr.ArmeSélectionné = (Mgr.ArmeSélectionné as Amelioration).ArmeAct;
            Nav.NavigateTo(Navigator.PART_ARMES, Navigator.PART_ACT);
        }
    }
}
