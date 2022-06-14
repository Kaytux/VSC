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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class UCMainPage : UserControl
    {
        public UCMainPage()
        {
            InitializeComponent();
        }

        private string patch_content = "Ajustements :\n\t- bonus d'armure et de pv pour Antonio\n\t- bonus de PV pour Gennaro et Suor Clerici\n\t- Bonus moveSpeed ​​pour Krochi\n\t- collisionneurs modifiés dans Mad Forest\n\t- les objets de scène cachés ont désormais 100 % de chances d'apparaître\n\t- optimisations mineures\n\nCorrections de bogues :\n\t- correctif provisoire pour le gel du jeu au démarrage après l'utilisation de mods de localisation\n\t- correctif provisoire pour le gel du jeu lors de la sélection des personnages après la corruption/modification des données de sauvegarde";

        private void patch_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(patch_content,"Notes de patch",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
