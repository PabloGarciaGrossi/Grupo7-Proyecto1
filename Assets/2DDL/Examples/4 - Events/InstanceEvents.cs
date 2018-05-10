namespace DynamicLight2D
{
	using UnityEngine;
	using System.Collections;
	
	public class InstanceEvents : MonoBehaviour {
		
		DynamicLight2D.DynamicLight light2d;
		float speed = .3f;
		
		
		
		
		IEnumerator Start () {
			// Find and set 2DLight Object //
			light2d = GameObject.Find("2DLight").GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight;
			
			// Add listeners
			
			light2d.OnEnterFieldOfView += onEnter;
			light2d.OnExitFieldOfView += onExit;
			
			
			yield return new WaitForEndOfFrame();
			
		}
		
		
		IEnumerator loop(){
			while(true){
				Vector3 pos = gameObject.transform.position;
				if(pos.y < -39){
					pos.y = 20;
					
				}else{
					pos.y -= speed;
				}
				
				
				
				yield return new WaitForEndOfFrame();
				gameObject.transform.position = pos;
			}
		}
		
		
		
		void onExit(GameObject g, DynamicLight2D.DynamicLight light){
			Debug.Log("OnExit");
			g.GetComponent<VidaEnemigo> ().enLuz = false;
		}
		
		void onEnter(GameObject g, DynamicLight2D.DynamicLight light){
			
			if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
				Debug.Log("OnEnter");
				g.GetComponent<VidaEnemigo> ().enLuz = true;
				}
			}
			
		}
		
	}


