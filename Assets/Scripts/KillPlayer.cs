using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	// Use this for initialization
	PlayerController player;
	void Start () {
		player = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("Player"))
			player.PlayerDeath ();	
	}
}
