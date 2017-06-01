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

	public Difficulty difficulty;
	public GameObject answersObj, operandsObj;
	[Range(0,2)]
	public int freeAnswers;

    public GlobalObject gameData;

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
        gameData = GlobalControl.Instance.gameData;
		setAnswers (gameData.answers);
		setOperands (gameData.operands);
		//GenerateHints (gameData.gameboardNums);
		DumpAnswers (gameData.gameboardNums);
		DumpOperands (gameData.operands);
		GlobalControl.Instance.gameData = gameData;
	}

	/// <summary>
	/// Sets the answers in the UI
	/// </summary>
	void setAnswers(int[] answers) {
		//Set all the row answers
		answersObj.transform.GetChild (0).gameObject.GetComponent<Text> ().text =
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
			GameObject operand = operandsObj.transform.GetChild (i).gameObject;
			Sprite temp = null;
			switch (operands [i].ToString ()) {
			case "+":
				temp = Resources.Load<Sprite> ("sprites/Operand Tiles/plus");
				break;
			case "-":
				temp = Resources.Load<Sprite> ("sprites/Operand Tiles/minus");
				break;
			case "*":
				temp = Resources.Load<Sprite> ("sprites/Operand Tiles/mult");
				break;
			case "/":
				temp = Resources.Load<Sprite> ("sprites/Operand Tiles/div");
				break;
			}
			operand.GetComponent<Image> ().sprite = temp;
		}
	}


	/// <summary>
	/// Gives the user free answers based on the setting
	/// </summary>
	/*void GenerateHints(int[,] gameboardNums) {
		for (int i = 0; i < freeAnswers; i++) {
			bool blankTile = true;

			while (blankTile) {
				int row = Random.Range (0, 3);
				int column = Random.Range (0, 3);
				//int answerObjPosition = row * 3 + column;

				InputField answerTile = inputFieldsObj.transform.GetChild (answerObjPosition).GetComponent<InputField> ();

				if (answerTile.text == string.Empty) {
					answerTile.text = gameboardNums [row, column].ToString ();
					answerTile.enabled = false;
					blankTile = false;
				}

			}
		}
	}*/

	public static void checkSolution(){
		GlobalObject gameData = GlobalControl.Instance.gameData;
		int[] answers = gameData.GenerateAnswers (gameData.solution);
		Debug.Log (answers[0] + " " + answers[1] + " " + answers[2] + " " + answers[3] + " " + answers[4] + " " + answers[5]);
		Debug.Log (gameData.answers[0] + " " + gameData.answers[1] + " " + gameData.answers[2] + " " + gameData.answers[3] + " " + gameData.answers[4] + " " + gameData.answers[5]);
		if (answers.ToString() == gameData.answers.ToString()) {
			Debug.Log ("Solution Found");
			GameObject.Find ("Status").GetComponent<Text>().text = "Solved, press quit to return.";
		} else {
			Debug.Log ("Solution not found");
			GameObject.Find ("Status").GetComponent<Text>().text = "Not solved";
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
