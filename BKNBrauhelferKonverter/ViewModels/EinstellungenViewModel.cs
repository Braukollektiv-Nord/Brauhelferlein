using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BKNBrauhelferKonverter.Models;
using BKNBrauhelferKonverter.Utils;
using Octokit;
using TrackerDog;
using TrackerDog.Configuration;
using GitHubClient = BKNBrauhelferKonverter.Utils.GitHubClient;

namespace BKNBrauhelferKonverter.ViewModels
{
    public class EinstellungenViewModel : ViewModelBase
    {
        private readonly Settings _settings;

        private ICommand _saveCommand;
        private ICommand _checkCommand;

        public EinstellungenViewModel()
        {
            var trackerConfig = ObjectChangeTracking.CreateConfiguration();
            trackerConfig.TrackThisType<Settings>();

            var trackableObjectFactory = trackerConfig.CreateTrackableObjectFactory();
            _settings = trackableObjectFactory.CreateFrom(Settings.GetSettings());
        }

        public string DkbDatenbank
        {
            get => _settings.KleinerBrauhelfer.Database;
            set
            {
                if (value == _settings.KleinerBrauhelfer.Database) return;
                _settings.KleinerBrauhelfer.Database = value;
                OnPropertyChanged();
            }
        }

        public string User
        {
            get => _settings.Git.User;
            set
            {
                if (value == _settings.Git.User) return;
                _settings.Git.User = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _settings.Git.Password;
            set
            {
                if (value == _settings.Git.Password) return;
                _settings.Git.Password = value;
                OnPropertyChanged();
            }
        }

        public string Token
        {
            get => _settings.Git.Token;
            set
            {
                if (value == _settings.Git.Token) return;
                _settings.Git.Token = value;
                OnPropertyChanged();
            }
        }

        public string SqlServer
        {
            get => _settings.Sql.Server;
            set
            {
                if (value == _settings.Sql.Server) return;
                _settings.Sql.Server = value;
                OnPropertyChanged();
            }
        }

        public string SqlDatabase
        {
            get => _settings.Sql.Database;
            set
            {
                if (value == _settings.Sql.Database) return;
                _settings.Sql.Database = value;
                OnPropertyChanged();
            }
        }

        public string SqlUser
        {
            get => _settings.Sql.User;
            set
            {
                if (value == _settings.Sql.User) return;
                _settings.Sql.User = value;
                OnPropertyChanged();
            }
        }

        public string SqlPass
        {
            get => _settings.Sql.Password;
            set
            {
                if (value == _settings.Sql.Password) return;
                _settings.Sql.Password = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new CommandHandler(Save, param => true));

        public ICommand CheckCommand => _checkCommand ?? (_checkCommand = new CommandHandler(Check, param => true));
        public string SqlPassword { get; set; }

        private void Save(object obj)
        {
            /*
            if (!Validate())
                return;
            */

            _settings.Save();

            MessageBox.Show("Erfolgreich gespeichert.");
        }

        private void Check(object obj)
        {
            if (!Validate())
                return;

            MessageBox.Show(GitHubClient.CheckCredentials(User, Password, Token) ? "Login-Daten in Ordnung." : "Login-Daten fehlerhaft.");
        }

        private bool Validate()
        {
            if (!((string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Password)) || string.IsNullOrEmpty(Token)))
            {
                MessageBox.Show("Bitte alle notwendigen Daten ausfüllen!");
                return false;
            }

            return true;
        }
    }
}
