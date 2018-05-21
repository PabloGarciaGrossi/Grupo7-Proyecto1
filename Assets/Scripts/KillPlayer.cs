using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	PlayerController pl;
	void Start(){
		pl = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			GameManager.instance.Damage ();
			GameManager.instance.ControladorVida ();
			StartCoroutine(pl.Knockback(0.02f, 400f, pl.transform.position));
		}
	}
}
