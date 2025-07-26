using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public bool isContinue = false;
    public Button ContinueButton;

    private void Update()
    {
        //OpenContinueButton();
    }

    public void OpenContinueButton()
    {
        if (isContinue)
        {
            ContinueButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            ContinueButton.GetComponent<Button>().interactable = false;
        }
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

    }
}
