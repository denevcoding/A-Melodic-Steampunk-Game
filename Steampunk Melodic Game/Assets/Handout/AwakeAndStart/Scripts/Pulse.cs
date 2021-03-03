using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {

	float time = 0;
	Material pulsingMaterial;
	GameObject pulsingObject;
	public string nameOfPulsingObject;

	void Awake()
	{
		pulsingObject = GameObject.Find(nameOfPulsingObject);
	}

	void Start () {
		pulsingMaterial = pulsingObject.GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 1) {
			time = 0;
		}
		Color color = Color.Lerp(Color.blue,Color.red, time);
		pulsingMaterial.color = color;
	}
}
