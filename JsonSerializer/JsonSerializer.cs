using System;
using System.Globalization;
using System.Text;

namespace JsonSerializer
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize(object o)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            var properties = o.GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i != 0) sb.Append(",");
                var value = properties[i].GetValue(o, null);
                var name = properties[i].Name;
                switch (properties[i].PropertyType.Name)
                {
                    case "String":
                        sb.Append($"\"{name}\":\"{value}\"");
                        break;
                    default:
                        sb.Append($"\"{name}\":{Convert.ToString(value, CultureInfo.InvariantCulture)}");
                        break;
                }
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}