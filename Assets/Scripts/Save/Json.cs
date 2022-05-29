using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using SwordsAndSandals;
using System;
using System.Linq;

namespace CustomJson
{
    public class Json
    {
        public void Save<T>(T data) where T : ISaveData
        { 
            var path = Application.persistentDataPath + "/" + typeof(T).Name + ".json";

            if (!File.Exists(path))
                File.WriteAllText(path, "");

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public T Load<T>() where T : ISaveData
        { 
            var path = Application.persistentDataPath + "/" + typeof(T).Name + ".json";

            string json = File.ReadAllText(path);

            if (typeof(IUtilitySaveData).IsAssignableFrom(typeof(T)))
            {
                return JsonUtility.FromJson<T>(json);
            }
            else if(typeof(IConvertSaveData).IsAssignableFrom(typeof(T)))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                new Exception("I can't find the required interface" + typeof(T) + ", I return the standard approach");
                return JsonUtility.FromJson<T>(json);
            }
        }
    }
}
