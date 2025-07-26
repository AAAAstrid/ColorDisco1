using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class Yellow : MonoBehaviour
{
    public TilemapCollider2D collider;
    public GameObject player;
    public bool isYellow = false;

    private void Awake()
    {
        collider = GetComponent<TilemapCollider2D>();
        player =GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerDye>().currentColor == "Yellow") 
        {
            isYellow = true;
        }
        else
        {
            isYellow = false;
        }
        isCollisionEnabled();
    }

    //pl染成黄色后，变成可穿过的状态
    public void isCollisionEnabled()
    {
        if (isYellow)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }
}
