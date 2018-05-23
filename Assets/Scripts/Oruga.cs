using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oruga : MonoBehaviour {
	public Transform[] limites;
	public int pointselection;
	public float speed;
	Transform limiteactual;

	void Start () {
		limiteactual = limites [pointselection];
	}

	void Update () {	
		//Movimiento de la Oruga respecto a las paredes
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, limiteactual.position, Time.deltaTime * speed);
		if (gameObject.transform.position == limiteactual.position) {
			pointselection++;
			if (pointselection == limites.Length)
				pointselection = 0;
			limiteactual = limites [pointselection];
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x, gameObject.transform.localScale.y, 1);
		}
	}
}
