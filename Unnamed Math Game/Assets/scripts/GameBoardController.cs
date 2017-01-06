using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	public GameObject answersObj, operandsObj;

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
		setAnswers ();
		setOperands ();
	}

	void RandomizeGameboard() {
		RandomizeNumbers ();
		RandomizeOperands ();
	}

	/// <summary>
	/// Sets the answers in the UI
	/// </summary>
	void setAnswers() {
		//Set all the row answers
		answersObj.transform.GetChild (0).gameObject.GetComponent <Text>().text =
			GenerateRowAnswer ((int) row.FirstRow).ToString ();
		answersObj.transform.GetChild (1).gameObject.GetComponent<Text> ().text = 
			GenerateRowAnswer ((int)row.SecondRow).ToString ();
		answersObj.transform.GetChild (2).gameObject.GetComponent<Text> ().text = 
			GenerateRowAnswer ((int)row.ThirdRow).ToString ();

		//Set all the column answers
		answersObj.transform.GetChild (3).gameObject.GetComponent<Text> ().text = 
			GenerateColumnAnswer ((int)column.FirstColumn).ToString ();
		answersObj.transform.GetChild (4).gameObject.GetComponent<Text> ().text = 
			GenerateColumnAnswer ((int)column.SecondColumn).ToString ();
		answersObj.transform.GetChild (5).gameObject.GetComponent<Text> ().text = 
			GenerateColumnAnswer ((int)column.ThirdColumn).ToString ();
	}

	/// <summary>
	/// Sets the operands in the UI
	/// </summary>
	void setOperands() {
		int operandsLength = operandsObj.transform.childCount;

		for(int i = 0; i < operandsLength; i++) {
			Text operandText = operandsObj.transform.GetChild (i).GetComponent<Text>();
			operandText.text = operands [i].ToString ();
		}
	}

	/// <summary>
	/// Genereates the gameboardNums
	/// </summary>
	void RandomizeNumbers() {
		gameboardNums = new int[GAMEBOARD_HEIGHT, GAMEBOARD_WIDTH];
		List<int> possibleNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		for(int i = 0; i < GAMEBOARD_HEIGHT; i++) {
			for(int k = 0; k < GAMEBOARD_WIDTH; k++) {
				int position = Random.Range (0, possibleNumbers.Count);
				int randomNum = possibleNumbers [position];
				possibleNumbers.RemoveAt (position);
				gameboardNums[i, k] = randomNum;
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

		//final answer
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
		int operandsStartingIndex = ColumnIndex + (GAMEBOARD_WIDTH - 1);

		//Generates the expression string for the column
		string expressionString = string.Format ("{0}{1}{2}{3}{4}",
			                          gameboardNums [0, ColumnIndex],
			                          operands [operandsStartingIndex],
			                          gameboardNums [1, ColumnIndex],
			                          operands [operandsStartingIndex + GAMEBOARD_WIDTH],
			                          gameboardNums [2, ColumnIndex]	
		                          );

		//Expression object for the string
		Expression expression = new Expression (expressionString);

		//final answer
		answer = System.Convert.ToDouble (expression.Evaluate ());

		return answer;
	}
}
