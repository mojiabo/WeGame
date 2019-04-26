namespace Framework
{
    public interface IProto
    {
        ushort ProtoCode { get; }

        string ProtoEnName { get; }

        byte[] ToArray();
    }
}