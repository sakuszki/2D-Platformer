using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private bool isDashing = false;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpforce = 5;
    public float dashForce = 5;
    public float dashTime = 0.5f;
    public float maxspeed = 10;
    public float stoppingforce = 5;
    public float enemyHitForce = 50;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();

        HandleMaxSpeed();

        PlayerStopping();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void HandleMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= maxspeed)
        {
            rigidbody2D.linearVelocityX = maxspeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxspeed)
        {
            rigidbody2D.linearVelocityX = -maxspeed;
        }

        if (rigidbody2D.linearVelocityX != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else {
            animator.SetBool("isRunning", false);
        }
        if (rigidbody2D.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }

    private void LimitMaxSpeed()
    {
        if (isDashing) ;
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingforce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }


    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnDash()
    {
        if (isDashing)
        {
            return;
        }
        isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0),ForceMode2D.Impulse);
        StartCoroutine(ResetDash(1));
    }
    IEnumerator ResetDash(float timeToReset)
    {
        yield return new WaitForSeconds(timeToReset);
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

}