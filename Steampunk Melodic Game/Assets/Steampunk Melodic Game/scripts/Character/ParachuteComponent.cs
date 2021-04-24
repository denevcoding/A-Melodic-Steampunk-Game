using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ParachuteComponent : SteampunkComponent
{
    Animator animatorPlayer;
    Rigidbody2D rigidbodyCharacter;

    // Start is called before the first frame update
    private void Awake()
    {
        animatorPlayer = GetComponent<Animator>();        
        rigidbodyCharacter = GetComponent<Rigidbody2D>();
    }
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {      
        if (Input.GetMouseButton(1) && !playerCharacter.IsGrounded() && playerCharacter.GetPlayerState() != CharacterStates.jumping)
        {
            animatorPlayer.SetBool("parachute", true);
            rigidbodyCharacter.gravityScale = 1;
            playerCharacter.SetState(CharacterStates.flying);
        }
        else
        {
            animatorPlayer.SetBool("parachute", false);
            rigidbodyCharacter.gravityScale = 5;           
        }
    }

    public override bool CheckPreconditions()
    {
        //if (base.CheckPreconditions() == false)
        //    return false;
        //else
        //{
        //    if (playerCharacter.GetPlayerState() != CharacterStates.falling && )
        //        return false;

        //    if (playerCharacter.isGrounded == true)
        //        return false;
        //}

        return true;
    }
}
