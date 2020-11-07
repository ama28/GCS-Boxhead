using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    public Vector2 facingDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        if ((x != 0) || (y != 0))
        {
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);
            facingDir.x = x;
            facingDir.y = y;
        }
        
        Vector2 moveInput = new Vector2(x, y);
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}

//public class BasicMovement : MonoBehaviour
//{
//    public float speed;
//    private Rigidbody2D rb;
//    private Vector2 moveVelocity;
//    public Animator animator;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
//        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

//        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
//        moveVelocity = moveInput.normalized * speed;
//    }

//    private void FixedUpdate()
//    {
//        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
//    }
//}
