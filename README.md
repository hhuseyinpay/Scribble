# Scribble
DEU CME 1101 - PROJECT BASED LEARNING I COURSE / Project 3 (2015)




Code / Project     :  CME1101 / 3
Year / Semester	:  2015-2016 Fall Semester 
Duration	      :  4 weeks


Project:  Scribble

Scribble is a word game in which two human opponents (player1 vs player2) score points by placing letters onto a game-board which is divided into a 15×15 grid of cells. The letters must form words which, in crossword fashion, flow left to right in rows or downwards in columns consecutively.

General Information

The game is played by two opponents on a board with a 15×15 grid of cells, each of which accommodates a single letter. In their turns, players can try to form an acceptable word or they can exchange some of their letters or they can pass their turns. A word is acceptable only if it is located in given dictionary.

Rules

1.	Initially the dictionary words and letter reservoir file must be loaded. Dictionary contains the list of acceptable words, letter reservoir file contains the amount and point of each letter.  

2.	The game begins with an empty board. Each player is given a “bag”, containing 7 random letters taken from reservoir. 

3.	In their turns, one of the following actions is possible for each player; 
a.	Players must form a word by using their letters (and also the letters on the board). Once placed on the board, every accepted word stays fixed until the end of the game. 
b.	Players can return any amount of their letters to letter reservoir and get the same amount of the new letters randomly.
c.	Players can pass their turns. 

4.	After placing an acceptable word, this word and any other newly formed words' scores are calculated by summing the individual points of all included letters for each new word. This score is added to player’s total score. Automatically, player's bag refilled, getting new random letters from reservoir up to 7 letters.

5.	At least one empty cell must be left (or a border of the board) at the beginning and end of the last formed word. 

6.	Arrow keys must be used for selecting cells before letter placement. 

7.	Players can query the dictionary (max. 3 times for each turn) by using letters and dots. A dot represents any single letter.

8.	The game continues until two opponents pass their turns twice (4 consecutive passes) or reservoir gets empty.

Sample Game


Letter points:   A:1  B:3  C:3  D:2   E:1  F:4  G:2  H:4  I:1  J:8  K:5  L:1  M:3 
                 N:1  O:1  P:3  Q:10  R:1  S:1  T:1  U:1  V:4  W:4  X:8  Y:4  Z:10
+ - - - - - - - - - - - - - - - + 
| . . . . . . . . . . . . . . . | Round  : 1 (Player 1)                    Player 1:
| . . . . . . . . . . . . . . . |                                          
| . . . . . . . . . . . . . . . | Returns: _ _ _ _ _ _ _                   Bag: F Y O V G N A     
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . | Query  : _ _ _ _ _ _ _ _ _ _ _ _ _ _ _   Score: 0 + 6 = 6
| . . . . . . . . . . . . . . . |
| . . . . . C O R N . . . . . . |                                          __________________________
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Player 2:
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Bag: A C K T H P S
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Score: 0
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |
+ - - - - - - - - - - - - - - - +
 


+ - - - - - - - - - - - - - - - + 
| . . . . . . . . . . . . . . . | Round  : 2 (Player 2)                    Player 1:
| . . . . . . . . . . . . . . . |                                          
| . . . . . . . . . . . . . . . | Returns: _ _ _ _ _ _ _                   Bag: F Y O V G N A     
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . | Query  : T R . . . _ _ _ _ _ _ _ _ _ _   Score: 6
| . . . . . . . T . . . . . . . |
| . . . . . C O R N . . . . . . | TRACE                                    __________________________
| . . . . . . . A . . . . . . . | TRACK
| . . . . . . . C . . . . . . . | TRADE                                    Player 2:
| . . . . . . . K . . . . . . . | TRAIN
| . . . . . . . . . . . . . . . | TREND                                    Bag: H P S Q W E R
| . . . . . . . . . . . . . . . | TRIAL
| . . . . . . . . . . . . . . . | TROLL                                    Score: 0 + 11 = 11
| . . . . . . . . . . . . . . . | TRUCK
| . . . . . . . . . . . . . . . | TRUST
+ - - - - - - - - - - - - - - - + TRUTH




+ - - - - - - - - - - - - - - - + 
| . . . . . . . . . . . . . . . | Round  : 3 (Player 1)                    Player 1:
| . . . . . . . . . . . . . . . |                                          
| . . . . . . . . . . . . . . . | Returns: _ _ _ _ _ _ _                   Bag: F O G A R T Y     
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . | Query  : _ _ _ _ _ _ _ _ _ _ _ _ _ _ _   Score: 6 + 10 + 2 = 18
| . . . . . . . T . . . . . . . |
| . . . . . C O R N . . . . . . |                                          __________________________
| . . . . . . N A V Y . . . . . |
| . . . . . . . C . . . . . . . |                                          Player 2:
| . . . . . . . K . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Bag: H P S Q W E R
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Score: 11
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |
+ - - - - - - - - - - - - - - - +




+ - - - - - - - - - - - - - - - + 
| . . . . . . . . . . . . . . . | Round  : 4 (Player 2)                    Player 1:
| . . . . . . . . . . . . . . . |                                          
| . . . . . . . . . . . . . . . | Returns: Q W _ _ _ _ _                   Bag: F O G A R T Y     
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . | Query  : _ _ _ _ _ _ _ _ _ _ _ _ _ _ _   Score: 18
| . . . . . . . T . . . . . . . |
| . . . . . C O R N . . . . . . |                                          __________________________
| . . . . . . N A V Y . . . . . |
| . . . . . . . C . . . . . . . |                                          Player 2:
| . . . . . . . K . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Bag: H P S E R Z T
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |                                          Score: 11
| . . . . . . . . . . . . . . . |
| . . . . . . . . . . . . . . . |
+ - - - - - - - - - - - - - - - +




Suggested Weekly Program

1. Discussing the problem. Designing and creating necessary variables/structures and screen. 
    Loading dictionary and reservoir files. 
2. Game initialization. Keyboard actions: Cursor keys and placing letters on the board.
3. Checking letters of a player (forming a word, controlling restrictions and rules). 
    Computing score. Refill the bag. 
4. Dictionary query. Remaining parts of the game and test.


First Evaluation: 18.12.2015
Report: 18.12.2015
Final Evaluation: 25.12.2015 (Powerpoint + Web page)
                Report: 11.1.2016

