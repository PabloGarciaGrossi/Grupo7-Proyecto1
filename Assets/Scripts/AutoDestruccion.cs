using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruccion : MonoBehaviour {
	public float tiempovivo;

	void Start () {
		Invoke ("Destruir", tiempovivo);
	}
	void Destruir(){
		Destroy (gameObject);
	}
}
