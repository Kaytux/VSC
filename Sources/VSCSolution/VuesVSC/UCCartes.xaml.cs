using BibliothequeClassesVSC;
using System.Linq;
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

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.ApCarteSelectionne = Manager.CarteSelectionne.LesObjetsCaches;
            Manager.EnnCarteSelectionne = Manager.CarteSelectionne.LesEnnemies;
            Manager.CarteSelectionne = e.AddedItems[0] as Carte;
        }
    }
}
