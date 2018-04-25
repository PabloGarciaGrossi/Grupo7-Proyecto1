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
		if (activador.GetComponent<Palanca> ().palanca)
			activado = activador.GetComponent<Palanca> ().activado;
		else
			activado = activador.GetComponent<Boton> ().activado;
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
