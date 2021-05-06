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


    public override void StartAction()
    {
        //base.StartAction();
        if (playerCharacter.GetPlayerState() != CharacterStates.flying)
        {
            animatorPlayer.SetBool("parachute", true);
            rigidbodyCharacter.gravityScale = 1;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (playerCharacter.GetPlayerState() == CharacterStates.flying)
        {
            if (playerCharacter.IsGrounded())
                EndAction();
        }

        if (Input.GetMouseButton(1))
        {
            if (CheckPreconditions() == false)
                return;

            StartAction();
        }
        else
        {
            EndAction();
        }
    }


    public void EndAction()
    {
        if (playerCharacter.GetPlayerState() == CharacterStates.flying)
        {
            animatorPlayer.SetBool("parachute", false);
            rigidbodyCharacter.gravityScale = 5;
        }
    }




    public override bool CheckPreconditions()
    {
        if (base.CheckPreconditions() == false)
            return false;
        else
        {
            if (playerCharacter.IsGrounded() || playerCharacter.GetPlayerState() == CharacterStates.jumping)
                return false;

            if (playerCharacter.isGrounded == true)
                return false;
        }

        return true;
    }


}
