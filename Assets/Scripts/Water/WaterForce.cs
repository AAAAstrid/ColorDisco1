using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��pl��ˮ�Ӵ�ʱ�����Զ������»������˶�����ö������
/// </summary>
public class WaterForce : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    [SerializeField]
    private float forceAmount;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��ҵĸ���
        PlayerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //����ҽ���ˮ�У���������ϻ�����ʹ����������
        if (collision == collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
