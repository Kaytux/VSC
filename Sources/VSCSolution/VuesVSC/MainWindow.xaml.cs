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
                    //contentControlConnexion.Content = new UCConnecte();
                    contentControl.Content = new UCProfil();
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez lancer Steam, et réessayez");
                }
            }
        }
    }
}
