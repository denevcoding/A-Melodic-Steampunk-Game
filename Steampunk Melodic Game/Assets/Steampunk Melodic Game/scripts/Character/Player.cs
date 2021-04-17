using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D physics;

    [SerializeField]
    [Range(50, 350)]
    private float jumpForce;

    private void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody2D>();
    }//closes Awake method


    void Start()
    {
        TickClock.singleton.timerEvents += Jump;
    }//closes Start method

    void Jump()
    {
        Vector2 jump = new Vector2(0, jumpForce);
        physics.AddForce(jump);

    }//closes TestClock method

}//closes Player class
