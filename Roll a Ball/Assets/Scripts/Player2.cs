using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {
	
	public Text countText2;
	public float speed2;
	public static Rigidbody rb2;
	public static int count2;

	public float jump2;


	public Text collide2;
	
	
	
	
	void Start(){
		Time.timeScale = 1;
		rb2 = GetComponent<Rigidbody> ();
		count2 = 0;
		SetCountText ();


		collide2.text = "";
		
		
	}
	void Update(){
	
		if (Input.GetKeyDown (KeyCode.E)) {
			if((rb2.position.y)>=0.49&&(rb2.position.y)<=.5){
				rb2.AddForce (new Vector3 (0, jump2, 0));
			}
		}
		
	}

	
	void FixedUpdate(){
		
		if (Input.GetKey (KeyCode.W)) {
			rb2.AddForce (new Vector3 (0, 0, 10));
		}
		if (Input.GetKey (KeyCode.S)) {
			rb2.AddForce (new Vector3 (0, 0, -10));
		}
		if (Input.GetKey (KeyCode.A)) {
			rb2.AddForce (new Vector3 (-10, 0, 0));
		}
		if (Input.GetKey (KeyCode.D)) {
			rb2.AddForce (new Vector3 (10, 0, 0));
		}
	}
	
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count2 = count2 + 1;
			SetCountText ();
		}
	}
	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.CompareTag ("wall")) {
			
			count2=count2-1;
			SetCountText();
			collide2.text = "Player 2 hit the wall";
			
		}
		
		if (other.gameObject.CompareTag ("1")) {
			if(rb2.position.y - Player1.rb2.position.y <=-.05){
				
				count2=count2-1;
				SetCountText ();
				
				collide2.text = "Player 1 won the collision!";
				//WaitForSeconds(1);
				
			}
			
		}
	}
	void SetCountText(){
		
		countText2.text = "Player 2 Score: " + count2.ToString ();
		
		
	}
}