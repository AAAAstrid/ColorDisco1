using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerDye : MonoBehaviour
{
    public enum DyeState
    {
       white, //白色
        Yellow, //黄色
        Blue, //蓝色
        Red, //红色
        Green, //绿色
        Purple, //紫色
        Black //黑色
    }

    //颜色列表
    public List<Color> colors;
    public Material playerMaterial;
    //颜色对应字典
    Dictionary<DyeState, Color> dyeColor = new Dictionary<DyeState, Color>();
    public Color playerColor;
    //染色水晶传递的颜色
    public string currentColor;

    private void Awake()
    {
        playerMaterial = GetComponent<SpriteRenderer>().material;
        // 初始化颜色列表  
        // 枚举值数量  
        int enumCount = System.Enum.GetValues(typeof(DyeState)).Length;
        // 检查 colors 列表长度  
        if (colors.Count < enumCount)
        {
            Debug.LogWarning("colors 列表长度不足，无法与 DyeState 枚举一一对应！");
            return;
        }

        // 依次映射  
        for (int i = 0; i < enumCount; i++)
        {
            dyeColor[(DyeState)i] = colors[i];
        }

        //添加染色事件  
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
    /// 染色
    /// </summary>
    /// <param name="state">要染的颜色枚举</param>
    public void Dye(string color)
    {
        currentColor = color;
        //将字符串转换为枚举类型
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

    //shift触发染色
    public void DyeColor(InputAction.CallbackContext ctx)
    {
        //吸色
        EventCenter.Broadcast(EventType.DyePlayer);
        //广播对应颜色砖块，触发功能

        //染色
        playerMaterial.SetColor("_SwardColor", playerColor);
    }
}
