using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruccion : MonoBehaviour {
	public float tiempovivo;
	// Use this for initialization
	void Start () {
		Invoke ("Destruir", tiempovivo);
	}
	void Destruir()
	{
		Destroy (gameObject);
	}
}
