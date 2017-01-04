using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;

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
	public enum row {
		FirstRow = 0,
		SecondRow = 1,
		ThirdRow = 2
	}

	private int[,] gameboardNums;
	private char[] operands;

	// Use this for initialization
	void Start () {
		RandomizeGameboard ();
		GenerateRowAnswer ((int) row.FirstRow);
		GenerateRowAnswer ((int) row.SecondRow);
		GenerateRowAnswer ((int) row.ThirdRow);
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
		}
	}

	/// <summary>
	/// Generates the answer for a single row
	/// This currently does not work if we change row count
	/// </summary>
	/// <returns>The row answer.</returns>
	public double GenerateRowAnswer(int RowIndex) {
		//Locate which operands to use based on the row
		int operandsStartingIndex = RowIndex * GAMEBOARD_WIDTH + RowIndex;

		Expression ex = new Expression ("2 * 3 + (5*2)");



		Debug.Log (ex.Evaluate ());

		return 0;
	}
}
