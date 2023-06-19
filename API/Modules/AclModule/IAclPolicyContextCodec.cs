namespace API.Modules.AclModule;

public interface IAclPolicyContextCodec
{

    string Encode(object context);

    object Decode(string context);

}
