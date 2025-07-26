using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 关卡类
/// </summary>
[System.Serializable]
public class Level :MonoBehaviour
{
    public int levelID;
    public bool isUnlocked;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            unLockLevel();
        }

    }

    //放在终点解锁关卡按钮
    public void unLockLevel()
    {
        isUnlocked = true;

        // 解锁下一关
        int nextLevelID = levelID + 1;

        // 保存解锁进度（使用最大解锁关卡）
        int currentUnlock = PlayerPrefs.GetInt("Un_Lock_Count", 1);
        int newUnlock = Mathf.Max(currentUnlock, nextLevelID);

        PlayerPrefs.SetInt("Un_Lock_Count", newUnlock);
        PlayerPrefs.Save();

    }

}
