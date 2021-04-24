using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteComponent : MonoBehaviour
{
    Animator animatorPlayer;
    PlayerCharacter playerCharacter;
    Rigidbody2D rigidbodyCharacter;
    // Start is called before the first frame update
    private void Awake()
    {
        animatorPlayer = GetComponent<Animator>();
        playerCharacter = GetComponent<PlayerCharacter>();
        rigidbodyCharacter = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1) && playerCharacter.isGrounded==false)
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
}
