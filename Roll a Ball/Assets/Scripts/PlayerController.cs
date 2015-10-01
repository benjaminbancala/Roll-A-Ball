using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text winText;
	public float jump;
	public Text returnToMenu;
	public Text collision;




	void Start(){
		Time.timeScale = 1;
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";


	}
	void Update(){

		if (Input.GetKeyDown (KeyCode.E)) {
			if((rb.position.y)==0.5){
				rb.AddForce (new Vector3 (0, jump, 0));
			}		
		}

		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if((rb.position.y)==0.5){
				rb.AddForce (new Vector3 (0, jump, 0));
			}		
		}

	}

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.CompareTag ("wall")) {
			count = count - 1;
			SetCountText ();
			collision.text="The Player collided with the wall!";
//			WaitForSeconds(1);

		}

	}
	void SetCountText(){

		countText.text = "Player 1 Score: " + count.ToString ();
		if (count >= 12) {
			Time.timeScale=0;
			winText.text = "You Win!";
			returnToMenu.text = "Return To Menu";

		}
	}
}