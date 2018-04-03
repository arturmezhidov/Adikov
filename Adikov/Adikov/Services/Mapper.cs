using System.Linq;
using System.Reflection;

namespace Adikov.Services
{
    public static class Mapper
    {
        public static TReceiver Map<TReceiver>(object source) where TReceiver : class, new()
        {
            TReceiver receiver = new TReceiver();
            PropertyInfo[] sourceProperties = source.GetType().GetProperties();
            PropertyInfo[] receiverProperties = receiver.GetType().GetProperties();

            foreach (PropertyInfo receiverProperty in receiverProperties)
            {
                if (!receiverProperty.CanWrite)
                {
                    continue;
                }

                PropertyInfo sourceProperty = sourceProperties.FirstOrDefault(i => i.Name == receiverProperty.Name);

                if (sourceProperty == null || !sourceProperty.CanRead)
                {
                    continue;
                }

                string value = sourceProperty.GetValue(source)?.ToString();
                receiverProperty.SetValue(receiver, value);
            }

            return receiver;
        }
    }
}