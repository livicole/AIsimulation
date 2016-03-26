using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	public Transform mouse;
	public Transform cat;

	Vector3 mouseOriginPos;
	Vector3 catOriginPos;

	void Start(){
		mouseOriginPos = mouse.position;
		catOriginPos = cat.position;
	}
	
	public void RestartScene(){
			mouse.gameObject.SetActive (true);
			mouse.position = mouseOriginPos;
			cat.position = catOriginPos;
	}
}
