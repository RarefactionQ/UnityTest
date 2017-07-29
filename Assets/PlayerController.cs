using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speedX;
	public float speedY;
	public Rigidbody rb;
	public bool jump;
	public bool grounded;

	// Update is called once per frame
	void Update () {
		
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speedX;
		if (Input.GetAxis ("Vertical") > 0) {
			jump = true;
			print ("jump");
		}
		transform.Translate (x, 0, 0);

		if (jump && grounded) {
			rb.AddForce (0, speedY, 0);
			jump = false;
			grounded = false;
		}

	}


	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.tag.Contains ("Ground"))
			print("OnCollisionStay");
			grounded = true;
	}
			
}
