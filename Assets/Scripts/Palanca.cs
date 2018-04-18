using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {
	public bool activado = false;
	public bool palanca;
	PlayerController activador;
	void Start (){
		activador = GameObject.FindWithTag ("Player").GetComponent<PlayerController> ();
	}
	void Update (){
		if (palanca)
			palancafuncion ();
		else
			GetComponent<Boton> ().enabled = true;
		}
	void palancafuncion()
	{
		if (activador.Activador ()) {
			if (activado) {
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
				activado = false;
			} else {
				gameObject.transform.localScale = new Vector3 (-1, 1, 1);
				activado = true;
			}
	}
}
}
