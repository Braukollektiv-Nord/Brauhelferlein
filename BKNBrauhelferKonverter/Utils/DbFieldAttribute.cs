using System;

namespace BKNBrauhelferKonverter.Utils
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbFieldAttribute : Attribute
    {
        private readonly string _dbField;

        public DbFieldAttribute(string dbField)
        {
            _dbField = dbField;
        }

        public string DbField => _dbField;
    }

}
