# UnnamedMathGame
Working Repository for The Unnamed Math Game


Scenes and Components:
----------------------
1. Home Screen
    - Scene Title
    - "High Scores" Button
      - To scene 2
    - "Credits" Button
      - To scene 3
    - "New Game" Button
      - To scene 4
2. High Scores
    - Scene Title
    - Bar across top of scene containing buttons for difficulty selector
    - High Scores list
      - 5 or 10? Static or Scrollable?
    - "Back" Button
      - To scene 1
3. Credits
    - Scene Title
    - "Back" Button
      - To scene 1
    - Credit text
    - Link to site
4. Difficulty Screen
    - Scene Title
    - Button for each difficulty
      - To Scene 5, pass difficulty setting for gameboard setup
    - "Back" Button
5. Game Board
    - Scene Title
    - Ad Banner
    - Timer
    - Number Bank
    - GameBoard
      - Operations
      - Answers
      - Input Slots (Drop number bank objects onto)
    - "Submit Solution" Button
      - Checks Solution
        - If correct, To scene 6
        - Else, highlight incorrect rows briefly
    - Hints?
6. Confirmation
    - Scene Title
    - Time
    - Name Entry (if high score)
      - Validate >0 chars entered
    - "Home" Button
      - To scene 1
    - "New Game" Button
      - To Scene 4
