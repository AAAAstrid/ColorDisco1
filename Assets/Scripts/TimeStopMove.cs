using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopMove : MonoBehaviour
{
    public static bool isMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isMove = true;
            Time.timeScale = 0.1f; // Slow down time
        }
    }
}
