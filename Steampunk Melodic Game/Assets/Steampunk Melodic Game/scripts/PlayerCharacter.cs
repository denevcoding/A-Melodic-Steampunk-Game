using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float force = 1;
    public float speed = 3.0f;
    Vector3 moveDirection = Vector2.zero;
    Animator animatorPlayer;
    Vector3 inputVector = Vector3.zero;

    void Awake() 
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        animatorPlayer = this.gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 5f, rigidBody.velocity.y, 0);

        //moveDirection.x = Input.GetAxis("Horizontal");
        //moveDirection.y = rigidBody.velocity.y;
        animatorPlayer.SetFloat("XVelocity", Mathf.Abs(inputVector.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * 500.0f);
        }
        if (inputVector.x > 0)
        {

        }
        else if (inputVector.x < 0)
        {
            Vector3 rotationVector = new Vector3(0,-180,0);
            //transform.rotation = rotationVector;
        }
       
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * force;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = inputVector;
        //rigidBody.MovePosition();


    }
}
