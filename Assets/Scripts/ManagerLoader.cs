using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadManagers()
    {
        // ����Resources/Managers������Ԥ����
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Assets/Resources/Prefabs/DontDistory");
        foreach (var prefab in prefabs)
        { 

            // ����Ƿ��Ѵ��ڸ����͵�ʵ��
            var existing = Object.FindObjectOfType(prefab.GetComponent<MonoBehaviour>().GetType());
            //if (existing == null)
            //{
                GameObject manager = Object.Instantiate(prefab);
                manager.name = prefab.name;
                Object.DontDestroyOnLoad(manager);
                Debug.Log($"�Ѵ���: {manager.name}");
            //}
        }


        Debug.Log("ȫ�ֹ�����Ԥ�����Ѽ���");
    }
}
