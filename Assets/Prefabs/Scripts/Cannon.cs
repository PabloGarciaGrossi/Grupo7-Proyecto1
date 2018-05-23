using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	public GameObject theprojectile;
	public float shoottime;
	public int chanceshoot;
	public Transform shootfrom;
	float nextshootTime;
	Animator cannonAnim;

	void Start () {
		cannonAnim = GetComponentInChildren<Animator> ();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextshootTime < Time.time) {
			nextshootTime = Time.time + shoottime;
			if (Random.Range (0, 10) >= chanceshoot) {
				Instantiate (theprojectile, shootfrom.position, Quaternion.identity);
				cannonAnim.SetTrigger ("CannonShoot");
			}
		}
	}
}
