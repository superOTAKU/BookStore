
using Newtonsoft.Json;

namespace API.Modules.AclModule.PolicyContextCodecs;

/// <summary>
/// 动态的Json序列号/反序列化
/// </summary>
public class JsonPolicyContextCodec : IAclPolicyContextCodec
{
    public object Decode(string context)
    {
        return JsonConvert.DeserializeObject(context) ?? throw new ArgumentNullException(nameof(context));
    }

    public string Encode(object context)
    {
        return JsonConvert.SerializeObject(context);
    }

}
