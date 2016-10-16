using UnityEngine;
using System.Collections;

public class EnemyFindLeader : MonoBehaviour {
	bool ready = false;
	float moveSpeed;
	GameObject leader;
	Animator anim;
	public Vector3 randomDir;
	EnemyResetAnims reset;

	// Use this for initialization
	void Start () {
		Invoke("GetStats",0.11f); // wait 0.11 second until all scripts are loaded
		anim = GetComponent<Animator>();
		randomDir = new Vector3 (Random.Range (-50, 50), 0f,Random.Range(-50,50)); // create a random direction
		reset = GetComponent<EnemyResetAnims> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ready) { //if all loaded
			if (!GetComponent<EnemyManager> ().amLeader) { //do this if you're not the leader
				SearchLeader ();
			}
		}
		if (Random.Range(0, 1000) < 1) {//updates random direction every few seconds as enemy is frantically running and looking for the leader
			randomDir = new Vector3 (Random.Range (-50, 50), 0f,Random.Range(-50,50)); // create a random direction
		}

		if (Vector3.Distance (transform.position, randomDir) < 5f) { //if you run to the place and leader is not around
			randomDir = new Vector3 (Random.Range (-50, 50), 0f,Random.Range(-50,50)); // create a new random direction
		}
	}

	void SearchLeader () {
		Vector3 dir = randomDir - transform.position; //set direction toward random direction
		//Debug.DrawRay(transform.position,dir);
		reset.ResetAnimation();
		anim.SetBool ("isRun", true);
		anim.speed = 1f + (moveSpeed / 10); //adjusts animation speed to this player's unique moveSpeed
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),moveSpeed * Time.deltaTime); //rotates toward the new random direction
		transform.Translate (0, 0, moveSpeed * 2 * Time.deltaTime); // move toward the random direction
	}
	
	void GetStats () {
		moveSpeed = transform.GetComponent<EnemyStats> ().moveSpeed; //pulls from the randomly generated stat for this enemy
		leader = GetComponent<EnemyManager> ().leader; //i lumped this in here because it kind of fits
		ready = true;
	}
}
