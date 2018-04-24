using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {
	public bool activado = false;
	public bool palanca;
	public bool enzona = false;
	/*void Update (){
		if (palanca) 
		{
			if (activado)
				gameObject.transform.localScale = new Vector3 (1, 1, 1);
			else
				gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		}
		else
			GetComponent<Boton> ().enabled = true;
		}*/
	/*void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if (palanca) 
			{
				if (Input.GetButtonDown ("Fire1") && !activado) 
				{
					gameObject.transform.localScale = new Vector3 (-1, 1, 1);
					activado = true;
				} 
				else if (Input.GetButtonDown ("Fire1") && activado) 
				{
					activado = false;
					gameObject.transform.localScale = new Vector3 (1, 1, 1);
				}
			}
			else
				GetComponent<Boton> ().enabled = true;
		}
	}*/
	void Update(){
		if (enzona) 
		{
			if (palanca) 
			{
				if (Input.GetButtonDown ("Fire1") && !activado) 
				{
					gameObject.transform.localScale = new Vector3 (-0.4f, 0.4f, 1);
					activado = true;
				} 
				else if (Input.GetButtonDown ("Fire1") && activado) 
				{
					activado = false;
					gameObject.transform.localScale = new Vector3 (0.4f, 0.4f, 1);
				}
			}
			else
				GetComponent<Boton> ().enabled = true;
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
