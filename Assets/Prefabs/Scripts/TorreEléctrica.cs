using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreEléctrica : MonoBehaviour {
	public GameObject activador1;
	public GameObject activador2;
	public Camera camera;
	public GameObject[] electricidad;
	public GameObject[] particulasdaño;
	public AudioSource sonidoBoss;

	BossFinal boss;
	PlayerController player;
	// Use this for initialization
	void Start () {
	boss = FindObjectOfType<BossFinal> ();
	player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activador1.GetComponent<Palanca> ().activado && activador2.GetComponent<Palanca> ().activado) {
			foreach (GameObject rayo in electricidad) {
				rayo.SetActive (true);
			}
			player.transform.position = new Vector3 (boss.transform.position.x, boss.transform.position.y - 5, 1);
			camera.orthographicSize = 35;
			player.gameObject.SetActive (false);
			sonidoBoss.Play ();
			Invoke ("ActivamasTarde", 2.5f);
			InvokeRepeating ("Bajaintensidadboss", 6f, 0.1f);
		}
	}
	void ActivamasTarde()
	{
		for (int i = 0; i < particulasdaño.Length; i++)
			particulasdaño [i].gameObject.SetActive (true);
	}
	void Bajaintensidadboss()
	{
		Color col = boss.GetComponent<SpriteRenderer> ().color;
		boss.GetComponent<SpriteRenderer> ().color = new Color (col.r, col.g, col.b, col.a - Time.deltaTime/2);
		foreach (GameObject rayo in electricidad) {
			rayo.SetActive (false);
		}
	}
}
