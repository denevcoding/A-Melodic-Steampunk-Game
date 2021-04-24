using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterStates
{
    idle = 0,
    jumping = 1,
    moving = 2,
    stunned = 3,
    dead = 4,
    falling = 5,
    flying = 6,
}


public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private CapsuleCollider2D boxCollider;
    private Animator animatorPlayer;

    public CameraHandler camera;

    private CharacterStates playerState;

    public bool isGrounded;

    [SerializeField]
    private LayerMask platformMask;


    void Awake()
    {
        boxCollider = GetComponent<CapsuleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.Find("CM vcam1").GetComponent<CameraHandler>();
        playerState = CharacterStates.idle;
    }

    public void InitPlayer(Vector3 initPosition)
    {
        Vector3 position = initPosition;
        position.z = 0;
        this.transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();

        //Debug.Log(rigidBody.velocity);

        switch (playerState)
        {
            case CharacterStates.idle:
                break;
            case CharacterStates.jumping:
                break;
            case CharacterStates.moving:
                break;
            case CharacterStates.stunned:
                break;
            case CharacterStates.dead:              
                //Debug.Log(rigidBody.velocity);
                break;
            default:
                break;
        }
    }


    public bool IsGrounded()
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
        // Debug.Log(rayCastHit.collider);

        animatorPlayer.SetBool("isGrounded", rayCastHit.collider != null);
        return rayCastHit.collider != null;
    }

    #region Auxiliar funcs
    public Rigidbody2D GetRigidBodie()
    {
        return rigidBody;
    }
    public CapsuleCollider2D GetColldier()
    {
        return boxCollider;
    }
    public Animator GetAnimator()
    {
        return animatorPlayer;
    }
    #endregion  



    public CharacterStates GetPlayerState()
    {
        return playerState;
    }
    public void SetState(CharacterStates state)
    {
        playerState = state;
    }


    //event Called from collition by physic Manager 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BallExperiment>() != null)
        {
            animatorPlayer.SetTrigger("dying");

            //rigidBody.simulated = false;
            playerState = CharacterStates.dead;

            rigidBody.angularVelocity = 0f;
            rigidBody.velocity = Vector2.zero;
       

            Destroy(collision.gameObject); 

          //  camera.CameraShake(1f, 2f);
        }
    }
    public void FixedUpdate()
    {
        animatorPlayer.SetFloat("YVelocity", rigidBody.velocity.y);
    }

}
