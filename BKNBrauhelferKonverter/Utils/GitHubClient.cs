using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Models;
using Octokit;

namespace BKNBrauhelferKonverter.Utils
{
    public class GitHubClient
    {
        private const string AppName = "BKN-Converter-App";
        //private const string RepositoryOwner = "Braukollektiv-Nord";
        private const string RepositoryOwner = "SPRDevelopment";
        private const string Repository = "Recipes";

        private GitSettings _settings;


        private bool CheckLoginData()
        {
            var config = new Configuration();
            _settings = config.GetSettings().Git;

            return !(string.IsNullOrEmpty(_settings.User) || string.IsNullOrEmpty(_settings.Password)) || !string.IsNullOrEmpty(_settings.Token);
        }

        private GitCommitResult CheckCredentials(ref Octokit.GitHubClient client, ref IReadOnlyList<RepositoryContent> repositoryContents)
        {
            if (!CheckLoginData())
                return new GitCommitResult { Status = GitCommitStatus.AuthMissing };

            client = new Octokit.GitHubClient(new ProductHeaderValue(AppName))
            {
                Credentials = string.IsNullOrEmpty(_settings.Token) ? new Credentials(_settings.User, _settings.Password) : new Credentials(_settings.Token)
            };

            try
            {
                repositoryContents = client.Repository.Content.GetAllContents(RepositoryOwner, Repository).Result;
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException.GetType() == typeof(AuthorizationException))
                {
                    return new GitCommitResult { Status = GitCommitStatus.AuthFailed };
                }

                return new GitCommitResult { Status = GitCommitStatus.Error, ErrorMsg = e.Message };
            }

            return new GitCommitResult {Status = GitCommitStatus.Success };
        }

        public static bool CheckCredentials(string user, string password, string token)
        {
            var client = new Octokit.GitHubClient(new ProductHeaderValue(AppName))
            {
                Credentials = string.IsNullOrEmpty(token) ? new Credentials(user, password) : new Credentials(token)
            };

            try
            {
                var repositoryContents = client.Repository.Content.GetAllContents(RepositoryOwner, Repository).Result;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public GitCommitResult CommitFile(string mdFile, string commitMessage)
        {
            IReadOnlyList<RepositoryContent> repositoryContents = null;
            Octokit.GitHubClient client = null;
            var result = CheckCredentials(ref client, ref repositoryContents);
            if (result.Status != GitCommitStatus.Success)
                return result;

            var filename = Path.GetFileName(mdFile);
            var content = File.ReadAllText(mdFile);
            var repositoryContent = repositoryContents.FirstOrDefault(x => x.Name.Equals(filename));

            if (repositoryContent == null)
            {
                // Create file
                var createChangeSet = client.Repository.Content.CreateFile(
                    RepositoryOwner,
                    Repository,
                    filename,
                    new CreateFileRequest(commitMessage, content)).Result;
            }
            else
            {
                // Update file
                var updateChangeSet = client.Repository.Content.UpdateFile(
                    RepositoryOwner,
                    Repository,
                    filename,
                    new UpdateFileRequest(commitMessage, content, repositoryContent.Sha)).Result;
            }

            return new GitCommitResult {Status = GitCommitStatus.Success};
        }

    }

    public class GitCommitResult
    {
        public GitCommitStatus Status { get; set; }
        public string ErrorMsg { get; set; }
    }
}
