using BibliothequeClassesVSC;
using System.Windows.Controls;

namespace VuesVSC
{
    /// <summary>
    /// Logique d'interaction pour UCCartes.xaml
    /// </summary>
    /// 
    public partial class UCCartes : UserControl
    {
        public Manager Manager => (App.Current as App).Manager;
        public UCCartes()
        {
            InitializeComponent();
            DataContext = Manager;
        }
    }
}
