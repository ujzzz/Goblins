using UnityEngine;
using System.Collections;

public class arrowHit : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = transform.parent.GetComponent<Animator> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Arrow") {
			anim.SetBool ("isHit", true);
		}
	}

	// Update is called once per frame
	void Update () {
		
	
	}
}
