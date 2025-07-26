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
        //��Ϸ��ͣ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    //��Ϸ��ͣ
    private void Pause()
    {
        isPaused = true;
        //�򿪲˵�
        menuGO.SetActive(true);
        //��ͣ��Ϸʱ��
        Time.timeScale = 0;
        ////���ɼ�
        //Cursor.visible = true;
    }

    //��Ϸδ��ͣ
    private void UpPause()
    {
        isPaused = false;
        menuGO.SetActive(false);
        Time.timeScale = 1;
        ////��겻�ɼ�
        //Cursor.visible = false;
    }

    //����������Ϸ
    public void ContinueGame()
    {
        UpPause();
    }

    //ȡ��ʱ����ͣ
    public void UITimeContinue()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    //���¼��س���
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menuGO.SetActive(false);
        isPaused = false;
    }
}
