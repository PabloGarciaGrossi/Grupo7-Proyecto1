﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoIA : MonoBehaviour {
	PlayerController player;
	public float speed;
	public float playerRange;
	public LayerMask playerlayer;
	bool playerInRange;
	float dirX,dirY;
	Rigidbody2D rb;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		InvokeRepeating ("cambiaDir", 0f, 0.2f);
		rb = GetComponent<Rigidbody2D> ();
	}
		
	void Update () {
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerlayer);
		if (playerInRange) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
			if (player.transform.position.x < transform.position.x)
				transform.localScale = new Vector3 (-2f, 2f, 1f);
			else
				transform.localScale = new Vector3 (2f, 2f, 1f);
		} else {
			rb.velocity = new Vector2 (dirX * 0.5f, dirY * 0.5f);
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere (transform.position, playerRange);
	}
	void cambiaDir(){
		dirX = Random.Range (-1f, 1.001f);
		dirY = Random.Range (-1f, 1.001f);
	}

}
