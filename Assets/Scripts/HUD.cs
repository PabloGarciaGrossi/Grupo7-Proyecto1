using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Sprite[] imvidas;
	public Image vidasUI;
	// Use this for initialization
	void Start () {
		vidasUI = GetComponentInChildren<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		vidasUI.sprite = imvidas [GameManager.instance.curVidas];
	}
}
