using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//namespace SaveSystemTutorial
//{
    public class PlayerData:MonoBehaviour
    {
        [Header("数据变量")]
        [SerializeField] string playerName = "具体玩家名";


        private const string Player_Data_Key = "玩家数据字符串";
        private const string Player_Data_File_Name = "PlayerData.save"; //数据存档文件名
        /// <summary>
        /// 封装玩家数据
        /// </summary>
       [System.Serializable] class SaveData
        {
            public string playerName;
        }

        public void Save()
        {
            SaveByPlayerPrefs();
            SaveByJson();
        }

        public void Load()
        {
            LoadFromPlayerPrefs();
            LoadFromJson();
        }

        SaveData SavingData()
        {
            //创建数据类
            var saveData = new SaveData();
            //赋值数据
            saveData.playerName = this.playerName;
            return saveData;
        }


        #region PlayerPrefs存档

        void SaveByPlayerPrefs()
        {
            //调用存档系统
            SaveSystem.SaveByPlayerPrefs(Player_Data_Key, SavingData());
        }
    void LoadData(SaveData saveData)
    {
        //重新赋值
        this.playerName = saveData.playerName;
    }


    void LoadFromPlayerPrefs()
        {
            //读取数据
            var json = SaveSystem.LoadFromPlayerPrefs(Player_Data_Key);
            //把数据转换为json格式
            var saveData = JsonUtility.FromJson<SaveData>(json);
            LoadData(saveData);

        }

        


        //删除存档
        //[UnityEditor.MenuItem("Developer/Delete Player Data Prefs")] //直接在unity菜单栏可删除存档
        public static void DeletePlayerDataPrefs()
        {
            //删除玩家数据
            PlayerPrefs.DeleteKey(Player_Data_Key);
        }

        #endregion

        #region 通过Json存档

        //存档
        void SaveByJson()
        {
            SaveSystem.SaveByJson(Player_Data_File_Name, SavingData());
            //另一种存档名，可记录当前系统时间
            //SaveSystem.SaveByJson($"{System.DateTime.Now: yyyy:dd:M HH-mm-ss}.sav",SavingData());
        }

        //读档
        void LoadFromJson()
        {
            var savedata = SaveSystem.LoadFromJson<SaveData>(Player_Data_File_Name);
            LoadData(savedata);
        }

        //删除
        //[UnityEditor.MenuItem("Developer/Delete Player Data File")] //直接在unity菜单栏可删除存档
        public static void DeletePlayerDataFile()
        {
            SaveSystem.DeleteSaveFile(Player_Data_File_Name);
        }
        #endregion
    }
//}

