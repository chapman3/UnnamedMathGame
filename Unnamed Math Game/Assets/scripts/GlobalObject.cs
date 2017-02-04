using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCalc;


public class GlobalObject {

    public enum Difficulty
    {
        easy = 1,
        medium = 2,
        hard = 3,
        hardest = 4
    }

    const int GAMEBOARD_HEIGHT = 3;
    const int GAMEBOARD_WIDTH = 3;

    [Range(0, 2)]
    public int freeAnswers;

    public int[,] gameboardNums;
    public char[] operands;
    public int[] answers;
    Difficulty difficulty;

    //constructor
    public GlobalObject(){
        //set difficulty
        setDifficulty();
        // generate numbers
        gameboardNums = RandomizeNumbers();
        // generate operands
        operands = RandomizeOperands();
        // generate answers
        answers = GenerateAnswers();
    }

    /// <summary>
    /// Sets the difficulty setting selected
    /// </summary>
    private void setDifficulty()
    {
        string text = GameObject.Find("DifficultyObj").GetComponent<Text>().text;
        Debug.Log("Difficulty:" + text);
        switch (text)
        {
            case "easy":
                difficulty = Difficulty.easy;
                break;
            case "medium":
                difficulty = Difficulty.medium;
                break;
            case "hard":
                difficulty = Difficulty.hard;
                break;
            case "hardest":
                difficulty = Difficulty.hardest;
                break;
        }
        Debug.Log(difficulty);
    }

    //class methods

    /// <summary>
    /// Randomizes a 2D array of numbers (1-9)
    /// </summary>
    /// <returns>The 2D number array</returns>
    private int[,] RandomizeNumbers()
    {
        int[,] numbers = new int[GAMEBOARD_HEIGHT, GAMEBOARD_WIDTH];
        List<int> possibleNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = 0; i < GAMEBOARD_HEIGHT; i++)
        {
            for (int k = 0; k < GAMEBOARD_WIDTH; k++)
            {
                int position = Random.Range(0, possibleNumbers.Count);
                int randomNum = possibleNumbers[position];
                possibleNumbers.RemoveAt(position);
                numbers[i, k] = randomNum;
            }
        }
        return numbers;
    }

    /// <summary>
    /// Randomizes an array of operands
    /// </summary>
    /// <returns>The operand array</returns>
    private char[] RandomizeOperands()
    {
        int size = (GAMEBOARD_HEIGHT + GAMEBOARD_WIDTH - 2) * GAMEBOARD_WIDTH;
        char[] tempOperands = new char[size];

        for (int i = 0; i < size; i++)
        {
            int operatorValue = (int)Random.Range(1, (int)difficulty + 1);
            switch (operatorValue)
            {
                case 1:
                    tempOperands[i] = '+';
                    break;
                case 2:
                    tempOperands[i] = '-';
                    break;
                case 3:
                    tempOperands[i] = '*';
                    break;
                case 4:
                    tempOperands[i] = '/';
                    break;
            }
        }
        return tempOperands;
    }


    /// <summary>
    /// Generates the answer array
    /// </summary>
    /// <returns>The answer array</returns>
    /// 
    private int[] GenerateAnswers()
    {
        int[] tempAnswers = new int[6];
        for(int i=0; i<3; i++)
        {
            tempAnswers[i] = (int)GenerateRowAnswer(i);
        }
        for(int j=3; j<6; j++)
        {
            tempAnswers[j] = (int)GenerateColumnAnswer(j - 3);
        }
        return tempAnswers;
    }


    /// <summary>
    /// Generates the answer for a single row
    /// This currently does not work if we change row count
    /// </summary>
    /// <returns>The row answer.</returns>
    /// <param name="RowIndex">The row to calculate</param> 
    /// 
    private double GenerateRowAnswer(int RowIndex)
    {
        double answer;

        //Locate which operands to use based on the row
        int operandsStartingIndex = RowIndex * 5;
        Debug.Log(operandsStartingIndex.ToString());

        //Generates the expression string for the row
        string expressionString = string.Format("{0}{1}{2}{3}{4}",
                                gameboardNums[RowIndex, 0],
                                operands[operandsStartingIndex],
                                gameboardNums[RowIndex, 1],
                                operands[operandsStartingIndex + 1],
                                gameboardNums[RowIndex, 2]);


        //Expression object for the string
        Expression expression = new Expression(expressionString);

        //final answer
        answer = System.Convert.ToDouble(expression.Evaluate());

        return answer;
    }

    /// <summary>
    /// Generates the answer for a single column
    /// This does not work for if we change the column count
    /// </summary>
    /// <returns>The column answer.</returns>
    /// <param name="ColumnIndex">The column to calculate</param>
    private double GenerateColumnAnswer(int ColumnIndex)
    {
        double answer;

        //Locate which operands to use based on the column
        int operandsStartingIndex = ColumnIndex + 2;

        //Generates the expression string for the column
        string expressionString = string.Format("{0}{1}{2}{3}{4}",
                                      gameboardNums[0, ColumnIndex],
                                      operands[operandsStartingIndex],
                                      gameboardNums[1, ColumnIndex],
                                      operands[operandsStartingIndex + 5],
                                      gameboardNums[2, ColumnIndex]
                                  );

        //Expression object for the string
        Expression expression = new Expression(expressionString);

        //final answer
        answer = System.Convert.ToDouble(expression.Evaluate());

        Debug.Log(string.Format("{0} = {1}", expressionString, answer));

        return answer;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
