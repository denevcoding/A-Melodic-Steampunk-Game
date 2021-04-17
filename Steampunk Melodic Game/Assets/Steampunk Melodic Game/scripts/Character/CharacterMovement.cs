using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    PlayerCharacter playerCharacter;

    [Tooltip("The amount of velocity to move the character")]
    public float groundSpeed = 3.0f;
    public float airSpeed = 3.0f;



    Vector3 inputVector = Vector3.zero;
    bool isRight = true;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckPreconditions())
            return;

        Move();
        FlipCharacter();
    }


    public bool CheckPreconditions() 
    {
        if (playerCharacter.GetPlayerState() == CharacterStates.dead)            
            return false;
           

        if (playerCharacter.GetPlayerState() == CharacterStates.stunned)
            return false;

        return true;
    
    }

    public void Move()
    {
        if (playerCharacter.IsGrounded())
        {
            // on the flooe
            MoveGround();
            playerCharacter.SetState(CharacterStates.running);
        }
        else
        {
            // ont the air
            MoveAir();
        }


    }

    //When player is falling or not touiching the floor
    public void MoveAir() 
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * airSpeed, playerCharacter.GetRigidBodie().velocity.y, 0);
        playerCharacter.GetAnimator().SetFloat("XVelocity", Mathf.Abs(inputVector.x));
    }
    public void MoveGround()
    {
        //When playert is touching the floor
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * groundSpeed, playerCharacter.GetRigidBodie().velocity.y, 0);
        playerCharacter.GetAnimator().SetFloat("XVelocity", Mathf.Abs(inputVector.x));
        playerCharacter.SetState(CharacterStates.running);
    }

    private void FlipCharacter()
    {
        if (inputVector.x < 0 && isRight || inputVector.x > 0 && !isRight)
        {
            isRight = !isRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void FixedUpdate()
    {
        if (!CheckPreconditions())
            return;
        playerCharacter.GetRigidBodie().velocity = inputVector;
        //Debug.Log("YVelocity " + playerCharacter.GetRigidBodie().velocity.y);
        playerCharacter.GetAnimator().SetFloat("YVelocity", playerCharacter.GetRigidBodie().velocity.y);
    }
}
