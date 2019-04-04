using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Serialize players and their count in json
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonSerializer<T> where T:BaseModel
    {
        public static  void Serialize(T model,string path)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ser.WriteObject(fs, model);
            }
        }

        public static T Deserialize(string path)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return ser.ReadObject(fs) as T;
            }
        }
    }
}
