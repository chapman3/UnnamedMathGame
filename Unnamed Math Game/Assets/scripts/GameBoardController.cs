using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour {
	const int GAMEBOARD_HEIGHT = 3;
	const int GAMEBOARD_WIDTH = 3;

	public int maxValue;
	public int minValue;

	private int[,] gameboardNums;
	private char[] operands;

	// Use this for initialization
	void Start () {
		gameboardNums = new int[GAMEBOARD_HEIGHT, GAMEBOARD_WIDTH];
		RandomizeGameboard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RandomizeGameboard() {
		//Generates the gameboardNums
		for(int i = 0; i < GAMEBOARD_HEIGHT; i++) {
			for(int k = 0; k < GAMEBOARD_WIDTH; k++) {
				gameboardNums [i, k] = (int) Random.Range (minValue, maxValue);
				Debug.Log (gameboardNums[i, k]);
			}
		}
	}
}
