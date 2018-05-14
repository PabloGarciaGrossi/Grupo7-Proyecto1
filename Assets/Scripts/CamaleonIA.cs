using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaleonIA : MonoBehaviour {
	SpriteRenderer sr;
	FieldOfViewEnemy fove;
	float dis;
	public float minTras, maxTras;

	void Start () {
		sr = GetComponentInChildren<SpriteRenderer> ();
		fove = GetComponent<FieldOfViewEnemy> ();
	}

	void Update () {
		dis = getDistance ();
		Color col = sr.color;
		sr.color = new Color (col.r, col.g, col.b, transparencia (dis));
	}

	float getDistance(){
		float x = fove.dst;
		return x;
	}

	float transparencia(float x){
		float a;
		if (x > minTras)
			a = 0;
		else if (x < maxTras)
			a = 1;
		else
			a = 1 - ((x - maxTras) / (minTras - maxTras));

		return a;
	}
}
