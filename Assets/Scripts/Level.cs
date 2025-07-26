using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �ؿ���
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

    //�����յ�����ؿ���ť
    public void unLockLevel()
    {
        isUnlocked = true;

        // ������һ��
        int nextLevelID = levelID + 1;

        // ����������ȣ�ʹ���������ؿ���
        int currentUnlock = PlayerPrefs.GetInt("Un_Lock_Count", 1);
        int newUnlock = Mathf.Max(currentUnlock, nextLevelID);

        PlayerPrefs.SetInt("Un_Lock_Count", newUnlock);
        PlayerPrefs.Save();

    }

}
