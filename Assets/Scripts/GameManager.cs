using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused = true;
    public GameObject menuGO;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpPause();
    }

    private void Update()
    {
        //游戏暂停
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    //游戏暂停
    private void Pause()
    {
        isPaused = true;
        //打开菜单
        menuGO.SetActive(true);
        //暂停游戏时间
        Time.timeScale = 0;
        ////鼠标可见
        //Cursor.visible = true;
    }

    //游戏未暂停
    private void UpPause()
    {
        isPaused = false;
        menuGO.SetActive(false);
        Time.timeScale = 1;
        ////鼠标不可见
        //Cursor.visible = false;
    }

    //重新启动游戏
    public void ContinueGame()
    {
        UpPause();
    }

    //取消时间暂停
    public void UITimeContinue()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    //重新加载场景
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menuGO.SetActive(false);
        isPaused = false;
    }
}
