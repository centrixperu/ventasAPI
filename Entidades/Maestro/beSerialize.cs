using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace Entidades.Maestro
{
    public class beSerialize
    {
        public static string SerializeObject<T>(T oSerializable)
        {
            MemoryStream memoryStream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(oSerializable.GetType());
            ser.WriteObject(memoryStream, oSerializable);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }

        public static T DeserializeObject<T>(string strSerialize)
        {
            T oSerializable = Activator.CreateInstance<T>();
            MemoryStream memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(strSerialize));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(oSerializable.GetType());
            oSerializable = (T)serializer.ReadObject(memoryStream);
            memoryStream.Close();
            memoryStream.Dispose();
            return oSerializable;
        }
    }
}
