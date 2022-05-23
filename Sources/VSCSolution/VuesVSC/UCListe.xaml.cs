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
    /// Interaction logic for ArmeActiveContol.xaml
    /// </summary>
    public partial class UCListe : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        public UCListe()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCArmes();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCEntites();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCCartes();
        }
    }
}
