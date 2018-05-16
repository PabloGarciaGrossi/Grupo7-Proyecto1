using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour {
	public float dmg;
	public float maxVida;
	public float vidaRestante;
	public bool enLuz = false;
	//public AudioSource hurtMonster;
	Animator anim;
	Vector2 vel;
	float speed;
	float iniciox, inicioy;
	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Rata") {
			vel = GetComponent<Rigidbody2D> ().velocity;
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
		} else if (gameObject.tag == "Oruga") {
			speed = GetComponentInChildren<Oruga> ().speed;
			anim = GetComponent<Animator> ();
		} else if (gameObject.tag == "Mosquito") {
			gameObject.transform.GetChild (0).gameObject.SetActive (false);
			speed = GetComponent<MosquitoIA> ().speed;
		}
		iniciox = transform.position.x;
		inicioy = transform.position.y;
		vidaRestante = maxVida;
	}
	void Update()
	{
		if (enLuz)
			Damage ();
	}
	public void Damage()
	{
		if (gameObject.tag != "Oruga")
		gameObject.transform.GetChild (0).gameObject.SetActive (true);
		vidaRestante -= dmg;
		if (vidaRestante <= 0) {
			if (gameObject.tag == "Rata") {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}else if (gameObject.tag == "Oruga") {
				gameObject.GetComponentInChildren<Oruga> ().speed = 0;
				anim.SetBool ("Muerte", true);
			} else if (gameObject.tag == "Mosquito") {
				gameObject.GetComponent<MosquitoIA> ().speed = 0;
				//hurtMonster.Play();
			}
			Invoke ("Destruir", 1f);
		}
		if (gameObject.tag != "Oruga")
		Invoke ("DesactivaParticulas", 1);
	}
	public void Reset(){
		gameObject.SetActive (true);
		if (gameObject.tag == "Rata") {
			GetComponent<IAenemigo> ().enabled = true;
			GetComponent<Rigidbody2D> ().velocity = vel;
		} else if (gameObject.tag == "Oruga")
			gameObject.GetComponentInChildren<Oruga> ().speed = speed;
		else if (gameObject.tag == "Mosquito") {
			GetComponent<MosquitoIA> ().enabled = true;
			gameObject.GetComponent<MosquitoIA> ().speed = speed;
		}
		vidaRestante = maxVida;
		gameObject.transform.position = new Vector2 (iniciox, inicioy);
		//gameObject.GetComponentInChildren<FieldOfViewEnemy> ().Detectado = false;
	}
	void Destruir (){
		gameObject.SetActive (false);
	}
	void DesactivaParticulas(){
		gameObject.transform.GetChild (0).gameObject.SetActive (false);
	}
}
