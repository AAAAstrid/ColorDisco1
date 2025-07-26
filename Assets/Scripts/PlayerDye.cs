using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerDye : MonoBehaviour
{
    public enum DyeState
    {
       white, //��ɫ
        Yellow, //��ɫ
        Blue, //��ɫ
        Red, //��ɫ
        Green, //��ɫ
        Purple, //��ɫ
        Black //��ɫ
    }

    //��ɫ�б�
    public List<Color> colors;
    public Material playerMaterial;
    //��ɫ��Ӧ�ֵ�
    Dictionary<DyeState, Color> dyeColor = new Dictionary<DyeState, Color>();
    public Color playerColor;
    //Ⱦɫˮ�����ݵ���ɫ
    public string currentColor;

    private void Awake()
    {
        playerMaterial = GetComponent<SpriteRenderer>().material;
        // ��ʼ����ɫ�б�  
        // ö��ֵ����  
        int enumCount = System.Enum.GetValues(typeof(DyeState)).Length;
        // ��� colors �б���  
        if (colors.Count < enumCount)
        {
            Debug.LogWarning("colors �б��Ȳ��㣬�޷��� DyeState ö��һһ��Ӧ��");
            return;
        }

        // ����ӳ��  
        for (int i = 0; i < enumCount; i++)
        {
            dyeColor[(DyeState)i] = colors[i];
        }

        //���Ⱦɫ�¼�  
        EventCenter.AddListener<string>(EventType.DyeColor, Dye);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerColor = dyeColor[DyeState.white];
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Ⱦɫ
    /// </summary>
    /// <param name="state">ҪȾ����ɫö��</param>
    public void Dye(string color)
    {
        currentColor = color;
        //���ַ���ת��Ϊö������
        if (System.Enum.TryParse<DyeState>(color, true, out var dyeState))
        {
            if (dyeColor.TryGetValue(dyeState, out Color c))
            {
                playerColor = c;
            }
            else
            {
  
            }
        }
    }

    //shift����Ⱦɫ
    public void DyeColor(InputAction.CallbackContext ctx)
    {
        //��ɫ
        EventCenter.Broadcast(EventType.DyePlayer);
        //�㲥��Ӧ��ɫש�飬��������

        //Ⱦɫ
        playerMaterial.SetColor("_SwardColor", playerColor);
    }
}
