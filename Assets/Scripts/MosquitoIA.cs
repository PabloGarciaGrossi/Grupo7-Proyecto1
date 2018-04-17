using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoIA : MonoBehaviour {
	PlayerController player;
	public float speed;
	public float playerRange;
	public LayerMask playerlayer;
	bool playerInRange;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerInRange = Physics2D.OverlapCircle (transform.position, playerRange, playerlayer);
		if (playerInRange) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
			if (player.transform.position.x < transform.position.x)
				transform.localScale = new Vector3 (-2f, 2f, 1f);
			else
				transform.localScale = new Vector3 (2f, 2f, 1f);
		}
	}
	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere (transform.position, playerRange);
	}
}
