using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<string> NextSceneName;

    //���������б�
    //ÿ�μ��س���ʱ��������б���ȡ���������ƵĶ�Ӧ���

    //���д���������ֱ�Ӵ��������л�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadNextScene(0);
        }
    }

    public void LoadNextScene(int i)
    {
        // ʹ�� Unity �ĳ���������������һ������
        SceneManager.LoadScene(this.NextSceneName[i]);
    }
}
