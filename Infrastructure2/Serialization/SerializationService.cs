namespace SportsBet.Infrastructure.Serialization;

public class SerializationService : ISerializationService
{
    private readonly RuntimeTypeModel model;
    private int metaIndex = 1;
    public SerializationService()
    {
        model = RuntimeTypeModel.Create();
        RegisterTypes(typeof(CommandBase), true);
        RegisterTypes(typeof(CommandItemBase));
    }

    public T Deserialize<T>(byte[] data)
    {
        using (var stream = new MemoryStream(data))
        {
            return (T)model.Deserialize(stream, null, typeof(T));
        }
    }

    public byte[] Serialize<T>(T value)
    {
        using (var stream = new MemoryStream())
        {
            model.Serialize(stream, value);
            return stream.ToArray();
        }
    }

    private void RegisterTypes(Type baseType, bool applyBaseMetaType = false)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var inheritingTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t != baseType && baseType.IsAssignableFrom(t));

        foreach (var type in inheritingTypes)
        {
            var baseMetaType = model.Add(type, applyDefaultBehaviour: false);
            var properties = type.GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                baseMetaType.AddField(i + 1, properties[i].Name);
            }

            if (applyBaseMetaType)
            {
                var parentMetaType = model[baseType];
                parentMetaType.AddSubType(metaIndex, type);
            }

            metaIndex++;
        }
    }

}