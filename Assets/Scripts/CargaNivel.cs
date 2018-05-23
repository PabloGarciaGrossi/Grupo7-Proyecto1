using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaNivel : MonoBehaviour {
	public string nivel;
	// Use this for initialization
	LvlManager lvl;
	void Start(){
		lvl = FindObjectOfType<LvlManager> ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			lvl.CargaNivel (nivel);
	}
}
