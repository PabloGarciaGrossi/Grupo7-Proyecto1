using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour {
	public GameObject enemigo;
	public Transform spawner1;
	public Transform spawner2;
	public GameObject palanca1;
	public GameObject palanca2;
	public bool detectado= false;

	void Start(){
		InvokeRepeating ("PruebaSpawner", 3f, 7f);
	}
	void Update () {
		if (palanca1.GetComponent<Palanca> ().activado && palanca2.GetComponent<Palanca> ().activado)
			gameObject.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			detectado = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			detectado = false;
		}
	}
	void PruebaSpawner(){
		if (detectado)
			Invoke ("Spawner", 1f);
	}
	void Spawner(){
		Instantiate (enemigo, spawner1.position, Quaternion.identity);
		Instantiate (enemigo, spawner2.position, Quaternion.identity);
	}
}
