using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //����ģʽ
    public static LevelSelect instance;
    //�ؿ��б�
    public List<Button> LevelButtons;
    //��ͨ�صı�����¼
    [SerializeField] private int unLockCount = 1;
    //ɾ������
    public bool Delete = false;
    //���ݴ浵�ļ�
    public const string Un_Lock_Count = "Un_Lock_Count";

    private void Awake()
    {
        instance = this;


    }

    private void Start()
    {
        // 1. ��ȡ�浵
        LoadFromPlayerPrefs();

        // 2. ��ʼ����ť״̬�����ڴ浵��
        RefreshButtonStates();

    }

    // �����ؿ���i��1��ʼ��
    public void unLockButton(int i)
    {
        // ȷ���ؿ�ID��Ч
        if (i < 1 || i > LevelButtons.Count)
        {
            Debug.LogWarning($"��Ч�Ĺؿ�ID: {i}");
            return;
        }

        // ���½���������ȡ���ֵ��ֹ���ˣ�
        unLockCount = Mathf.Max(unLockCount, i);

        // �����������
        SaveUnLock();

        // ˢ�°�ť״̬
        RefreshButtonStates();
    }

    // �����������
    void SaveUnLock()
    {
        PlayerPrefs.SetInt(Un_Lock_Count, unLockCount);
        PlayerPrefs.Save();
        Debug.Log($"�ѱ����������: ��������{unLockCount}��");
    }

    // ��ȡ�浵
    void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(Un_Lock_Count))
        {
            unLockCount = PlayerPrefs.GetInt(Un_Lock_Count);
            Debug.Log($"�Ӵ浵���ؽ�������: �ѽ�������{unLockCount}��");
        }
        else
        { 
            SaveUnLock(); // ������ʼ�浵
        }
    }

    // ˢ�°�ť״̬
    private void RefreshButtonStates()
    {
        
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            // �ؿ�������1��ʼ������i+1��ʾ�ؿ���
            bool isUnlocked = (i + 1) <= unLockCount;

            LevelButtons[i].interactable = isUnlocked;

        }
    }

    // ɾ���浵����Ӳ˵������ԣ�
    [ContextMenu("ɾ���浵")]
    public void DeletePlayerDataFile()
    {
        PlayerPrefs.DeleteKey(Un_Lock_Count);
        PlayerPrefs.Save();

        // ���ý���״̬
        unLockCount = 1;

        // ˢ��UI
        RefreshButtonStates();

        Debug.Log("��ɾ���浵������Ϊ��һ�ؽ���");
    }

    // �����ã�������һ��
    [ContextMenu("���Խ�����һ��")]
    public void TestUnlockNextLevel()
    {
        unLockButton(unLockCount + 1);
    }

}
