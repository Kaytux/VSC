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
    /// Logique d'interaction pour UCEnnemie.xaml
    /// </summary>
    public partial class UCEnnemie : UserControl
    {
        public Manager Manager => (App.Current as App).Manager;
        public UCEnnemie()
        {
            InitializeComponent();
            DataContext = Manager;
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.StatsSelectionne = Manager.EnnemieSelectionne.stats.ToList();
            Manager.EnnemieSelectionne= e.AddedItems[0] as Ennemie;

        }
    }
}
