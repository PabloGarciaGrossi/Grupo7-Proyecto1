using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour {
	public Light luz;
	public FieldOfView fov;
	public AudioSource sonidoBat;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			luz.range = 7;
			fov.viewRadius = 7;
			gameObject.SetActive (false);
			sonidoBat.Play ();
		}
	}
	public void Reset(){
		gameObject.SetActive (true);
	}
}
