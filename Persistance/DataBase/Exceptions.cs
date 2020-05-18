using System;

namespace Persistance.Database
{
    public class DatabaseUniqueException : Exception
    {
        public DatabaseUniqueException(string field)
        : base("field=" + field) { }
    }

    public class DatabaseRowsNotFound : Exception
    {
        public DatabaseRowsNotFound()
        : base("Row(s) not found") { }
    }
}
