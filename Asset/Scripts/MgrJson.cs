using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public static class MgrJson
{
    public static void Save(object data, string p_path)
    {
        File.WriteAllText(p_path, JsonConvert.SerializeObject(data, Formatting.Indented));

        AssetDatabase.Refresh();
    }
    public static T Load<T>(string p_path, UnityAction<T> callback = null) where T : class, new()
    {
        if (!File.Exists(p_path))
        {
            Debug.Log("--- MgrJson: " + p_path + " is null ---");
            return null;
        }

        T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(p_path));

        callback?.Invoke(data);

        return data;
    }
}