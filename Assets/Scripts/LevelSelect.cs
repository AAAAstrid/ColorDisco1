using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //单例模式
    public static LevelSelect instance;
    //关卡列表
    public List<Button> LevelButtons;
    //已通关的变量记录
    [SerializeField] private int unLockCount = 1;
    //删档开关
    public bool Delete = false;
    //数据存档文件
    public const string Un_Lock_Count = "Un_Lock_Count";

    private void Awake()
    {
        instance = this;


    }

    private void Start()
    {
        // 1. 读取存档
        LoadFromPlayerPrefs();

        // 2. 初始化按钮状态（基于存档）
        RefreshButtonStates();

    }

    // 解锁关卡（i从1开始）
    public void unLockButton(int i)
    {
        // 确保关卡ID有效
        if (i < 1 || i > LevelButtons.Count)
        {
            Debug.LogWarning($"无效的关卡ID: {i}");
            return;
        }

        // 更新解锁计数（取最大值防止回退）
        unLockCount = Mathf.Max(unLockCount, i);

        // 保存解锁进度
        SaveUnLock();

        // 刷新按钮状态
        RefreshButtonStates();
    }

    // 保存解锁进度
    void SaveUnLock()
    {
        PlayerPrefs.SetInt(Un_Lock_Count, unLockCount);
        PlayerPrefs.Save();
        Debug.Log($"已保存解锁进度: 解锁到第{unLockCount}关");
    }

    // 读取存档
    void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(Un_Lock_Count))
        {
            unLockCount = PlayerPrefs.GetInt(Un_Lock_Count);
            Debug.Log($"从存档加载解锁进度: 已解锁到第{unLockCount}关");
        }
        else
        { 
            SaveUnLock(); // 创建初始存档
        }
    }

    // 刷新按钮状态
    private void RefreshButtonStates()
    {
        
        for (int i = 0; i < LevelButtons.Count; i++)
        {
            // 关卡索引从1开始，所以i+1表示关卡号
            bool isUnlocked = (i + 1) <= unLockCount;

            LevelButtons[i].interactable = isUnlocked;

        }
    }

    // 删除存档（添加菜单项方便测试）
    [ContextMenu("删除存档")]
    public void DeletePlayerDataFile()
    {
        PlayerPrefs.DeleteKey(Un_Lock_Count);
        PlayerPrefs.Save();

        // 重置解锁状态
        unLockCount = 1;

        // 刷新UI
        RefreshButtonStates();

        Debug.Log("已删除存档，重置为第一关解锁");
    }

    // 测试用：解锁下一关
    [ContextMenu("测试解锁下一关")]
    public void TestUnlockNextLevel()
    {
        unLockButton(unLockCount + 1);
    }

}
