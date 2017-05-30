using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class ButtonController : MonoBehaviour
{
	public static string tempDiff;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

	void Awake(){
		DontDestroyOnLoad (this);
	}

    /// <summary>
    /// Switches the scene
    /// </summary>
    /// <param name="scene">The scene to be switched to or the difficulty to be passed to a GlobalObject</param> 
    /// 
    public void SwitchToScene(string scene)
    {
        Scene thisScene = SceneManager.GetActiveScene();
        if (thisScene.name == "Difficulty")
        {
            if(scene != "Title")
            {
				tempDiff = scene;
                SceneManager.LoadScene("NewGameBoard");
            }
        }
        else
        {
            SceneManager.LoadScene(scene);
        } 
    }

	public void handleNumBar(int number){
		GameObject current = EventSystem.current.currentSelectedGameObject;
		Sprite tempSprite;
		tempSprite = StateHandler.changeNumBarState (current);
		current.GetComponent<Image>().sprite = tempSprite;
		//Debug.Log (current.name);
	}

	public void handleInput(){
		GameObject current = EventSystem.current.currentSelectedGameObject;
		if (current.GetComponent<Image> ().sprite.name == "blank") {
			Sprite tempSprite;
			tempSprite = StateHandler.changeInputState (current);
			current.GetComponent<Image> ().sprite = tempSprite;
		}
		//Debug.Log (current.name);
	}
}