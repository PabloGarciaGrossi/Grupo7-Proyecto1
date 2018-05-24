using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {
	public bool activado;
	public Sprite spriteapagado;
	public Sprite spriteencendido;
	void Start(){
		GetComponent<SpriteRenderer> ().sprite = spriteapagado;
	}
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "pushable") {
			activado = true;
			GetComponent<SpriteRenderer> ().sprite = spriteencendido;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "pushable") {
			activado = false;
			GetComponent<SpriteRenderer> ().sprite = spriteapagado;
		}
	}
}
