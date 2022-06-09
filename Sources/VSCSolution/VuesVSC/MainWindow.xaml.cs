using BibliothequeClassesVSC;
using System.Linq;
using System.Media;
using System.Windows;

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

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Mgr.Utilisateur != null)
            {
                contentControl.Content = new UCProfil();
            }
            else
            {
                int test = Mgr.ChargeSteamAPI();

                if (test==0)
                {
                    SystemSounds.Hand.Play();
                    await Mgr.GetSuccesJoueur();
                    contentControlConnexion.Content = new UCConnecte();
                    contentControl.Content = new UCProfil();
                }
                else
                {
                    if (test == 1)
                    {
                        System.Windows.MessageBox.Show("Erreur : Veuillez lancer Steam, et réessayez");
                    }
                    else if(test == 2)
                    {
                        System.Windows.MessageBox.Show("Erreur : Votre compte Steam ne possède pas Vampire Survivors, initialisation impossible");
                    }
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
