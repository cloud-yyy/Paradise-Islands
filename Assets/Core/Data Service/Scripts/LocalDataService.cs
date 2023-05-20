using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class LocalDataService : IDataService
{
    public void Load<T>(string key, Action<T> callback)
    {
        var path = BuildPath(key);

        using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write))
        using (var streamReader = new StreamReader(stream))
        {
            var json = streamReader.ReadToEnd();
            var data = JsonUtility.FromJson<T>(json);

            callback?.Invoke(data);
        }
    }

    public void Save(object data, string key, Action<bool> callback = null)
    {
        var path = BuildPath(key);
        var json = JsonUtility.ToJson(data);

        using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        using (var streamWriter = new StreamWriter(stream))
        {
            streamWriter.Write(json);
        }

        callback?.Invoke(true);
    }

    private string BuildPath(string key) => Path.Combine(Application.persistentDataPath, key);
}
