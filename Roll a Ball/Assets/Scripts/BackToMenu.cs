using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour {

	public Button returnToMenu;


	// Use this for initialization
	void Start () {
		returnToMenu.enabled = true;
	}

	public void MainMenu(){
		
		Application.LoadLevel (0);
		
	}

}
