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
    /// Logique d'interaction pour UCRecap.xaml
    /// </summary>
    public partial class UCRecap : UserControl
    {
        public Manager Mgr => (App.Current as App).Manager;
        public UCRecap()
        {
            InitializeComponent();
            DataContext = Mgr;
        }
    }
}
