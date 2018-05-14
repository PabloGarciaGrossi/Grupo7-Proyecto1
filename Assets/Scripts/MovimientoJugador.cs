using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour {
	public float topspeed = 10f;
	public bool facingright = true;
	Animator anim;
	Rigidbody2D rb;
	RaycastHit2D activa;
	Transform tamaño;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		tamaño = gameObject.transform;
	}

	void fixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (move * topspeed, rb.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (move));
		if (move > 0 && !facingright)
			flip ();
		else if (move < 0 && facingright)
			flip ();
			
	}
	void flip(){
		facingright = !facingright;
		Vector3 thescale = transform.localScale;
		thescale.x *= -1;
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
	public bool Activador (){
		if (Input.GetKey (KeyCode.P)) {
			activa = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, 2f);
			if (activa.collider != null && activa.collider.tag == "Palanca") {
				return true;
			} else
				return false;
		} else
			return false;
	}
	void DibujaActivador()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*2f);
	}
}
