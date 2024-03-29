﻿using System.Collections;
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

	public Difficulty difficulty;
	public GameObject answersObj, operandsObj, inputFieldsObj;
	[Range(0,2)]
	public int freeAnswers;

    GlobalObject globalObject;

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

	// Use this for initialization
	void Start () {
        GameObject.Find("DifficultyObj").GetComponent<Text>().text = ButtonController.tempDiff;
        globalObject = new GlobalObject();
		setAnswers (globalObject.answers);
		setOperands (globalObject.operands);
		GenerateHints (globalObject.gameboardNums);
		DumpAnswers (globalObject.gameboardNums);
		DumpOperands (globalObject.operands);
	}

	/// <summary>
	/// Sets the answers in the UI
	/// </summary>
	void setAnswers(int[] answers) {
		//Set all the row answers
		answersObj.transform.GetChild (0).gameObject.GetComponent <Text>().text =
			answers[0].ToString ();
		answersObj.transform.GetChild (1).gameObject.GetComponent<Text> ().text =
            answers[1].ToString ();
		answersObj.transform.GetChild (2).gameObject.GetComponent<Text> ().text =
            answers[2].ToString ();

		//Set all the column answers
		answersObj.transform.GetChild (3).gameObject.GetComponent<Text> ().text =
            answers[3].ToString ();
		answersObj.transform.GetChild (4).gameObject.GetComponent<Text> ().text =
            answers[4].ToString ();
		answersObj.transform.GetChild (5).gameObject.GetComponent<Text> ().text =
            answers[5].ToString ();
	}

	/// <summary>
	/// Sets the operands in the UI
	/// </summary>
	void setOperands(char[] operands) {
		int operandsLength = operandsObj.transform.childCount;

		for(int i = 0; i < operandsLength; i++) {
			Text operandText = operandsObj.transform.GetChild (i).GetComponent<Text>();
			operandText.text = operands [i].ToString ();
		}
	}


	/// <summary>
	/// Gives the user free answers based on the setting
	/// </summary>
	void GenerateHints(int[,] gameboardNums) {
		for (int i = 0; i < freeAnswers; i++) {
			bool blankTile = true;

			while (blankTile) {
				int row = Random.Range (0, 3);
				int column = Random.Range (0, 3);
				int answerObjPosition = row * 3 + column;

				InputField answerTile = inputFieldsObj.transform.GetChild (answerObjPosition).GetComponent<InputField> ();

				if (answerTile.text == string.Empty) {
					answerTile.text = gameboardNums [row, column].ToString ();
					answerTile.enabled = false;
					blankTile = false;
				}
			}
		}
	}

	/// <summary>
	/// Dumps the answers into the console for debugging
	/// </summary>
	void DumpAnswers(int[,] gameboardNums) {
		for(int i = 0; i < 3; i++) {
			for(int k = 0; k < 3; k++) {
				Debug.Log (string.Format ("Row {0} Column {1} Value {2}", i, k, gameboardNums [i, k]));
			}
		}
	}

	/// <summary>
	/// Dumps the operands into the console for debugging
	/// </summary>
	void DumpOperands(char[] operands) {
		for(int i = 0; i < operands.Length; i++) {
			Debug.Log (operands [i]);
		}
	}
}
