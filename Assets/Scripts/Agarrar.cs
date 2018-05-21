
using UnityEngine;
using System.Collections;

public class Agarrar : MonoBehaviour {

	bool enzona = false;
	public Canvas engranaje;
	public PlayerController pl;
	public AudioSource pillaEngranaje;
	void Start(){
		pl = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.O) && enzona) {
			gameObject.SetActive (false);
			engranaje.enabled = true;
			pl.grabbed = true;
			pillaEngranaje.Play ();

		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			enzona = true;
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
			enzona = false;
	}
}