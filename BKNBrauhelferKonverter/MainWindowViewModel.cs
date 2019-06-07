using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BKNBrauhelferKonverter.Utils;
using BKNBrauhelferKonverter.ViewModels;

namespace BKNBrauhelferKonverter
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IList<ViewModelBase> _viewModels;
        private object _currentViewModel;
        private ListViewItem _selecteListViewItem;

        public MainWindowViewModel()
        {
            _viewModels = new List<ViewModelBase>();
            _viewModels.Add(new SudKonverterViewModel());
            _viewModels.Add(new RohstoffeViewModel());
            _viewModels.Add(new EinstellungenViewModel());

            _currentViewModel = _viewModels.FirstOrDefault(x => x.GetType() == typeof(EinstellungenViewModel));
        }

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ListViewItem SelecteListViewItem
        {
            get => _selecteListViewItem;
            set
            {
                if (Equals(value, _selecteListViewItem)) return;
                _selecteListViewItem = value;
                ChangeCurrentView();
                OnPropertyChanged();
            }
        }

        private void ChangeCurrentView()
        {
            // Quick 'n' dirty!
            switch(_selecteListViewItem.Name)
            {
                case "Sudauswahl":
                    CurrentViewModel = _viewModels.FirstOrDefault(x => x.GetType() == typeof(SudKonverterViewModel));
                    break;
                case "Rohstoffe":
                    CurrentViewModel = _viewModels.FirstOrDefault(x => x.GetType() == typeof(RohstoffeViewModel));
                    break;
                case "Einstellungen":
                    CurrentViewModel = _viewModels.FirstOrDefault(x => x.GetType() == typeof(EinstellungenViewModel));
                    break;
                case "Beenden":
                    if (MessageBox.Show("Wirklich beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }

                    break;
            }
            
        }
    }
}
