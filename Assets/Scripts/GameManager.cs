using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestor del juego (singleton simplificado). Controlará el estado del juego
/// y tendrá métodos llamados desde los distintos objetos que lo hacen avanzar.
/// Debe haber una única instancia. 
/// </summary>
public class GameManager : MonoBehaviour {

	// Creamos una variable estática para almacenar la instancia única
	public static GameManager instance = null;
	public GameObject currentcheckpoint;
	PlayerController player;
	Animator playerAnim;
	VidaEnemigo [] enemigo;
	BossFinal boss;
	FocoLuz luz;
	Bateria[] pila;
	boxpull [] box;
	Generador[] engranajes;
	public int Maxvidas;
	public int curVidas;


	// En cuanto el objeto se active
	void Awake() {
		// Si no hay ningún objeto GameManager ya creado
		if (instance == null) {
			// Almacenamos la instancia actual
			instance = this;
			// Nos aseguramos de no destruir el objeto, es decir, 
			// de que persista, si cambiamos de escena
			DontDestroyOnLoad(this.gameObject);
		}
		else {
			// Si ya existe un objeto GameManager, no necesitamos uno nuevo
			Destroy(this.gameObject);
		}
		playerAnim = GameObject.FindWithTag ("Player").GetComponentInChildren<Animator> ();
		player = FindObjectOfType<PlayerController> ();
		luz = FindObjectOfType<FocoLuz> ();
		pila = FindObjectsOfType<Bateria> ();
		box = FindObjectsOfType<boxpull> ();
		engranajes = FindObjectsOfType<Generador> ();
		curVidas = Maxvidas;
		boss = FindObjectOfType<BossFinal> ();
	}
	void Update()
	{
		enemigo = FindObjectsOfType<VidaEnemigo> ();
		if (curVidas <= 0)
			player.PlayerDeath (); //Llama a PlayerDeath, crea el menú de reaparición
	}
	public void Damage()
	{
		//pierde una vida
		curVidas -= 1;
	}
	public void RespawnPlayer()
	{
			
			player.transform.position = currentcheckpoint.transform.position; //Coloca al Jugador donde se ha guardado 
		playerAnim.SetBool ("Muerte", false);                           	  //el último checkpoint en la clase Checkpoint
		for (int i = 0; i < enemigo.Length; i++) {//Véase especificaciones en el Checkpoint.cs 
				enemigo [i].Reset ();
			}
			for (int i = 0; i < pila.Length; i++) {
				pila [i].Reset ();
			}
		boss.GetComponent<BossFinal> ().enabled = true;
		luz.Reset ();
		curVidas = Maxvidas;
	}
}

