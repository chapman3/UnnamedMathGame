using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class ButtonController : MonoBehaviour
{
    GameObject go;
    GameObject tempGo;
    public static string tempDiff;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToScene(string scene)
    {
        Scene thisScene = SceneManager.GetActiveScene();
        if (thisScene.name == "Difficulty")
        {
            if(scene != "Title")
            {
                tempDiff = scene;
                SceneManager.LoadScene("GameBoard");
                go = GameObject.Find("DifficultyObj");
                go.GetComponent<Text>().text = scene;
                Scene sendScene = SceneManager.GetSceneByName("GameBoard");
                SceneManager.MoveGameObjectToScene(go, sendScene);
                SceneManager.LoadScene("GameBoard");
            }
        }
        else
        {
            SceneManager.LoadScene(scene);
        } 
    }
}