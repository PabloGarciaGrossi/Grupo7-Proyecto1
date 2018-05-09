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
		enemigo = FindObjectsOfType<VidaEnemigo> ();
		luz = FindObjectOfType<FocoLuz> ();
		pila = FindObjectsOfType<Bateria> ();
		box = FindObjectsOfType<boxpull> ();
		engranajes = FindObjectsOfType<Generador> ();
		curVidas = Maxvidas;
	}
	void Update()
	{
		if (curVidas <= 0)
			RespawnPlayer();
	}
	public void Damage()
	{
		curVidas -= 1;
	}
	public void RespawnPlayer()
	{
			player.transform.position = currentcheckpoint.transform.position;
			playerAnim.SetBool ("Muerte", false);
			for (int i = 0; i < enemigo.Length; i++) {
				enemigo [i].Reset ();
			}
			for (int i = 0; i < pila.Length; i++) {
				pila [i].Reset ();
			}
			/*for (int i = 0; i < box.Length; i++) {
				box [i].Reset ();
			}*/
			luz.Reset ();
		curVidas = Maxvidas;
	}

	// A partir de aquí añadiríamos los métodos que necesitemos implementar
	// para conseguir las funcionalidades que pretendamos incluir. 
}

