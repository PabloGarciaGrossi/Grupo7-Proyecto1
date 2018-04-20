using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb;
	RaycastHit2D activa;
	public float playerSpeed;
	public float playerJump;
	bool enTierra;
	public bool miraDerecha;
	public Transform posJugador, posSuelo;
    Animator playerAnim;
	Transform tamaño;
	// Use this for initialization
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		enTierra = true;
		miraDerecha = true;
		tamaño = gameObject.transform;
	}
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
		Girar (miraDerecha);
		DetectaSuelo ();
		float move = Input.GetAxis ("Horizontal");
		playerAnim.SetFloat ("Speed", Mathf.Abs (move));
		if (move > 0){
			miraDerecha = true;
            rb.velocity = new Vector2 (playerSpeed, rb.velocity.y);
        }
		else if (move < 0) {
			miraDerecha = false;
            rb.velocity = new Vector2 (-playerSpeed, rb.velocity.y);
        }
		else if (move == 0 && enTierra)
			playerAnim.SetBool ("idle", true);

    }
	void Update()
	{
		if (Input.GetButtonDown ("Jump") && enTierra) {
			enTierra = false;
			rb.AddForce (new Vector2 (0, playerJump), ForceMode2D.Impulse);
			playerAnim.SetBool ("jump", true);
			playerAnim.SetBool ("idle", false);
		} else {
			enTierra = true;
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
	/*public bool Activador (){
		if (Input.GetButtonDown ("Fire1")) {
			activa = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, 2f);
			if (activa.collider != null && activa.collider.tag == "Palanca") {
				return true;
			} else
				return false;
		} else
			return false;
	}*/
	/*public void Activador()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			activa = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, 2f);
			if (activa.collider != null && activa.collider.tag == "Palanca")
				activa.collider.GetComponent<Palanca> ().activado = true;
		}
	}
	*/
	void DibujaActivador()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*2f);
	}
}
