using System;
using System.Reflection;
using UnityEditor;

namespace UnityUtilities
{
    [InitializeOnLoad]
    static class ConfigAssetHelper
    {
        static ConfigAssetHelper()
        {
            foreach (var type in TypeCache.GetTypesDerivedFrom(typeof(ConfigAsset<>)))
            {
                var getMethod = type.GetMethod("Get", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                getMethod.Invoke(null, Array.Empty<object>());
            }
        }
    }
}