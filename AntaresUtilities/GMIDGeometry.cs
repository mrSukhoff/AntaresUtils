using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace AntaresUtilities
{
    //Описывает структуру объектов для сериализации
    public class GMIDGeometry
    {
        public string GMID;
        public List<RecipeGeometry> ListOfrecipeGeometries;

        public void Save(string path) 
        {
            XmlSerializer formatter = new XmlSerializer(typeof(GMIDGeometry));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static GMIDGeometry Load(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(GMIDGeometry));
            GMIDGeometry result = new GMIDGeometry();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                result = (GMIDGeometry)deserializer.Deserialize(fs);
            }
            return result;
        }
    }
}
