using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour {

	public static Sprite changeInputState(GameObject selected){
		GlobalObject gameData = GlobalControl.Instance.gameData;
		if (gameData.selected == null) {
			return (Resources.Load<Sprite> ("sprites/Number Tiles/blank"));
		}else{
			switch (gameData.selected.name) {
			case "one":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (1, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-blue"));
			case "two":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (2, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-blue"));			
			case "three":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (3, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-blue"));
			case "four":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (4, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-blue"));
			case "five":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (5, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-blue"));
			case "six":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (6, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-blue"));
			case "seven":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (7, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-blue"));
			case "eight":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (8, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-blue"));
			case "nine":
				gameData.setUsed (gameData.selected.name);
				gameData.selected = null;
				gameData.setSolution (9, selected.name);
				return (Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-blue"));
			}
		}
		GlobalControl.Instance.gameData = gameData;
		return (Resources.Load<Sprite> ("sprites/Number Tiles/blank"));
	}

	public static void inputStateToNull(GameObject selected){
		GlobalObject gameData = GlobalControl.Instance.gameData;
		gameData.revertInput (selected.name);
		GlobalControl.Instance.gameData = gameData;
	}

	public static Sprite changeNumBarState(GameObject selected){
		return loadSprite (selected);
	}

	public static Sprite loadSprite(GameObject selected){
		Sprite tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/blank");
		GlobalObject gameData = GlobalControl.Instance.gameData;
		int state;
		switch (selected.name) {
		//States:
		//0 = unselected
		//1 = selected
		//2 = used
		case "one":
			state = gameData.numBarState [0];
			if (state == 0) {
				gameData.numBarState [0] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [0] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/ones/1-red");
				Debug.Log ("one is used");
			}
			break;
		case "two":
			state = gameData.numBarState [1];
			if (state == 0) {
				gameData.numBarState [1] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [1] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/twos/2-red");
				Debug.Log ("two is used");			
			}
			break;
		case "three":
			state = gameData.numBarState [2];
			if (state == 0) {
				gameData.numBarState [2] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [2] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/threes/3-red");
				Debug.Log ("three is used");			
			}
			break;
		case "four":
			state = gameData.numBarState [3];
			if (state == 0) {
				gameData.numBarState [3] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [3] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fours/4-red");
				Debug.Log ("four is used");			
			}
			break;
		case "five":
			state = gameData.numBarState [4];
			if (state == 0) {
				gameData.numBarState [4] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [4] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/fives/5-red");
				Debug.Log ("five is used");			
			}
			break;
		case "six":
			state = gameData.numBarState [5];
			if (state == 0) {
				gameData.numBarState [5] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [5] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sixes/6-red");
				Debug.Log ("six is used");			
			}
			break;
		case "seven":
			state = gameData.numBarState [6];
			if (state == 0) {
				gameData.numBarState [6] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [6] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/sevens/7-red");
				Debug.Log ("seven is used");			
			}
			break;
		case "eight":
			state = gameData.numBarState [7];
			if (state == 0) {
				gameData.numBarState [7] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [7] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/eights/8-red");
				Debug.Log ("eight is used");			
			}
			break;
		case "nine":
			state = gameData.numBarState [8];
			if (state == 0) {
				gameData.numBarState [8] = 1;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-teal");
				if (gameData.selected != null) {
					gameData.revertSelected();
				}
				gameData.selected = selected;
			} else if (state == 1) {
				gameData.selected = null;
				gameData.numBarState [8] = 0;
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-blue");
			} else if (state == 2) {
				tempSprite = Resources.Load<Sprite> ("sprites/Number Tiles/nines/9-red");
				Debug.Log ("nine is used");			
			}
			break;
		}
		GlobalControl.Instance.gameData = gameData;
		return tempSprite;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
