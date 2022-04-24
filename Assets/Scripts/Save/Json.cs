using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using SwordsAndSandals;

namespace CustomJson
{
    public class Json
    {
        public void Save(ISaveData data, Enums.SaveFilename saveFilename)
        {
            var path = Application.persistentDataPath + "/" + saveFilename + ".json";

            if (!File.Exists(path))
                File.WriteAllText(path, "");

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public T Load<T>(Enums.SaveFilename saveFilename)
        {
            var path = Application.persistentDataPath + "/" + saveFilename + ".json";

            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(json);
        }
    }
}
