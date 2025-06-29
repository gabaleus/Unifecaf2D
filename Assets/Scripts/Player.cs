using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;

    private float move;
    private bool isOnFloor;
    private bool isMoving;
    private bool isOnLadder;
    private AudioSource JumpSound;
    

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnLadder)
        {
            float moveVertical = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, moveVertical * speed * Time.deltaTime, 0);
        }
        move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
            JumpSound.Play();
            isOnFloor = false;
        }


            if (move > 0)
            {
                isMoving = true;
                sprite.flipX = false;
            }
            else if (move < 0)
            {
                isMoving = true;
                sprite.flipX = true;
            }
            else
            {
                isMoving = false;
            }
            anim.SetBool("isMoving", isMoving);
            anim.SetBool("isOnFloor", isOnFloor);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnFloor = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = true;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop horizontal movement when on ladder
            rb.linearVelocity = Vector2.zero; // Reset velocity to prevent sliding
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Ensure no vertical movement
            rb.gravityScale = 0; // Disable gravity when on ladder
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y); // Restore horizontal movement when leaving ladder
            rb.gravityScale = 2; // Re-enable gravity when leaving ladder
        }
    }
}
