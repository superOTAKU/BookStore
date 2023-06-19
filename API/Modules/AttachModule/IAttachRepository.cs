using API.Commons.DataAccesses;
using API.Modules.AttachModule.Domains;

namespace API.Modules.AttachModule;

public interface IAttachRepository : IRepository
{

    void Add(Attach attach);

    Attach? GetById(int id);
}
