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
    /// Interaction logic for Armes.xaml
    /// </summary>
    public partial class UCTypesArmes : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        public UCTypesArmes()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lBox.ItemsSource = Mgr.LesArmesActives;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lBox.ItemsSource = Mgr.LesArmesPassives;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lBox.ItemsSource = Mgr.LesAmeliorations;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
