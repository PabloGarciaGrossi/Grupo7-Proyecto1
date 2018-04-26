using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoLuz : MonoBehaviour {
	public float disminucion;
	public FieldOfView fov;
	public Light luz;
	public DynamicLight2D.DynamicLight luz2;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating("DisminuyePotencia", 0.1f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DisminuyePotencia(){
		fov.viewRadius = gameObject.GetComponent<Light> ().range;
		luz.range -= disminucion;
		luz2.LightRadius = luz.range;
	}
	public void Reset(){
		if (fov.viewRadius < 3.5f) {
			fov.viewRadius = 3.5f;
			luz.range = 3.5f;
		} else {
			fov.viewRadius = 7;
			luz.range = 7;
		}
	}
}
