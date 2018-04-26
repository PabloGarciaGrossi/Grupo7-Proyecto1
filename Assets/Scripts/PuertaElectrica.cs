using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaElectrica : MonoBehaviour {
	public GameObject activador;
	bool activado = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activador.tag == "Palanca")
			activado = activador.GetComponent<Palanca> ().activado;
		else if (activador.tag == "Boton")
			activado = activador.GetComponent<Boton> ().activado;
		else
			activado = activador.GetComponent<Generador> ().detectado;
		if (activado) {
			gameObject.GetComponent<KillPlayer> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		} else {
			gameObject.GetComponent<KillPlayer> ().enabled = true;
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
