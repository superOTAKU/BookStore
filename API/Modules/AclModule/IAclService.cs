using API.Modules.AclModule.Domains;
using API.Modules.AclModule.Dtos;

namespace API.Modules.AclModule;

public interface IAclService
{

    /// <summary>
    /// 对目标实体进行访问控制检查，实际的逻辑在策略类中执行
    /// </summary>
    /// <param name="entityType">实体类型</param>
    /// <param name="entityId">实体id</param>
    /// <returns>检查是否通过</returns>
    bool AccessControl(string entityType, string entityId);
    
    /// <summary>
    /// 添加一个访问控制策略，Repository层只负责CURD
    /// </summary>
    /// <param name="command">命令对象</param>
    /// <returns></returns>
    AclRecord AddAclRecord(AddAclRecordCommand command);

}
