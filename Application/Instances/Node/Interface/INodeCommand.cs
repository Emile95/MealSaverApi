using Application.Node.DataModel.Sended;

namespace Application.Node.Interface
{
    public interface INodeCommand
    {
        object Login(LoginModel model);
    }
}
