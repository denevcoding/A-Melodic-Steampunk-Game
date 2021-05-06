using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public enum CharacterStates
{
    idle = 0,
    jumping = 1,
    Running = 2,

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

    private PlayerJump jumpComponent;
    private ParachuteComponent parachuteComponent;

    public CameraHandler camera;
    public CharacterStates playerState;


    [SerializeField]
    private KeyCode jumpKey;
    private KeyCode parachuteKey;


    public bool isGrounded;


    [SerializeField]
    private LayerMask platformMask;


    void Awake()
    {
        jumpComponent = GetComponent<PlayerJump>();
        parachuteComponent = GetComponent<ParachuteComponent>();

        boxCollider = GetComponent<CapsuleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();

        BaseSMB[] bsmbs = animatorPlayer.GetBehaviours<BaseSMB>();
        foreach (BaseSMB smb in bsmbs)
        {
            smb.pCharacter = this;
        }

        SteampunkComponent[] ninjaComponents = GetComponents<SteampunkComponent>();
        foreach (SteampunkComponent steamComp in ninjaComponents)
        {
            steamComp.playerCharacter = this;
        }
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

        if (Input.GetKeyDown(jumpKey))
        {
            jumpComponent.StartAction();
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    parachuteComponent.StartAction();
        //}

        ////Debug.Log(rigidBody.velocity);

        //switch (playerState)
        //{
        //    case CharacterStates.idle:
        //        break;
        //    case CharacterStates.jumping:
        //        break;
        //    case CharacterStates.moving:
        //        break;
        //    case CharacterStates.stunned:
        //        break;
        //    case CharacterStates.dead:              
        //        //Debug.Log(rigidBody.velocity);
        //        break;
        //    case CharacterStates.falling:
               
        //        break;
        //    default:
        //        break;
        //}
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

        //if (rigidBody.velocity.y < 0 && playerState != CharacterStates.jumping && playerState != CharacterStates.flying)
        //{    

        //    SetState(CharacterStates.falling);
        //}
    }

}
