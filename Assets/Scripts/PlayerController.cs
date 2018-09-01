using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public Text winText;
	public Text countText;
	public float speed;
	public float jump;
	public bool jumping;

	void Start(){
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		if (count < 4) {
			if (Input.GetKey ("space") && !jumping) {
				jump = 3;
				if (this.transform.position.y >= 1)
					jumping = true;
			} else {
				jump = 0;
				if (this.transform.position.y == 0.5) {
					jumping = false;
				}
			}
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, jump, moveVertical);
			rb.AddForce (movement * speed);
		}
	}

		void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PickUps")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 4)
			winText.text = "YOU'VE DONE IT!!!";
	}
}
