using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificaCamara : MonoBehaviour {
	public float maxtam;
	public float mintam;
	public Camera camera;
	// Use this for initialization
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			camera.orthographicSize = camera.orthographicSize + 1 * Time.deltaTime;
			if (camera.orthographicSize > maxtam)
				camera.orthographicSize = maxtam;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
				camera.orthographicSize = mintam;
	}
}
}

