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
        public const string PART_ARMES_ACTIVES = "Armes Actives";
        public const string PART_ARMES_PASSIVES = "Armes Passives";
        public const string PART_AMELIORATION = "Amélioration";
        public ReadOnlyDictionary<string, Func<UserControl>> WindowParts { get; private set; }
        Dictionary<string, Func<UserControl>> windowParts { get; set; } = new Dictionary<string, Func<UserControl>>()
        {
            [PART_ARMES_ACTIVES] = () => new UCArmes(),
            [PART_ARMES_PASSIVES] = () => new UCArmesPassives(),
            [PART_AMELIORATION] = () => new UCAmelioration(),
        };

        public Navigator()
        {
            WindowParts = new ReadOnlyDictionary<string, Func<UserControl>>(windowParts);
            SelectedUserControlCreator = WindowParts.First();
        }

        public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreator
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

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void NavigateTo(string windowPartName)
        {
            if (WindowParts.ContainsKey(windowPartName))
            {
                SelectedUserControlCreator = WindowParts.Single(kvp => kvp.Key == windowPartName);
            }
        }
    }
}
