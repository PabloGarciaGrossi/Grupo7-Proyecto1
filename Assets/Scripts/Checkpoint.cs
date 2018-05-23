using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player"))
			//coloca al jugador en el currentckeckpoint, punto de control actual
			//NOTA: si el jugador retrocede a un punto de control anterior lo actualizará como el último
			GameManager.instance.currentcheckpoint = gameObject;
	}
}
