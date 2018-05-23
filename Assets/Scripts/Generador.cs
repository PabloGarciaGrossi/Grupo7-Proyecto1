using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {
	public bool detectado;
	public Canvas Engranaje;
	public Sprite SprActivado;
	bool enzona = false;
	public AudioSource colocaEngranaje;
	PlayerController pl;
	void Start(){
		pl = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	void Update(){
		//Para coger el engranaje
		if (Input.GetKeyDown (KeyCode.O) && pl.grabbed && enzona) {
			detectado = true;
			Engranaje.enabled = false;
			colocaEngranaje.Play ();
			gameObject.GetComponent<SpriteRenderer> ().sprite = SprActivado;

		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			enzona = true;
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player")
			enzona = false;
	}

}
