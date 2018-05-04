using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	bool isDead = false;
	Rigidbody2D rb;
	RaycastHit2D activa;
	public float playerSpeed;
	public float playerJump;
	public bool enTierra;
	public bool miraDerecha;
	public Transform posJugador, posSuelo;
    Animator playerAnim;
	Transform tamaño;
	MosquitoIA[] mosquito;
	IAenemigo[] rata;
	public Canvas pMuerte;
	float cont = 0,iniSpeed;
	// Use this for initialization
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		enTierra = true;
		miraDerecha = true;
		tamaño = gameObject.transform;
		mosquito = FindObjectsOfType<MosquitoIA> ();
		rata = FindObjectsOfType <IAenemigo> ();
		iniSpeed = playerSpeed;
	}
    void Start()
    {
		pMuerte.enabled = false;
		playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (!isDead) {
			Girar (miraDerecha);
			DetectaSuelo ();
			float move = Input.GetAxis ("Horizontal");
			if (move != 0) {
				cont += Time.deltaTime;
			} else
				cont = 0;

			if (cont > 1f) {
				playerSpeed = 1.5f * iniSpeed;
			} else if (cont > 0)
				playerSpeed = (1+cont) * iniSpeed;
			else
				playerSpeed = iniSpeed;
			playerAnim.SetFloat ("Speed", Mathf.Abs (move));
			if (move > 0) {
				miraDerecha = true;
				rb.velocity = new Vector2 (playerSpeed, rb.velocity.y);
			} else if (move < 0) {
				miraDerecha = false;
				rb.velocity = new Vector2 (-playerSpeed, rb.velocity.y);
			} else if (move == 0 && enTierra)
				playerAnim.SetBool ("idle", true);
		} else {
			pMuerte.enabled = true;
			if (Input.GetKey (KeyCode.R)) {
				isDead = false;
				GameManager.instance.RespawnPlayer ();
				pMuerte.enabled = false;
			}
		}
    }
	void Update()
	{
		if (Input.GetButtonDown ("Jump") && enTierra && !isDead) {
			rb.AddForce (new Vector2 (0, playerJump), ForceMode2D.Impulse);
			playerAnim.SetBool ("jump", true);
			playerAnim.SetBool ("idle", false);
		}
		if (!enTierra)
			playerAnim.SetBool ("jump", true);
		else
			playerAnim.SetBool ("jump", false);
			
	}
	void DetectaSuelo (){
		Debug.DrawLine (posJugador.position, posSuelo.position, Color.yellow);
		enTierra = Physics2D.Linecast(posJugador.position, posSuelo.position, 1 << LayerMask.NameToLayer("Plataformas"));
	}
	void Girar (bool miraDerecha){
		if (miraDerecha) {
			gameObject.transform.localScale = new Vector3 (0.6f, 0.6f, 1);
		} else {
			gameObject.transform.localScale = new Vector3 (-0.6f, 0.6f, 1);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
			gameObject.transform.localScale = tamaño.localScale;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform")
			transform.parent = null;
	}
	void DibujaActivador()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*2f);
	}
	public void PlayerDeath()
	{
		if (!isDead) {
			for (int i = 0; i < mosquito.Length; i++)
				mosquito [i].GetComponent<MosquitoIA> ().enabled = false;
			for (int i = 0; i < rata.Length; i++)
				rata [i].GetComponent<IAenemigo> ().enabled = false;
			GetComponent<Agarrar> ().grabbed = false;
			playerAnim.SetBool ("Muerte", true);
			rb.velocity = Vector2.zero;
			isDead = true;
		}
	}
}
