using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{

    public float speed;
    public Vector3 initPosition = Vector3.zero;

    void Awake()
    {
        Debug.Log("entro el awake");
        transform.position = initPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("entro el start");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Vector3 position = this.transform.position;
        position.x += speed * Time.deltaTime;
        this.transform.position = position;
        Debug.Log("Update");
    }
}
