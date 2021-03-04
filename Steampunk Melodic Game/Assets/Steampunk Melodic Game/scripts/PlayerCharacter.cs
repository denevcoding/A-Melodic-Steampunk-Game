using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float force = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        //rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * force;
    }
}
