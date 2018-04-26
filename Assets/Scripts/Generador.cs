using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {
	public bool detectado;
	Agarrar agarre;
	float iniciox,inicioy;
	void Start(){
		detectado = false;
		agarre = GameObject.FindWithTag ("Player").GetComponent<Agarrar> ();
		iniciox = transform.position.x;
		inicioy = transform.position.y;
	}
	void OnTriggerEnter2D(Collider2D other){
		GameObject generador = other.gameObject;
		if (generador.CompareTag ("Generador") && !agarre.grabbed) {
			detectado = true;
			gameObject.tag = "Enganchado";
			GetComponent<Rigidbody2D> ().mass = 1000;
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
			transform.parent = other.transform;
			gameObject.transform.position = other.GetComponentInChildren<Transform> ().position;
		}
	}
	public void Reset(){
		gameObject.tag = "Agarrable";
		GetComponent<Rigidbody2D> ().mass = 100;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		transform.parent = null;
		gameObject.transform.position = new Vector2 (iniciox, inicioy);
	}

}
