using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour {
	public float dmg;
	public float maxVida;
	public float vidaRestante;
	Animator anim;
	Vector2 vel;
	float speed;
	float iniciox, inicioy;
	// Use this for initialization
	void Start () {
		if (gameObject.tag != "Oruga") {
			vel = GetComponent<Rigidbody2D> ().velocity;
			gameObject.transform.GetChild (3).gameObject.SetActive (false);
		}
		else
			speed = GetComponentInParent<Oruga> ().speed;
		anim = GetComponent<Animator> ();
		iniciox = transform.position.x;
		inicioy = transform.position.y;
		vidaRestante = maxVida;
	}
	public void Damage()
	{
		if (gameObject.tag != "Oruga")
		gameObject.transform.GetChild (3).gameObject.SetActive (true);
		vidaRestante -= dmg;
		if (vidaRestante <= 0) {
			if (gameObject.tag == "Rata")
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			else if (gameObject.tag == "Oruga") {
				gameObject.GetComponentInChildren<Oruga> ().speed = 0;
				anim.SetBool ("Muerte", true);
			}
			Invoke ("Destruir", 1f);
		}
		Invoke ("DesactivaParticulas", 1);
	}
	public void Reset(){
		gameObject.SetActive (true);
		if (gameObject.tag == "Rata")
			GetComponent<Rigidbody2D> ().velocity = vel;
		else if (gameObject.tag == "Oruga")
			gameObject.GetComponentInChildren<Oruga> ().speed = speed;
		vidaRestante = maxVida;
		gameObject.transform.position = new Vector2 (iniciox, inicioy);
		//gameObject.GetComponentInChildren<FieldOfViewEnemy> ().Detectado = false;
	}
	void Destruir (){
		gameObject.SetActive (false);
	}
	void DesactivaParticulas(){
		gameObject.transform.GetChild (3).gameObject.SetActive (false);
	}
}
