using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour {

	public static Sprite changeNumBarState(string selected){
		Debug.Log ("Made it to changeNumBarState");
		return loadSprite (selected);
	}

	private static Sprite loadSprite(string selected){
		Sprite tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/blank");
		GlobalObject gameData = GlobalControl.Instance.gameData;
		int state;
		switch (selected) {
		case "one":
			state = gameData.numBarState [0];
			if (state == 0) {
				gameData.numBarState [0] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-teal");
			} else if (state == 1) {
				gameData.numBarState [0] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-red");
			} else if (state == 2) {
				gameData.numBarState [0] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-blue");
			}
			break;
		case "two":
			state = gameData.numBarState [1];
			if (state == 0) {
				gameData.numBarState [1] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-teal");
			} else if (state == 1) {
				gameData.numBarState [1] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-red");
			} else if (state == 2) {
				gameData.numBarState [1] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-blue");
			}
			break;
		case "three":
			state = gameData.numBarState [2];
			if (state == 0) {
				gameData.numBarState [2] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-teal");
			} else if (state == 1) {
				gameData.numBarState [2] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-red");
			} else if (state == 2) {
				gameData.numBarState [2] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-blue");
			}
			break;
		case "four":
			state = gameData.numBarState [3];
			if (state == 0) {
				gameData.numBarState [3] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-teal");
			} else if (state == 1) {
				gameData.numBarState [3] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-red");
			} else if (state == 2) {
				gameData.numBarState [3] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-blue");
			}
			break;
		case "five":
			state = gameData.numBarState [4];
			if (state == 0) {
				gameData.numBarState [4] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-teal");
			} else if (state == 1) {
				gameData.numBarState [4] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-red");
			} else if (state == 2) {
				gameData.numBarState [4] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-blue");
			}
			break;
		case "six":
			state = gameData.numBarState [5];
			if (state == 0) {
				gameData.numBarState [5] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-teal");
			} else if (state == 1) {
				gameData.numBarState [5] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-red");
			} else if (state == 2) {
				gameData.numBarState [5] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-blue");
			}
			break;
		case "seven":
			state = gameData.numBarState [6];
			if (state == 0) {
				gameData.numBarState [6] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-teal");
			} else if (state == 1) {
				gameData.numBarState [6] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-red");
			} else if (state == 2) {
				gameData.numBarState [6] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-blue");
			}
			break;
		case "eight":
			state = gameData.numBarState [7];
			if (state == 0) {
				gameData.numBarState [7] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-teal");
			} else if (state == 1) {
				gameData.numBarState [7] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-red");
			} else if (state == 2) {
				gameData.numBarState [7] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-blue");
			}
			break;
		case "nine":
			state = gameData.numBarState [8];
			if (state == 0) {
				gameData.numBarState [8] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-teal");
			} else if (state == 1) {
				gameData.numBarState [8] = 2;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-red");
			} else if (state == 2) {
				gameData.numBarState [8] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-blue");
			}
			break;
		}
		Debug.Log (tempSprite.ToString ());
		return tempSprite;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
