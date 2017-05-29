/*
 * http://www.sitepoint.com/saving-data-between-scenes-in-unity/
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour 
{
	public static GlobalControl Instance;

	//stats to be kept regardless of the scene
	public GlobalObject gameData;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
			gameData = new GlobalObject ();
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

}
