using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float force = 1;
    private Animator animatorPlayer;
    private float scaleX;
    public float gravity = 9.8f;
    public float jumpSpeed = 20;
    CharacterController controller;

    
    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
        animatorPlayer = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        //rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
        float XInput = Input.GetAxis("Horizontal");
        

        animatorPlayer.SetFloat("XVelocity", Mathf.Abs(XInput));
        //Debug.Log("movement" + YInput);
        transform.position += new Vector3(XInput, 0, 0) * Time.deltaTime * force;
        if (XInput < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);

        }
        else
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);

        }
    }
}
