namespace API.Modules.AclModule.Dtos;

public class AddAclRecordCommand
{
    public string EntityType { get; set; } = null!;
    public string EntityId { get; set; } = null!;

    public string Policy { get; set; } = null!;

    public object PolicyContext { get; set; } = string.Empty;
}
