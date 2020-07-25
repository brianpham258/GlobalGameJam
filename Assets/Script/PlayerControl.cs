using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    // Player RigidBody
    public Rigidbody2D theRB;
    public Animator ani;
    public Collider2D myCollider;
    public CircleCollider2D interactCol;

    [SerializeField] public float moveSpeed = 3;
    [SerializeField] public int jumpSpeed = 5;
    public float speedMulti;
    public float speed = 3f;
    private float time;


    public void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        interactCol = GetComponent<CircleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && FindObjectOfType<GameDataS>().getStamina() > 0) 
        {
            moveSpeed = speed * speedMulti;
            FindObjectOfType<GameDataS>().setStamina();
        }
        else
        {
            moveSpeed = speed;
        }
        if (theRB != null)
        {
            run();
            jump();
            flip();
        }
        else
        {
            Debug.Log("Player not attach" + gameObject);
        }
        /*Debug.Log(stamina);
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("interact")))
        {
            stamina += 200;
        }*/



    }


    public void run()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 playerVelocity = new Vector2(inputX * moveSpeed, theRB.velocity.y);
        theRB.velocity = playerVelocity;
        bool playerHorizontalSpeed = Mathf.Abs(theRB.velocity.x) > Mathf.Epsilon;
        ani.SetBool("Running", playerHorizontalSpeed);

    }

    public void jump()
    {
        if (!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            theRB.velocity += jumpVelocity;
            //debugging
            //FindObjectOfType<GameDataS>().playerGameOver();
        }
        //bool playerVerticalSpeed = Mathf.Abs(theRB.velocity.y) > Mathf.Epsilon;
        //ani.SetBool("Jumping", playerVerticalSpeed);
    }

    public void flip()
    {
        bool playerHorizontalSpeed = Mathf.Abs(theRB.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(theRB.velocity.x), 1f);
        }
    }
}