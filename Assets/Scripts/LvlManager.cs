using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour {
	
	public void CargaNivel (string nombre){
		SceneManager.LoadScene ("Nivel2");
	}

	public void Salir(){
		Application.Quit ();
	}
}
