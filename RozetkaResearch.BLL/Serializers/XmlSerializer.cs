using System.IO;

namespace RozetkaResearch.BLL.Serializers
{
    public static class XmlSerializer
    {
        public static T Deserialize<T>(string content)
        {
            //content = GetNode(content, "offers");
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (var reader = new StringReader(content))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private static string GetNode(string content, string node)
        {
            var start = $"<{node}>";
            var end = $"</{node}>";
            var startIndex = content.IndexOf(start);
            var endIndex = content.IndexOf(end);
            return content.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
        }
    }
}
