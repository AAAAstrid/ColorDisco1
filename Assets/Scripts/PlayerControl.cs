using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField] float jumpHeight = 5f;  //��Ծ�߶�
    [SerializeField] float gravityScale = 3f; //��������ֵ
    [SerializeField] float speed = 5f; //�ƶ��ٶ�
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
        // ���ǽ��
        CheckWall();
    }


    private void FixedUpdate()
    {
        // ֻ�� velocity �����ƶ�
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    // ��ȷǽ����
    void CheckWall()
    {
        // ��ȷ�����⣨Բ�η�Χ��⣩
        isGround = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
        // ǽ���⣨��������Ϊ���棩
        isOnWall = Physics2D.Raycast(
            wallCheck.position,
            Vector2.right * transform.localScale.x,
            0.1f,
            groundLayer
        );

    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        //�ڵ��� ����ǽ ��
        //�ڵ��� ����ǽ ��
        //���ڵ��� ��ǽ ��
        //���ڵ��� ����ǽ ��
        if (!isGround && ! isOnWall || !isGround &&  isOnWall )
        {
        }
        else {
            rb.gravityScale = gravityScale;
            //������Ծ�߶ȼ�����Ծ��
            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y) * rb.gravityScale);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    public void Move(InputAction.CallbackContext ctx)
    {
        if (GameManager.instance.isPaused == false)
        {
            moveVector = ctx.ReadValue<Vector2>();
            //���﷭ת
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
