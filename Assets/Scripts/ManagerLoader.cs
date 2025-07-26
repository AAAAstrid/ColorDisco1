using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadManagers()
    {
        // 加载Resources/Managers下所有预制体
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Assets/Resources/Prefabs/DontDistory");
        foreach (var prefab in prefabs)
        { 

            // 检查是否已存在该类型的实例
            var existing = Object.FindObjectOfType(prefab.GetComponent<MonoBehaviour>().GetType());
            //if (existing == null)
            //{
                GameObject manager = Object.Instantiate(prefab);
                manager.name = prefab.name;
                Object.DontDestroyOnLoad(manager);
                Debug.Log($"已创建: {manager.name}");
            //}
        }


        Debug.Log("全局管理器预制体已加载");
    }
}
