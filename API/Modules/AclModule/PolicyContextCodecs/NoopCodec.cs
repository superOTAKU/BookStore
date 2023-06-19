namespace API.Modules.AclModule.PolicyContextCodecs
{
    public class NoopCodec : IAclPolicyContextCodec
    {
        public object Decode(string context)
        {
            return new object();
        }

        public string Encode(object context)
        {
            return string.Empty;
        }

    }
}
