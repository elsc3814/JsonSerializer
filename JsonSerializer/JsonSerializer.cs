using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace JsonSerializer
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize(object o)
        {
            var sb = new StringBuilder();
            SerializeObject(o, sb);
            return sb.ToString();
        }

        private static void SerializeObject(object o, StringBuilder sb)
        {
            sb.Append("{");
            var properties = o.GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i != 0) sb.Append(",");
                var value = properties[i].GetValue(o, null);
                var name = properties[i].Name;

                sb.Append($"\"{name}\":");
                AppendValue(value, properties[i].PropertyType, sb);
            }

            sb.Append("}");
        }

        private static void AppendValue(object value, Type type, StringBuilder sb)
        {
            if (type.IsArray)
            {
                sb.Append("[");

                var arr = (IList) value;

                for (var i = 0; i < arr.Count; i++)
                {
                    if (i != 0) sb.Append(",");
                    AppendValue(arr[i], arr[i]?.GetType(), sb);
                }

                sb.Append("]");
                return;
            }

            if (type.IsClass && type.Name != "String")
            {
                SerializeObject(value, sb);
                return;
            }

            sb.Append(type.Name switch
            {
                "String" => $"\"{value}\"",
                "Boolean" => value != null && (bool) value ? "true" : "false",
                _ => Convert.ToString(value, CultureInfo.InvariantCulture)
            });
        }
    }
}