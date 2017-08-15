using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //load the scene with the main gameplay
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    //quit the game
    public void QuitButton()
    {
        Application.Quit();
    }
}
