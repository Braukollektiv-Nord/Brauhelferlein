using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Models;
using BKNBrauhelferKonverter.Utils;
using BKNBrauhelferKonverter.Views;
using Microsoft.Win32;

namespace BKNBrauhelferKonverter.ViewModels
{
    public class SudKonverterViewModel : ViewModelBase
    {
        private readonly SudKonverter _sudKonverter;
        private ObservableCollection<SudBase> _items;
        private SudBase _selectedItem;
        private string _lastConvertedFile;

        private ICommand _konvertierenCommand;
        private ICommand _gitCommitCommand;
        private ICommand _rohstoffSyncCommand;

        private bool _canExecute;

        public SudKonverterViewModel()
        {
            _sudKonverter = new SudKonverter();
            Items = new ObservableCollection<SudBase>(_sudKonverter.GetSudOverview());
        }


        public ObservableCollection<SudBase> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public SudBase SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                _canExecute = _selectedItem != null;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand KonvertierenCommand => _konvertierenCommand ?? (_konvertierenCommand = new CommandHandler(Konvertieren, param => _canExecute));

        public ICommand GitCommitCommand => _gitCommitCommand ?? (_gitCommitCommand = new CommandHandler(GitCommit, param =>_canExecute));

        public ICommand RohstoffSyncCommand => _rohstoffSyncCommand ?? (_rohstoffSyncCommand = new CommandHandler(RohstoffeSynchronisieren, param => true));

        private void RohstoffeSynchronisieren(object obj)
        {
            var client = new MySqlClient();
            client.Connect();
        }

        private void Konvertieren(object obj)
        {
            var filename = "Bierstil - " + _selectedItem.Sudname;
            if (_selectedItem.Sudnummer > 0)
            {
                filename += " - " + _selectedItem.Sudnummer;
            }
            filename += ".md";

            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".md",
                Filter = "MarkDown Dateien (*.md)|*.md",
                FileName = filename
            };


            if (saveFileDialog.ShowDialog() != true)
            {
                return;
            }

            try
            {
                _lastConvertedFile = saveFileDialog.FileName;
                _sudKonverter.ConvertToMarkdown(_selectedItem.Id, saveFileDialog.FileName);
                MessageBox.Show("Markdown-Datei erfolgreich erzeugt", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show("Es ist ein Fehler bei der Konvertierung aufgetreten: \r\n " + e.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GitCommit(object obj)
        {
            var commitDialog = string.IsNullOrEmpty(_lastConvertedFile) ? new GitCommitView() : new GitCommitView(_lastConvertedFile);
            var dialogResult = commitDialog.ShowDialog();

            if (dialogResult != true)
                return;

            var dialogViewModel = commitDialog.DataContext as GitCommitViewModel;
            var commitMessage = dialogViewModel?.CommitMessage;
            var filename = dialogViewModel?.MdFile;

            var gitHubClient = new GitHubClient();
            var result = gitHubClient.CommitFile(filename, commitMessage);

            switch (result.Status)
            {
                case GitCommitStatus.AuthMissing:
                {
                    MessageBox.Show("Fehlende Login-Daten.  Bitte in den Einstellungen eintragen.");
                    return;
                }
                case GitCommitStatus.AuthFailed:
                {
                    MessageBox.Show("Login nicht erfolgreich.  Bitte in den Einstellungen ändern.");
                    return;
                }
                case GitCommitStatus.Error:
                    MessageBox.Show("Es ist ein folgender Fehler aufgetreten:\n" + result.ErrorMsg);
                    return;
                case GitCommitStatus.Success:
                    MessageBox.Show("Datei erfolgreich commited.");
                    return;
                case GitCommitStatus.Unknown:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
