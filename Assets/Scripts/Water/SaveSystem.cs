using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

//namespace SaveSystemTutorial
//{
    public static class SaveSystem
    {
        #region PlayerPrefs存档
        //存档
        public static void SaveByPlayerPrefs(string key, object data)
        {
            //把数据转为字符串
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        //读档
        public static string LoadFromPlayerPrefs(string key)
        {
            return PlayerPrefs.GetString(key, null);
        }

        #endregion

        #region JSON存档

        //存档
        public static void SaveByJson(string saveFileName, object data)
        {
            var json = JsonUtility.ToJson(data);
            //Application用于录入不同平台的数据
            var path = Path.Combine(Application.persistentDataPath, saveFileName);


            try
            {
                File.WriteAllText(path, json);
                Debug.Log($"存档成功！路径： {path} ");
            }
            catch (System.Exception e)
            {
                Debug.Log($"存档失败！路径{path}。\n{e}");
            }
        }

        public static T LoadFromJson<T>(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);


            try
            {
                //读取文件
                var json = File.ReadAllText(path);
                //把Json转称泛型数据
                var data = JsonUtility.FromJson<T>(json);
                //返回数据
                return data;
            }
            catch (System.Exception e)
            {
                
                Debug.Log($"读档失败！路径{path},\n{e}");
                return default;
            }
        }

        //删除存档
        public static void DeleteSaveFile(string saveFileName)
        {
            var path = Path.Combine(Application.persistentDataPath, saveFileName);

            try
            {
                File.Delete(path);
            }catch (System.Exception e)
            {
                Debug.Log($"删档失败！路径{path},\n{e}");
            }

        }

        #endregion
    }
//}
