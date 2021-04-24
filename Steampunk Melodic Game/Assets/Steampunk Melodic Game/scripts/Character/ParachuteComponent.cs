using System.Collections;
using System.Collections.Generic;
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
        if (!CheckPreconditions())
            return;

        if (Input.GetMouseButton(1))
        {
            animatorPlayer.SetBool("parachute", true);
            rigidbodyCharacter.gravityScale = 1;
        }
        else
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
            if (playerCharacter.GetPlayerState() == CharacterStates.stunned)
                return false;

            if (playerCharacter.isGrounded == true)
                return false;
        }

        return true;
    }
}
