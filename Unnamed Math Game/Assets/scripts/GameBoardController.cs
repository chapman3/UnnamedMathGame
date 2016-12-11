using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty {
	easy = 1,
	medium = 2,
	hard = 3,
	hardest = 4
}

public class GameBoardController : MonoBehaviour {
	const int GAMEBOARD_HEIGHT = 3;
	const int GAMEBOARD_WIDTH = 3;

	public int maxValue;
	public int minValue;
	public Difficulty difficulty;

	private int[,] gameboardNums;
	private char[] operands;

	// Use this for initialization
	void Start () {
		RandomizeGameboard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void RandomizeGameboard() {
		RandomizeNumbers ();
		RandomizeOperands ();
	}

	/// <summary>
	/// Genereates the gameboardNums
	/// </summary>
	void RandomizeNumbers() {
		gameboardNums = new int[GAMEBOARD_HEIGHT, GAMEBOARD_WIDTH];
		for(int i = 0; i < GAMEBOARD_HEIGHT; i++) {
			for(int k = 0; k < GAMEBOARD_WIDTH; k++) {
				gameboardNums [i, k] = (int) Random.Range (minValue, maxValue + 1);
			}
		}
	}

	/// <summary>
	/// Randomizes the operands
	/// </summary>
	void RandomizeOperands() {
		int size = (GAMEBOARD_HEIGHT + GAMEBOARD_WIDTH - 2) * GAMEBOARD_WIDTH;
		operands = new char[size];

		for(int i = 0; i < size; i++) {
			int operatorValue = (int)Random.Range (1, (int)difficulty + 1);
			switch(operatorValue) {
			case 1:
				operands [i] = '+';
				break;
			case 2:
				operands [i] = '-';
				break;
			case 3:
				operands [i] = 'x';
				break;
			case 4:
				operands [i] = '/';
				break;
			}

			Debug.Log (operands [i]);
		}
	}
}
