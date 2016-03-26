using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour
{

	public Transform mouse;
	public AudioSource soundManager;
	public AudioClip dinoLOS;
	public AudioClip dinoEat;
	public AudioClip manScream;

	//public static bool soundPlayed;
	float timeSeen;

	void FixedUpdate ()
	{
		if (mouse == null) {
			return;
		}

		Vector3 directionToMouse = (mouse.position - transform.position);
		Vector3 forward = transform.forward;
		float angle = Vector3.Angle (directionToMouse, forward);

		if (angle < 90f) {
			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();

			if (Physics.Raycast (catRay, out catRayHitInfo, 25f) && catRayHitInfo.collider.tag == "Mouse") {
				if (catRayHitInfo.distance <= 1.5f) {
					mouse.gameObject.SetActive (false);
					soundManager.PlayOneShot (dinoEat, 1f);
					soundManager.PlayOneShot (manScream, 1f);
				} else if (catRayHitInfo.distance <= 7f) {
					GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 900f);
					if (Time.time > timeSeen + .2f) {
						soundManager.PlayOneShot (dinoLOS, 1f);
						timeSeen = Time.time;
					}
				}
			}
		}
	}
}
