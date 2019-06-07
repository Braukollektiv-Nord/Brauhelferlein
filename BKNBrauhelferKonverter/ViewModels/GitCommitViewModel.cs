using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Utils;
using BKNBrauhelferKonverter.Views;
using Microsoft.Win32;

namespace BKNBrauhelferKonverter.ViewModels
{
    public class GitCommitViewModel : ViewModelBase
    {
        private string _mdFile;
        private ICommand _gitCommitCommand;
        private ICommand _openFileCommand;
        private string _commitMessage;

        public GitCommitViewModel(string defaultFile = "")
        {
            MdFile = defaultFile;
        }

        public string MdFile
        {
            get => _mdFile;
            set
            {
                if (value == _mdFile) return;
                _mdFile = value;
                OnPropertyChanged(nameof(MdFile));
            }
        }

        public string CommitMessage
        {
            get => _commitMessage;
            set
            {
                if (value == _commitMessage) return;
                _commitMessage = value;
                OnPropertyChanged(nameof(CommitMessage));
            }
        }

        public ICommand CommitCommand => _gitCommitCommand ?? (_gitCommitCommand = new CommandHandler(GitCommit, param => true));
        public ICommand OpenFileCommand => _openFileCommand ?? (_openFileCommand = new CommandHandler(OpenFile, param => true));

        private void OpenFile(object obj)
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".md",
                Filter = "MarkDown Dateien (*.md)|*.md"
            };

            if (!string.IsNullOrEmpty(MdFile))
            {
                openFileDialog.FileName = MdFile;
            }

            if (openFileDialog.ShowDialog() == true)
            {
                MdFile = openFileDialog.FileName;
            }
        }

        private void GitCommit(object obj)
        {
            try
            {
                var client = new GitHubClient();
                var result = client.CommitFile(MdFile, CommitMessage);

                switch (result.Status)
                {
                    case GitCommitStatus.AuthMissing:
                    {
                        MessageBox.Show("Login-Daten fehlen. Bitte in den Einstellungen eintragen.");
                        return;
                    }
                    case GitCommitStatus.AuthFailed:
                    {
                        MessageBox.Show("Login-Daten fehlerhaft. Bitte in den Einstellungen ändern.");
                        return;
                    }
                    case GitCommitStatus.Error:
                        MessageBox.Show("Unbekannter Fehler:\n" + result.ErrorMsg);
                        return;
                    case GitCommitStatus.Success:
                        MessageBox.Show("Erfolgreich commited!");
                        return;
                    case GitCommitStatus.Unknown:
                    default:
                        MessageBox.Show("Unbekanntes Ergebnis! Das sollte nicht vorkommen...");
                        return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Schwerer Fehler:\n" + e.Message);
            }

            
        }
    }
}
