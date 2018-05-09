using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {
	public bool detectado;
	public Canvas Engranaje;
	bool enzona = false;
	PlayerController pl;
	/*void Start(){
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
	}*/
	void Start()
	{
		pl = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.R) && pl.grabbed && enzona) {
			detectado = true;
			Engranaje.enabled = false;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			enzona = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
			enzona = false;
	}

}
