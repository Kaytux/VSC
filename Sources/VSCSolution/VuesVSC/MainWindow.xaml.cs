using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager Mgr => (App.Current as App).Manager;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mgr.StatsSelectionne = Mgr.ArmeSélectionné.stats.ToList();
            contentControl.Content = new UCTypesArmes();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCMainPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Mgr.StatsSelectionne=Mgr.PersonnageSelectionne.stats.ToList();
            contentControl.Content = new UCPersonnages();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Mgr.utilisateur != null)
            {
                contentControl.Content = new UCProfil();
            }
            else
            {
                bool test = Mgr.ChargeSteamAPI();

                if (test)
                {
                    SystemSounds.Hand.Play();
                    contentControlConnexion.Content = new UCConnecte();
                    contentControl.Content = new UCProfil();
                }
                else
                {
                    var window = new PopUpSteam();

                    window.Owner = this;
                    window.Show();
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UCListe();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Mgr.StatsSelectionne=Mgr.EnnemieSelectionne.stats.ToList();
            contentControl.Content = new UCEnnemie();
        }

        private void UCMainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
