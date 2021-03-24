using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExperiment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        int holi = 0;
        Debug.Log("object triggered this");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //int holi = 0;
        //Debug.Log("object triggered this");
    }
}
