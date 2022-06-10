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
            Manager.ApCarteSelectionne = Manager.CarteSelectionne.LesObjetsCaches;
            Manager.EnnCarteSelectionne = Manager.CarteSelectionne.LesEnnemies;

            if (Manager.Utilisateur != default)
            {
                Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.CarteSelectionne.Nom));
                if (Manager.NoteSelectionne == default)
                {
                    Manager.Utilisateur.lesNotes.Add(new Utilisateur.Note(Manager.CarteSelectionne.Nom, ""));
                    Manager.NoteSelectionne = Manager.Utilisateur.lesNotes.SingleOrDefault(note => note.Element.Equals(Manager.CarteSelectionne.Nom));
                }
            }
            else
            {
                tb_note.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void lBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.CarteSelectionne = e.AddedItems[0] as Carte;
            Manager.ApCarteSelectionne = Manager.CarteSelectionne.LesObjetsCaches;
            Manager.EnnCarteSelectionne = Manager.CarteSelectionne.LesEnnemies;
        }
    }
}
