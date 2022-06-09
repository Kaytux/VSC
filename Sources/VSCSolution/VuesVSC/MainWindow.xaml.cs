using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
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
                        MessageBox.Show("Erreur : Veuillez lancer Steam, et réessayez");
                    }
                    else if(test == 2)
                    {
                        MessageBox.Show("Erreur : Votre compte Steam ne possède pas Vampire Survivors, initialisation impossible");
                    }
                }
            }
        }
    }
}
