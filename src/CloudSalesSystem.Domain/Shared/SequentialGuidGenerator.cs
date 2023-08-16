namespace CloudSalesSystem.Domain.Shared;

internal static class SequentialGuidGenerator
{
    public static Guid Generate()
    {
        long ticks = DateTime.UtcNow.Ticks;
        byte[] byteArray = Guid.NewGuid().ToByteArray();
        byte[] bytes = BitConverter.GetBytes(Interlocked.Increment(ref ticks));
        if (!BitConverter.IsLittleEndian)
            Array.Reverse<byte>(bytes);
        byteArray[8] = bytes[1];
        byteArray[9] = bytes[0];
        byteArray[10] = bytes[7];
        byteArray[11] = bytes[6];
        byteArray[12] = bytes[5];
        byteArray[13] = bytes[4];
        byteArray[14] = bytes[3];
        byteArray[15] = bytes[2];
        return new Guid(byteArray);
    }
}