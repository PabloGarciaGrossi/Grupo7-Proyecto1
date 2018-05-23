using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour {
	public float VelGiro;
	public GameObject activador;

	void Update () {
		if (activador.GetComponent<Generador>().detectado)
		transform.Rotate (0f, 0f, VelGiro);
	}
}
