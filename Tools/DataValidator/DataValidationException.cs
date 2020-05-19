using System;

namespace DataValidator
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string className, string valueName, string message)
        : base(className+";"+(valueName == null ? "" : (valueName+";"))+message)
        {
        }
    }
}
