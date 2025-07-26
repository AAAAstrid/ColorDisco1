using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//放染色水晶身上
public class Dye : MonoBehaviour
{
    public Material material;
    public float thickness = 0.01f;
    [Header("染色颜色（英文大写）")]
    public string color;
    private bool playerInRange = false;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Thickness", 0);

        EventCenter.AddListener(EventType.DyePlayer, DyePlayer);
    }
    //染色
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            material.SetFloat("_Thickness", thickness);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            material.SetFloat("_Thickness", 0);
            playerInRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //收到染色信号，用当前颜色给pl染色
    public void DyePlayer()
    {
        // 检测Shift按下且玩家在染色区
        if (playerInRange )
        {
            // 触发事件，把颜色传递出去
            EventCenter.Broadcast<string>(EventType.DyeColor, color);
        }
        else
        {

        }
    }
}
