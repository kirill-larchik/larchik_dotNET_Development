using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoodsLibrary
{
    /// <summary>
    /// Class goods collection.
    /// </summary>
    public class GoodsCollection
    {
        private List<Good> _goods;

        /// <summary>
        /// Inits goods collection.
        /// </summary>
        public GoodsCollection()
        {
            _goods = new List<Good>();
        }

        /// <summary>
        /// Inits collection with goods.
        /// </summary>
        /// <param name="goods"></param>
        public GoodsCollection(params Good[] goods)
        {
            _goods = goods.ToList();
        }

        /// <summary>
        /// Returns goods collection.
        /// </summary>
        /// <returns></returns>
        public List<Good> GetGoods()
        {
            return _goods;
        }

        /// <summary>
        /// Saves collection to json file.
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveToFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter writer = new JsonTextWriter(sw);
            writer.WriteStartArray();
            
            foreach (Good good in _goods)
            {
                writer.WriteStartObject();

                writer.WritePropertyName("type");
                writer.WriteValue(good.GetType().Name);

                writer.WritePropertyName("name");
                writer.WriteValue(good.Name);

                writer.WritePropertyName("cost");
                writer.WriteValue(good.Cost);

                writer.WritePropertyName("markup");
                writer.WriteValue(good.Markup);

                writer.WritePropertyName("count");
                writer.WriteValue(good.Count);

                writer.WriteEndObject();
            }
            writer.WriteEndArray();

            File.WriteAllText(filePath, sb.ToString());
        }

        /// <summary>
        /// Gets collection from json file.
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFile(string filePath)
        {
            if (File.Exists(filePath)) 
            {
                _goods.Clear();

                string typeName = string.Empty;
                string name = string.Empty;
                double cost = 0;
                double markup = 0;
                int count = 0;

                StringReader sr = new StringReader(File.ReadAllText(filePath));
                JsonReader reader = new JsonTextReader(sr);

                while (reader.Read())
                {
                    var tokenType = reader.TokenType;
                    if (tokenType == JsonToken.PropertyName)
                    {
                        var value = (reader.Value as string) ?? string.Empty;

                        if (value == "type")
                            typeName = reader.ReadAsString();
                        if (value == "name")
                            name = reader.ReadAsString();
                        if (value == "cost")
                            cost = (double)reader.ReadAsDouble();
                        if (value == "markup")
                            markup = (double)reader.ReadAsDouble();
                        if (value == "count")
                            count = (int)reader.ReadAsInt32();
                    }

                    if (tokenType == JsonToken.EndObject)
                    {
                        _goods.Add(Good.GetGood(typeName, name, cost, markup, count));
                    }
                }
            }
        }
    }
}
