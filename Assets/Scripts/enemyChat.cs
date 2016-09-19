using UnityEngine;
using System.Collections;

public class enemyChat : MonoBehaviour {

	private Animator anim;
	private int chat;
	public GameObject[] chatPartner;
	public GameObject player;
	private float rotSpeed = 2f;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
//		chatPartner = GameObject.FindGameObjectsWithTag ("Enemy");
//		int i = Random.Range (0, chatPartner.Length);
//		transform.rotation = Quaternion.LookRotation (chatPartner[i].transform.position - transform.position);
	}

	// Update is called once per frame
	void FixedUpdate () {
		chat = Random.Range (1, 6);
		//anim.SetInteger ("Chat", chat);
		yoYoYo ();
	}

	// enemies start rapping at you
	private void yoYoYo () {

		Vector3 direction = player.transform.position - transform.position;
		float angle = Vector3.Angle (direction, transform.forward);
		if (Vector3.Distance(player.transform.position, transform.position) < 10 && angle < 50) {
			anim.SetInteger ("Chat", 7);
		} 
		// makes them come to the player and start rapping
		if (Input.GetKey ("z")) {
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isIdle", false);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			transform.Translate (0, 0, rotSpeed * Time.deltaTime);
		}
		anim.SetBool ("isWalking", false);
		anim.SetBool ("isIdle", true);
	}
}
