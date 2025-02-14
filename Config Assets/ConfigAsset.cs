using System;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ConfigAsset<T> : ScriptableObject where T : ConfigAsset<T>
{
    public const string ConfigsDirectory = "Config/";
    public const string ResourcesDirectory = "Assets/Resources/" + ConfigsDirectory;

    private static Dictionary<Type, ScriptableObject> _loadedAssets = new Dictionary<Type, ScriptableObject>();

    public static T Get()
    {
        if (_loadedAssets.TryGetValue(typeof(T), out var asset))
        {
            return (T)asset;
        }

        var resourcePath = ConfigsDirectory + typeof(T).Name;
        T config = Resources.Load<T>(resourcePath);
        if (config != null)
        {
            _loadedAssets[typeof(T)] = config;
            return config;
        }

#if UNITY_EDITOR
        Directory.CreateDirectory(ResourcesDirectory);
        config = ScriptableObject.CreateInstance<T>();
        var assetPath = ResourcesDirectory + typeof(T).Name + ".asset";
        AssetDatabase.CreateAsset(config, assetPath);
        AssetDatabase.SaveAssets();
        return config;
#else
            return null;
#endif
    }
}