using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VuesVSC
{
    public class Navigator : INotifyPropertyChanged
    {
        public const string PART_MAIN = "Main";
        public const string PART_ARMES = "Armes";
        public const string PART_PERSONNAGES = "Personnages";
        public const string PART_ENNEMIES = "Ennemies";
        public const string PART_CARTES = "Cartes";

        public const string PART_ACT = "Armes actives";
        public const string PART_PASS = "Armes passives";
        public const string PART_AMELIO = "Améliorations";
        public const string PART_RECAP = "Récap";
        public ReadOnlyDictionary<string,Func<UserControl>> WindowParts { get; private set; }
        Dictionary<string, Func<UserControl>> windowParts { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            [PART_MAIN] = () => new UCMainPage(),
            [PART_ARMES] = () => new UCTypesArmes(),
            [PART_PERSONNAGES] = () => new UCPersonnages(),
            [PART_ENNEMIES] = () => new UCEnnemie(),
            [PART_CARTES] = () => new UCCartes()
        };

        public ReadOnlyDictionary<string, Func<UserControl>> WindowPartsScnd { get; private set; }
        Dictionary<string, Func<UserControl>> windowPartsScnd { get; set; } = new Dictionary<string, Func<UserControl>>
        {
            [PART_ACT] = () => new UCArmes(),
            [PART_PASS] = () => new UCArmesPassives(),
            [PART_AMELIO] = () => new UCAmelioration(),
            [PART_RECAP] = () => new UCRecap()
        };

        public Navigator()
        {
            WindowParts = new ReadOnlyDictionary<string, Func<UserControl>>(windowParts);
            SelectedUserControlCreator = WindowParts.First();
            WindowPartsScnd = new ReadOnlyDictionary<string, Func<UserControl>>(windowPartsScnd);
            SelectedUserControlCreatorScnd = WindowPartsScnd.First();
        }

        public KeyValuePair<string,Func<UserControl>> SelectedUserControlCreator
        {
            get => selectedUserControlCreator;
            set
            {
                if (selectedUserControlCreator.Equals(value)) return;
                selectedUserControlCreator = value;
                OnPropertyChanged();
            }
        }
        private KeyValuePair<string, Func<UserControl>> selectedUserControlCreator;

        public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreatorScnd
        {
            get => selectedUserControlCreatorScnd;
            set
            {
                if (selectedUserControlCreatorScnd.Equals(value)) return;
                selectedUserControlCreatorScnd = value;
                OnPropertyChanged();
            }
        }
        private KeyValuePair<string, Func<UserControl>> selectedUserControlCreatorScnd;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName="")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void NavigateTo(string windowPartName,string windowPartNameScnd=default)
        {
            if (WindowParts.ContainsKey(windowPartName))
            {
                if(windowPartName == PART_ARMES)
                {
                    if (windowPartNameScnd == default) return;
                    else NavigateToScnd(windowPartNameScnd);
                }
                SelectedUserControlCreator = WindowParts.Single(kvp => kvp.Key == windowPartName);
            }
        }
        private void NavigateToScnd(string windowPartName)
        {
            if (WindowPartsScnd.ContainsKey(windowPartName))
            {
                SelectedUserControlCreatorScnd = WindowPartsScnd.Single(kvp => kvp.Key == windowPartName);
            }
        }
    }
}
