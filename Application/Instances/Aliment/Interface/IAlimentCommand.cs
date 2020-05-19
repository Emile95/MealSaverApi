using Application.Aliment.DataModel.Sended;

namespace Application.Aliment.Interface
{
    public interface IAlimentCommand
    {
        object Add(AlimentModel model);
        object RemoveById(int id);
        object Update(AlimentModel model);
    }
}
