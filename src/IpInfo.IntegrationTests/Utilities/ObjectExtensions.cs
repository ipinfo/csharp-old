using System.Reflection;
using System.Text;

namespace IpInfo.IntegrationTests.Utilities
{
    public static class ObjectExtensions
    {
        public static string GetPropertiesText(this object obj)
        {
            var builder = new StringBuilder();

            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                builder.AppendLine($"{property.Name}: {value}");

                if (value == null || !value.GetType().IsClass || value is string)
                {
                    continue;
                }

                foreach (var objectProperty in value.GetType().GetProperties())
                {
                    try
                    {
                        builder.AppendLine($"  {objectProperty.Name}: {objectProperty.GetValue(value)}");
                    }
                    catch (TargetParameterCountException)
                    {
                    }
                }
            }

            return builder.ToString();
        }
    }
}
