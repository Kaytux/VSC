using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace VuesVSC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Navigator Nav => (App.Current as App).Navigator;
        public Manager Mgr => (App.Current as App).Manager;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            Nav.NavigateTo(Navigator.PART_MAIN);
            lboxMenu.SelectedIndex = -1;
        }

        private async void Steam_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.Utilisateur != null)
            {
                Nav.NavigateTo(Navigator.PART_PROFIL);
                lboxMenu.SelectedIndex = -1;
            }
            else
            {
                contentControlConnexion.Content = new UCChargement();
                int test = Mgr.ChargeSteamAPI();

                if (test==0)
                {
                    SystemSounds.Hand.Play();
                    await Mgr.GetSuccesJoueur();
                    contentControlConnexion.Content = new UCConnecte();
                    Nav.NavigateTo(Navigator.PART_PROFIL);
                    lboxMenu.SelectedIndex = -1;
                }
                else
                {
                    if (test == 1)
                    {
                        MessageBox.Show("Erreur : Veuillez lancer Steam, et réessayez");
                        contentControlConnexion.Content = new UCNonConnecte();

                    }
                    else if(test == 2)
                    {
                        MessageBox.Show("Erreur : Votre compte Steam ne possède pas Vampire Survivors, initialisation impossible");
                        contentControlConnexion.Content = new UCNonConnecte();
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Debug.WriteLine("test close");
            Mgr.SauvegardeDonnées();
        }
    }
}
