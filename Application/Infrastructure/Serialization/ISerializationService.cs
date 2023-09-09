namespace SportsBet.Application.Infrastructure.Serialization;

public interface ISerializationService
{
    public byte[] Serialize<T>(T value);
    public T Deserialize<T>(byte[] data);
}
