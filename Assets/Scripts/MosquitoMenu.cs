using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMenu : MonoBehaviour {
	public GameObject [] mosquitos = new GameObject[6];
	int active = 0;
	public float vel;
	// Use this for initialization
	void Start () {
		for (int i = 1; i < 6; i++) {
			mosquitos [i].SetActive (false);
		}
		InvokeRepeating ("Cambia", vel, vel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Cambia(){
		mosquitos [active].SetActive(false);
		active = Random.Range (0, 6);
		mosquitos [active].SetActive (true);
	}

}
