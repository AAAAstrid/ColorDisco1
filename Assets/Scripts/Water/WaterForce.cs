using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 让pl与水接触时，可以额外向下或向上运动，获得额外的力
/// </summary>
public class WaterForce : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    [SerializeField]
    private float forceAmount;
    // Start is called before the first frame update
    void Start()
    {
        //获取玩家的刚体
        PlayerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //若玩家进入水中，则可以向上或向下使用力来沉浮
        if (collision == collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
