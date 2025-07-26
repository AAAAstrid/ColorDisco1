using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] float jumpHeight = 5f;  //跳跃高度
    [SerializeField] float gravityScale = 3f; //重力缩放值
    [SerializeField] float speed = 5f; //移动速度
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    [SerializeField] private bool isGround;
    [SerializeField] private bool isOnWall;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundLayer;




    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        // 检测墙面
        CheckWall();
    }


    private void FixedUpdate()
    {
        // 只用 velocity 控制移动
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    // 精确墙面检测
    void CheckWall()
    {
        // 精确地面检测（圆形范围检测）
        isGround = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        // 墙面检测（避免误判为地面）
        isOnWall = Physics2D.Raycast(
            wallCheck.position,
            Vector2.right * transform.localScale.x,
            0.1f,
            groundLayer
        );

    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        //在地面 在贴墙 √
        //在地面 不贴墙 √
        //不在地面 贴墙 ×
        //不在地面 不贴墙 ×
        if (!isGround && ! isOnWall || !isGround &&  isOnWall )
        {
        }
        else {
            rb.gravityScale = gravityScale;
            //根据跳跃高度计算跳跃力
            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y) * rb.gravityScale);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (GameManager.instance.isPaused == false)
        {
            moveVector = ctx.ReadValue<Vector2>();
            //人物翻转
            int faceDir = (int)transform.localScale.x;
            if (moveVector.x > 0)
            {
                faceDir = 1;
            }
            if (moveVector.x < 0)
            {
                faceDir = -1;
            }
            transform.localScale = new Vector3(faceDir, 1, 1);
        }
    }
    private void OnDrawGizmos()
    {


        Gizmos.color = Color.red;
        Gizmos.DrawRay(wallCheck.position, Vector2.right * transform.localScale.x * 0.1f);
   
    }
}
