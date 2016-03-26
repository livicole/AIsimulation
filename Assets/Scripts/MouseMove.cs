using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

	public Transform cat;
	public AudioSource soundManager;
	public AudioClip losScream;

	float timeSeen;

	void FixedUpdate(){
		Vector3 directionToCat = (cat.position - transform.position);
		Vector3 forward = transform.forward;
		float angle = Vector3.Angle (directionToCat, forward);

		if (angle < 180f) {
			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseRayHitInfo = new RaycastHit ();

			if(Physics.Raycast(mouseRay, out mouseRayHitInfo, 8f)){
				if(mouseRayHitInfo.collider.tag == "Cat"){
					GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 900f);
					if (Time.time > timeSeen + .8f) {
						soundManager.PlayOneShot (losScream, 1f);
						timeSeen = Time.time;
					}
				}
			}
		}
	}
}
