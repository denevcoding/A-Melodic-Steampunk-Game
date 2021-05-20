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




    //Ground Interaction
    [SerializeField]
    private LayerMask platformMask;
    public bool isGrounded;

    public float slopeLimit;





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
        Application.targetFrameRate = 60;
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
        if (playerState == CharacterStates.dead)
            return;

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

        RaycastHit2D rayCastHit = Physics2D.BoxCast(origin, boxCollider.bounds.size, 0f, Vector2.down, extraDistance, platformMask);
        Color rayColor;

        if (rayCastHit.collider != null)
        {
            rayColor = Color.blue;
            if (rayCastHit.collider.gameObject.layer == LayerMask.NameToLayer("DeathPlatform"))
            {
                playerDie();
            }
        }
        else
        {
            rayColor = Color.red;
        }


        //Detecting the slope     
        RaycastHit2D surfaceNormal = Physics2D.Raycast(rayCastHit.point, rayCastHit.normal * 1.8f);
        Debug.DrawRay(rayCastHit.point, rayCastHit.normal * 1.8f, Color.magenta);

        float angle = Vector2.Angle(Vector2.right, rayCastHit.normal);
        Debug.Log("slope Angle = " + angle);

        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraDistance), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraDistance), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y), Vector2.right * (boxCollider.bounds.extents.y + extraDistance), rayColor);
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



    public void playerDie()
    {
        if (playerState == CharacterStates.dead)
            return;

        animatorPlayer.SetTrigger("dying");

        //rigidBody.simulated = false;
        playerState = CharacterStates.dead;

        rigidBody.angularVelocity = 0f;
        rigidBody.velocity = Vector2.zero;

    }

    //event Called from collition by physic Manager 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathPlatform"))
        {
            playerDie();
        }
        

        if (collision.gameObject.GetComponent<BallExperiment>() != null)
        {
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
