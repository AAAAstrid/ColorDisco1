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
            Debug.LogError($"δ���ص�Ԥ���壡����·��: Resources/{path}");
            return;
        }

        foreach (var prefab in prefabs)
        {
            // 1. ͨ������+���ͼ��ʵ���Ƿ����
            MonoBehaviour existingScript = Object.FindObjectsOfType<MonoBehaviour>()
                .FirstOrDefault(mb => mb.name == prefab.name && mb.GetType() == prefab.GetComponent<MonoBehaviour>()?.GetType());

            if (existingScript != null)
            {
                Debug.Log($"�Ѵ��ڹ�����: {prefab.name}");
                continue;
            }

            // 2. ʵ����������
            GameObject manager = Object.Instantiate(prefab);
            manager.name = prefab.name; // ����ԭ�������ظ�
            Object.DontDestroyOnLoad(manager);
            Debug.Log($"����ȫ�ֹ�����: {manager.name}");
        }
    }
}
