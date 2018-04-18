using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeController : MonoBehaviour {
	public float sporeSpeedHigh;
	public float sporeSpeedLow;
	public float sporeAngle;
	public float rotacion;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (new Vector2 (Random.Range (-sporeAngle, sporeAngle), Random.Range (sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);
		rb.AddTorque (Random.Range (-rotacion, rotacion));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
