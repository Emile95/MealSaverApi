using System.Collections.Generic;

namespace RepositoryManager.CrudConfiguration.Crud.ResultCrud
{
    public class SelectResult<Selector> : Result
    {
        public List<Selector> Result { get; set; }
    }
}
