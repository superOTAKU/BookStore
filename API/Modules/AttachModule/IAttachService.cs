using API.Modules.AttachModule.Domains;
using API.Modules.AttachModule.Dtos;

namespace API.Modules.AttachModule;

public interface IAttachService
{

    Attach Put(PutAttachCommand putCommand);

}
