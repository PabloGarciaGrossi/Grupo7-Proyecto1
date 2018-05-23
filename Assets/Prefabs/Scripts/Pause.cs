using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	bool active = false;
	Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")){
			active = !active;
			canvas.enabled = active;
			Time.timeScale = (active) ? 0 : 1f;
		}
	}
}
