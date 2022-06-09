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
    /// Interaction logic for UCArmesPassives.xaml
    /// </summary>
    public partial class UCArmesPassives : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        public UCArmesPassives()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mgr.ArmeSélectionné = e.AddedItems[0] as Arme;
        }
    }
}
