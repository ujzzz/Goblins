using UnityEngine;
using System.Collections;

public class arrowHit : MonoBehaviour {

	Animator anim;
	EnemyResetAnims reset;

	// Use this for initialization
	void Start () {
		anim = transform.parent.GetComponent<Animator> ();
		reset = GetComponentInParent<EnemyResetAnims> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Arrow") {
			reset.ResetAnimation ();
			anim.SetBool ("isDead", true);
			GetComponentInParent<EnemyManager> ().alive = false;
			this.enabled = false;
		}
	}
}
