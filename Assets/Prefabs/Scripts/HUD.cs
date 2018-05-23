using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Sprite[] imvidas;
	public Image vidasUI;

	void Start () {
		//Muestra el HUD de las vidas
		vidasUI = GetComponentInChildren<Image> ();
	}

	void Update () {
		//Actualiza las vidas
		vidasUI.sprite = imvidas [GameManager.instance.curVidas];
	}
}
