using UnityEngine;
using System.Collections;

public class boxpull : MonoBehaviour {

	public float defaultMass;
	public float imovableMass;
	public bool beingPushed;
	float xPos;
	Transform tamaño;

	public Vector3 lastPos;

	public int mode;
	public int colliding;
	public float iniciox, inicioy;
    private void Awake() {
        beingPushed = true;
    }
    void Start () {
        beingPushed = false;
		xPos = transform.position.x;
		iniciox = transform.position.x;
		inicioy = transform.position.y;
		lastPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (mode == 0) {
			if (beingPushed == false) {
				transform.position = new Vector3 (xPos, transform.position.y);
			} else
				xPos = transform.position.x;
		} else if (mode == 1) {

			if (beingPushed == false) {
				GetComponent<Rigidbody2D> ().mass=imovableMass;
			} else {
				GetComponent<Rigidbody2D> ().mass=defaultMass;
				}

		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
			gameObject.transform.localScale = tamaño.localScale;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform")
			transform.parent = null;
	}
	public void Reset(){
		gameObject.transform.position = new Vector2 (iniciox, inicioy);
	}
}