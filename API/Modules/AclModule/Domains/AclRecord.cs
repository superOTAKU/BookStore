using API.Commons.Domains;

namespace API.Modules.AclModule.Domains;

public class AclRecord : IHasCreateTime
{
    public int Id { get; set; }

    public string EntityType { get; set; } = null!;

    public string EntityId { get; set; } = null!;

    //扩展点，访问控制策略

    public string Policy = null!;

    public string PolicyContext { get; set; } = null!;

    public DateTime CreateTime { get; set; }

}
