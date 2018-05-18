using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reiniciaobjeto : MonoBehaviour {
	public GameObject activador;
	Vector3 posini;
	// Use this for initialization
	void Start () {
		posini = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (activador.GetComponent<Boton> ().activado)
			gameObject.transform.position = posini;
	}

}
