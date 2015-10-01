using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {
	
	public Text countText2;
	public float speed2;
	public static Rigidbody rb2;
	public static int count2;
	public Text winText2;
	public float jump2;
	public Text return2;
	public float timeLeft2;
	public Text textTimeLeft2;
	private int time2;
	public Text collide2;
	public Text timeWarning2;

		
	
	
	void Start(){
		Time.timeScale = 1;
		rb2 = GetComponent<Rigidbody> ();
		count2 = 0;
		SetCountText ();
		winText2.text = "";

		collide2.text = "";
		timeWarning2.text = "";
		
	}
	void Update(){

		timeLeft2 -= Time.deltaTime;
		time2 = (int)timeLeft2;
		textTimeLeft2.text = "Time: " + time2.ToString ();

		if (timeLeft2 < 30) {
			timeWarning2.text = "TIME IS ALMOST UP!!!";
		}
		if (timeLeft2 < 0) {
			GameOver ();
		}
		
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			if((rb2.position.y)>=0.49&&(rb2.position.y)<=.5){
				rb2.AddForce (new Vector3 (0, jump2, 0));
			}
		}
		
	}
	void GameOver(){

		Time.timeScale = 0;
		return2.text = "Return To Menu";
		if (count2 > Player2.count2) {
			winText2.text = "Player 1 wins!!!!";
		} else if (count2 < Player2.count2) {

			winText2.text = "Player 2 wins!!!!";
		} else {

			winText2.text = "It is a tie!!!";
		}
	}

	void FixedUpdate(){
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb2.AddForce (new Vector3 (0, 0, 10));
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb2.AddForce (new Vector3 (0, 0, -10));
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb2.AddForce (new Vector3 (-10, 0, 0));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
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
			collide2.text = "Player 1 hit the wall";

		}
		
		if (other.gameObject.CompareTag ("2")) {
			if(rb2.position.y - Player2.rb2.position.y <=-.05){
	
				count2=count2-1;
				SetCountText ();

				collide2.text = "Player 2 won the collision!";
				//WaitForSeconds(1);

			}
			
		}
	}
	void SetCountText(){
		
		countText2.text = "Player 1 Score: " + count2.ToString ();


	}
}