using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKNBrauhelferKonverter.Utils;
using Octokit;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable VirtualMemberCallInConstructor

namespace BKNBrauhelferKonverter.Models
{
    public class Settings
    {
        public Settings()
        {
            KleinerBrauhelfer = new DkbSetting();
            Git = new GitSettings();
            Sql = new SqlSettings();
        }

        public virtual DkbSetting KleinerBrauhelfer { get; set; }
        public virtual GitSettings Git { get; set; }
        public virtual SqlSettings Sql { get; set; }

        public static Settings GetSettings()
        {
            var config = new Configuration();
            return config.GetSettings();
        }

        public void Save()
        {
            var config = new Configuration();
            config.SaveSettings(this);
        }
    }

    public class DkbSetting
    {
        public virtual string Database { get; set; }
    }

    public class GitSettings
    {
        public virtual string User { get; set; }
        public virtual string Password { get; set; }
        public virtual string Token { get; set; }
    }

    public class SqlSettings
    {
        public virtual string Server { get; set; }
        public virtual string Database { get; set; }
        public virtual string User { get; set; }
        public virtual string Password { get; set; }
    }
}
