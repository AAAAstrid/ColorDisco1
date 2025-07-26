using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ManagerLoader1
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void LoadManagers()
    {
        string path = "Prefabs/DontDistory"; 
        GameObject[] prefabs = Resources.LoadAll<GameObject>(path);

        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError($"未加载到预制体！请检查路径: Resources/{path}");
            return;
        }

        foreach (var prefab in prefabs)
        {
            // 1. 通过名称+类型检测实例是否存在
            MonoBehaviour existingScript = Object.FindObjectsOfType<MonoBehaviour>()
                .FirstOrDefault(mb => mb.name == prefab.name && mb.GetType() == prefab.GetComponent<MonoBehaviour>()?.GetType());

            if (existingScript != null)
            {
                Debug.Log($"已存在管理器: {prefab.name}");
                continue;
            }

            // 2. 实例化并挂载
            GameObject manager = Object.Instantiate(prefab);
            manager.name = prefab.name; // 保留原名避免重复
            Object.DontDestroyOnLoad(manager);
            Debug.Log($"创建全局管理器: {manager.name}");
        }
    }
}
