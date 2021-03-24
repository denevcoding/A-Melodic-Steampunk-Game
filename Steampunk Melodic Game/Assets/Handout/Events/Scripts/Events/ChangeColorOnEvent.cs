using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnEvent : MonoBehaviour {

	public EventDispatcher eventDispatcher;

	void OnEnable() {
		eventDispatcher.OnEvent += Blush;
    }

    void OnDisable() {
		eventDispatcher.OnEvent -= Blush;
    }
    
	void Blush() {
        Color col = new Color(0.9f, Random.value, Random.value);
		Renderer renderer = GetComponent<Renderer>();
        if(renderer) {
			renderer.material.color = col;
        }
    }
}
