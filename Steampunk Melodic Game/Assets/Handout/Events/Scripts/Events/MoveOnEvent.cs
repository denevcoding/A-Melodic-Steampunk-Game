using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEvent : MonoBehaviour {
    public EventDispatcher eventDispatcher;
    void OnEnable() {
		eventDispatcher.OnEvent += Boing;
    }
    void OnDisable() {
		eventDispatcher.OnEvent -= Boing;
    }
	void Boing() {

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (rigidBody) {
            rigidBody.AddForce(Vector3.up* Random.Range(200.0f, 300.0f));
            rigidBody.AddTorque(Vector3.forward * Random.Range(-10.0f, 10.0f));
        }
        //Vector3 pos = transform.position;
        //pos.y = Random.Range(1.0f, 3.0f);
        //transform.position = pos;
    }
}

