using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls buttons on win screen

public class WinScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //loads main menu when selected
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
