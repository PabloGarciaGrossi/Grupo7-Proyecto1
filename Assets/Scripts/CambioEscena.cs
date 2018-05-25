using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.curVidas = GameManager.instance.Maxvidas;
		GameManager.instance.boss = FindObjectOfType<BossFinal> ();
		GameManager.instance.playerAnim = GameObject.FindWithTag ("Player").GetComponentInChildren<Animator> ();
		GameManager.instance.player = FindObjectOfType<PlayerController> ();
		GameManager.instance.luz = FindObjectOfType<FocoLuz> ();
		GameManager.instance.pila = FindObjectsOfType<Bateria> ();
		GameManager.instance.enemigo = FindObjectsOfType<VidaEnemigo> ();
	}
}
