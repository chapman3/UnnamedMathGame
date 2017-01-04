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
	};
	public enum column {
		FirstColumn = 0,
		SecondColumn = 1,
		ThirdColumn = 2
	};

	private int[,] gameboardNums;
	private char[] operands;

	// Use this for initialization
	void Start () {
		RandomizeGameboard ();

		//These are just tests for now until we have a ui
		//We might also consider making an array of answers
		//Not sure yet but they work is the good news
		GenerateRowAnswer ((int) row.FirstRow);
		GenerateRowAnswer ((int) row.SecondRow);
		GenerateRowAnswer ((int) row.ThirdRow);
		GenerateColumnAnswer ((int) column.FirstColumn);
		GenerateColumnAnswer ((int) column.SecondColumn);
		GenerateColumnAnswer ((int) column.ThirdColumn);
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
				operands [i] = '*';
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
	/// <param name="RowIndex">The row to calculate</param> 
	public double GenerateRowAnswer(int RowIndex) {
		double answer;

		//Locate which operands to use based on the row
		int operandsStartingIndex = RowIndex * GAMEBOARD_WIDTH + RowIndex;

		//Generates the expression string for the row
		string expressionString = string.Format("{0}{1}{2}{3}{4}", 
			                    gameboardNums [RowIndex, 0],
			                    operands [operandsStartingIndex],
			                    gameboardNums [RowIndex, 1],
			                    operands [operandsStartingIndex + 1],
			                    gameboardNums [RowIndex, 2]);

		//Expression object for the string
		Expression expression = new Expression (expressionString);

		answer = System.Convert.ToDouble(expression.Evaluate ());

		return answer;
	}

	/// <summary>
	/// Generates the answer for a single column
	/// This does not work for if we change the column count
	/// </summary>
	/// <returns>The column answer.</returns>
	/// <param name="ColumnIndex">The column to calculate</param>
	public double GenerateColumnAnswer(int ColumnIndex) {
		double answer;

		//Locate which operands to use based on the column
		int operandsStartingIndex = ColumnIndex + 2; //todo: write this

		//Generates the expression string for the column
		string expressionString = string.Format ("{0}{1}{2}{3}{4}",
			                          gameboardNums [0, ColumnIndex],
			                          operands [operandsStartingIndex],
			                          gameboardNums [1, ColumnIndex],
			                          operands [operandsStartingIndex + GAMEBOARD_WIDTH],
			                          gameboardNums [2, ColumnIndex]	
		                          );

		Expression expression = new Expression (expressionString);

		answer = System.Convert.ToDouble (expression.Evaluate ());

		return answer;
	}
}
