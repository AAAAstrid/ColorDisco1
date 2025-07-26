using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public List<string> NextSceneName;

    //创建场景列表
    //每次加载场景时，都会从列表中取出场景名称的对应编号

    //若有触发器，则直接触发场景切换
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadNextScene(0);
        }
    }

    public void LoadNextScene(int i)
    {
        // 使用 Unity 的场景管理器加载下一个场景
        SceneManager.LoadScene(this.NextSceneName[i]);
    }
}
