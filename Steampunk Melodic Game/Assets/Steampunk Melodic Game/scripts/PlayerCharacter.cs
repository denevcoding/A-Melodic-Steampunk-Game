using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    Animator animatorPlayer;

    [Tooltip("The amount of velocity to move the character")]
    public float speed = 3.0f;    
    Vector3 inputVector = Vector3.zero;
    bool isRight = true;

    public bool isGrounded;

    [SerializeField]
    private LayerMask platformMask;



    void Awake() 
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 5f, rigidBody.velocity.y, 0);
 
        animatorPlayer.SetFloat("XVelocity", Mathf.Abs(inputVector.x));


        Jump();
       

        FlipCharacter();       
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = inputVector;        
    }

    private void Jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 500.0f);
        }
    }

    private bool IsGrounded()
    {
        float extraDistance = 0.1f;

        Vector2 origin = boxCollider.bounds.center;

        RaycastHit2D rayCastHit = Physics2D.Raycast(origin, Vector2.down, boxCollider.bounds.extents.y + extraDistance, platformMask);
        Color rayColor;

        if (rayCastHit.collider != null)
        {
            rayColor = Color.blue;
        }
        else
        {
            rayColor = Color.red;           
        }

        Debug.DrawRay(origin, Vector2.down * (boxCollider.bounds.extents.y + extraDistance), rayColor);
        Debug.Log(rayCastHit.collider);        

        return rayCastHit.collider != null;
    }


    private void FlipCharacter()
    {
        if (inputVector.x < 0 && isRight || inputVector.x > 0 && !isRight)
        {
            isRight = !isRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }


    //event Called from collition by physic Manager 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Chocó " + collision.gameObject.name);
    }
}
