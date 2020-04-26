using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Cryptography;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public Animator animator;
    public Rigidbody2D rigidbody2d;
    public BoxCollider2D boxCollider2d;
    private SpriteRenderer renderer;
    public GameObject Garbage;
    float jumpVelocity;
    int doubleJump;
    public AudioSource death;
    public GameObject gameOverUI;
    Vector3 originalPos;
    public Camera mainCamera;
    public GameObject laser;
    Vector3 camPos;
    Vector3 laserPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        camPos = mainCamera.transform.position;
        laserPos = laser.transform.position;
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        doubleJump = 1;
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
        transform.rotation = Quaternion.identity;

        if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)))
        {
            jumpVelocity = 4f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        if (!IsGrounded() && (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z)) && doubleJump > 0)
        {
            doubleJump--;
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

    public void GarbageCheck()
    {
        gameObject.SetActive(false);
    }

    public void LaserCheck()
    {
        death.Play();
        gameObject.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reset() {
        Time.timeScale = 1f;
        gameObject.SetActive(true);
        transform.position = originalPos;
        laser.transform.position = laserPos;
        mainCamera.transform.position = camPos;
        gameOverUI.SetActive(false);
    }

    public void RechargeJump()
    {
        doubleJump++;
    }

    public void ExitMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
