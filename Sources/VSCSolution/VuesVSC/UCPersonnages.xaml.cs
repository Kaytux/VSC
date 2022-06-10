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
    /// Logique d'interaction pour UCPersonnages.xaml
    /// </summary>
    public partial class UCPersonnages : UserControl
    {
        public Manager Manager => (App.Current as App).Manager;
        public Navigator Nav => (App.Current as App).Navigator;
        public UCPersonnages()
        {
            InitializeComponent();
            DataContext = Manager;
            Manager.StatsSelectionne = Manager.PersonnageSelectionne.stats.ToList();

            if (Manager.Utilisateur != default)
            {
                Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.PersonnageSelectionne.Nom));
                if (Manager.NoteSelectionne == default)
                {
                    Manager.Utilisateur.lesNotes.Add(new Utilisateur.Note(Manager.PersonnageSelectionne.Nom, ""));
                    Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.PersonnageSelectionne.Nom));
                }
            }
            else
            {
                tb_note.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.PersonnageSelectionne = e.AddedItems[0] as Personnage;
            Manager.StatsSelectionne = Manager.PersonnageSelectionne.stats.ToList();

            if (Manager.Utilisateur != default)
            {
                Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.PersonnageSelectionne.Nom));
                if (Manager.NoteSelectionne == default)
                {
                    Manager.Utilisateur.lesNotes.Add(new Utilisateur.Note(Manager.PersonnageSelectionne.Nom, ""));
                    Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.PersonnageSelectionne.Nom));
                }
            }
            else
            {
                tb_note.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void Arme_Click(object sender,RoutedEventArgs e)
        {
            Manager.ArmeSélectionné = Manager.PersonnageSelectionne.Arme;
            Nav.NavigateTo(Navigator.PART_ARMES,Navigator.PART_ACT);
        }
    }
}
