using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : MonoBehaviour {

	public delegate void MyEventAction();
	public event MyEventAction OnEvent;
    
    void OnGUI() {
        if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 200, 30), "Click For an Event")) {
            if(OnEvent != null) OnEvent();
        }
    }

    void OnMouseDown() {
		if(OnEvent != null)
			OnEvent();
	}
}
