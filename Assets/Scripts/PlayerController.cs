using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text  countText;
	public Text  winText;

	private Rigidbody rigitbody;
	private int 	  count;

	void Start () {
		rigitbody = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHorisontal = Input.acceleration.x;
		float moveVertical   = Input.acceleration.y;

		Vector3 movement = new Vector3 (moveHorisontal, 0.0f, moveVertical);

		rigitbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag (@"Pick Up")) {
			other.gameObject.SetActive (false);
			count = count +1;
			SetCountText ();
		}
	}

	void SetCountText (){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}