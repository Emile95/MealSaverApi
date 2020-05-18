using System;

namespace DataValidator
{
    public interface IDataValidator
    {
        DataValidationException Validate<Data>(Data data);
    }
}
