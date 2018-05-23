using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectaEnemy : MonoBehaviour {
	public float dmg;

	void OnTriggerStay2D (Collider2D col){
		GameObject enemigo = col.gameObject;
		if (enemigo.CompareTag ("Enemy")) {
			VidaEnemigo v = enemigo.GetComponent <VidaEnemigo>();
			v.Damage (); //Aplica daño llamando al método Damage tras haber 
						 //detectado al enemigo mediante el CompareTag
		}
	}
}
