using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    PlayerCharacter playerCharacter;


    [Tooltip("This number represents the force of the jump")]
    public float jumpForce;

    public bool activateDoubleJump;

    [SerializeField]
    private KeyCode jumpKey;

    public int airJumpsAmount;

 

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

        Jump();
    }


    public bool CheckPreconditions()
    {
        if (playerCharacter.GetPlayerState() == CharacterStates.dead)
            return false;
        if (!playerCharacter.IsGrounded())
            return false;

        return true;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            playerCharacter.GetRigidBodie().AddForce(Vector3.up * jumpForce);
            //camera.CameraShake(3, 1f);
        }
    }
}
