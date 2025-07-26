using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

//namespace SaveSystemTutorial
//{
    public static class SaveSystem
    {
        #region PlayerPrefs�浵
        //�浵
        public static void SaveByPlayerPrefs(string key, object data)
        {
            //������תΪ�ַ���
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        //����
        public static string LoadFromPlayerPrefs(string key)
        {
            return PlayerPrefs.GetString(key, null);
        }

        #endregion

        #region JSON�浵

        //�浵
        public static void SaveByJson(string saveFileName, object data)
        {
            var json = JsonUtility.ToJson(data);
            //Application����¼�벻ͬƽ̨������
            var path = Path.Combine(Application.persistentDataPath, saveFileName);


            try
            {
                File.WriteAllText(path, json);
                Debug.Log($"�浵�ɹ���·���� {path} ");
            }
            catch (System.Exception e)
            {
                Debug.Log($"�浵ʧ�ܣ�·��{path}��\n{e}");
            }
        }

        public static T LoadFromJson<T>(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);


            try
            {
                //��ȡ�ļ�
                var json = File.ReadAllText(path);
                //��Jsonת�Ʒ�������
                var data = JsonUtility.FromJson<T>(json);
                //��������
                return data;
            }
            catch (System.Exception e)
            {
                
                Debug.Log($"����ʧ�ܣ�·��{path},\n{e}");
                return default;
            }
        }

        //ɾ���浵
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);

            try
            {
                File.Delete(path);
            }catch (System.Exception e)
            {
                Debug.Log($"ɾ��ʧ�ܣ�·��{path},\n{e}");
            }

        }

        #endregion
    }
//}
