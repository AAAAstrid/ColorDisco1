using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//namespace SaveSystemTutorial
//{
    public class PlayerData:MonoBehaviour
    {
        [Header("���ݱ���")]
        [SerializeField] string playerName = "���������";


        private const string Player_Data_Key = "��������ַ���";
        private const string Player_Data_File_Name = "PlayerData.save"; //���ݴ浵�ļ���
        /// <summary>
        /// ��װ�������
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
            //����������
            var saveData = new SaveData();
            //��ֵ����
            saveData.playerName = this.playerName;
            return saveData;
        }


        #region PlayerPrefs�浵

        void SaveByPlayerPrefs()
        {
            //���ô浵ϵͳ
            SaveSystem.SaveByPlayerPrefs(Player_Data_Key, SavingData());
        }
    void LoadData(SaveData saveData)
    {
        //���¸�ֵ
        this.playerName = saveData.playerName;
    }


    void LoadFromPlayerPrefs()
        {
            //��ȡ����
            var json = SaveSystem.LoadFromPlayerPrefs(Player_Data_Key);
            //������ת��Ϊjson��ʽ
            var saveData = JsonUtility.FromJson<SaveData>(json);
            LoadData(saveData);

        }

        


        //ɾ���浵
        //[UnityEditor.MenuItem("Developer/Delete Player Data Prefs")] //ֱ����unity�˵�����ɾ���浵
        public static void DeletePlayerDataPrefs()
        {
            //ɾ���������
            PlayerPrefs.DeleteKey(Player_Data_Key);
        }

        #endregion

        #region ͨ��Json�浵

        //�浵
        void SaveByJson()
        {
            SaveSystem.SaveByJson(Player_Data_File_Name, SavingData());
            //��һ�ִ浵�����ɼ�¼��ǰϵͳʱ��
            //SaveSystem.SaveByJson($"{System.DateTime.Now: yyyy:dd:M HH-mm-ss}.sav",SavingData());
        }

        //����
        void LoadFromJson()
        {
            var savedata = SaveSystem.LoadFromJson<SaveData>(Player_Data_File_Name);
            LoadData(savedata);
        }

        //ɾ��
        //[UnityEditor.MenuItem("Developer/Delete Player Data File")] //ֱ����unity�˵�����ɾ���浵
        public static void DeletePlayerDataFile()
        {
            SaveSystem.DeleteSaveFile(Player_Data_File_Name);
        }
        #endregion
    }
//}

