using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//��Ⱦɫˮ������
public class Dye : MonoBehaviour
{
    public Material material;
    public float thickness = 0.01f;
    [Header("Ⱦɫ��ɫ��Ӣ�Ĵ�д��")]
    public string color;
    private bool playerInRange = false;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat("_Thickness", 0);

        EventCenter.AddListener(EventType.DyePlayer, DyePlayer);
    }
    //Ⱦɫ
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

    //�յ�Ⱦɫ�źţ��õ�ǰ��ɫ��plȾɫ
    public void DyePlayer()
    {
        // ���Shift�����������Ⱦɫ��
        if (playerInRange )
        {
            // �����¼�������ɫ���ݳ�ȥ
            EventCenter.Broadcast<string>(EventType.DyeColor, color);
        }
        else
        {

        }
    }
}
