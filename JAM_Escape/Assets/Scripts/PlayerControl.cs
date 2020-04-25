using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public Animator animator;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    private SpriteRenderer renderer;
    float jumpVelocity;
    bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        doubleJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector2 position = transform.position;
        position.x = position.x + 2.8f * horizontal * Time.deltaTime;
        transform.position = position;

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)))
        {
            jumpVelocity = 4f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        if (!IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)) && doubleJump)
        {
            doubleJump = false;
            jumpVelocity = 4f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.S))
            animator.SetBool("IsCrouch", true);
        else
            animator.SetBool("IsCrouch", false);
        if (IsGrounded())
            animator.SetBool("IsJumping", false);
        else
            animator.SetBool("IsJumping", true);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        if (raycastHit2d.collider == null)
            return false;
        else
            return true;
    }

    public void RechargeJump()
    {
        doubleJump = true;
    }
}
