
using UnityEngine;
using System.Collections;

public class Agarrar : MonoBehaviour {

	bool enzona = false;
	public Canvas engranaje;
	public PlayerController pl;
	/*RaycastHit2D hit;
	public float distance=2f;
	public Transform holdpoint;
	public float throwforce;
	public LayerMask notgrabbed;
	bool enzona = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{

			if(enzona)
			{
				engranaje.enabled = false;
				Physics2D.queriesStartInColliders=false;

				hit =	Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);

				if(hit.collider!=null && hit.collider.tag=="Agarrable")
				{
					Destroy (hit.collider);
					grabbed=true;
				}


				//grab
			}else if(!Physics2D.OverlapPoint(holdpoint.position,notgrabbed))
			{
				grabbed=false;

				if(hit.collider.gameObject.GetComponent<Rigidbody2D>()!=null)
				{

					hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity= new Vector2(transform.localScale.x,1)*throwforce;
				}


				//throw
			}


		}

		if (grabbed)
			engranaje.enabled = true;


	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*distance);
	}*/
	void Start(){
		pl = FindObjectOfType<PlayerController> ().GetComponent<PlayerController> ();
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.R) && enzona) {
			gameObject.SetActive (false);
			engranaje.enabled = true;
			pl.grabbed = true;
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