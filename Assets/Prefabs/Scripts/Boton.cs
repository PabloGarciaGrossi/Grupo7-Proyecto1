using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {
	public bool activado;
	//public AudioSource botonAct;
	public Sprite spriteapagado;
	public Sprite spriteencendido;
	void Start(){
		GetComponent<SpriteRenderer> ().sprite = spriteapagado;
	}
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "pushable") {
			activado = true;
			GetComponent<SpriteRenderer> ().sprite = spriteencendido;
			//botonAct.Play ();
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "pushable") {
			activado = false;
			GetComponent<SpriteRenderer> ().sprite = spriteapagado;
		}
	}
}
