using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunctions : MonoBehaviour
{
	public GameObject player1piece;
	public GameObject player2piece;

	int[,] board = new int[9,8] {{3,3,3,3,3,3,3,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3},{3,0,0,0,0,0,0,3 },{3,3,3,3,3,3,3,3}};
	int player = 1;

	bool checkWin(int[,] board, int x, int y, int player) {
		int count = 1;
		int i = 1;
		while(board[x,y+i] == player) {
			count += 1;
			i += 1;
		}
		i = 1;
		while(board[x,y-i] == player) {
			count += 1;
			i += 1;
        }
		if(count >= 4) {
			return true;
        }
		count = 1;
		i = 1;
		while(board[x+i,y] == player) {
			count += 1;
			i += 1;
		}
		i = 1;
		while(board[x-i,y] == player) {
			count += 1;
			i += 1;
		}
		if (count >= 4)
		{
			return true;
		}
		count = 1;
		i = 1;
		while (board[x+i,y+i] == player) {
			count += 1;
			i += 1;
		}
		i = 1;
		while (board[x-i,y-i] == player) {
			count += 1;
			i += 1;
		}
		if (count >= 4)
		{
			return true;
		}
		count = 1;
		i = 1;
		while (board[x+i,y-i] == player) {
			count += 1;
			i += 1;
		}
		i = 1;
		while (board[x-i,y+i] == player) {
			count += 1;
			i += 1;
		}
		if (count >= 4)
		{
			return true;
		}
		return false;
	}

	int[,] dropCheck(int[,] board, int col, int player, out int newPlayer, GameObject piece1, GameObject piece2) {
		if(board[col,6] == 0) {
			int row = 6;
			GameObject piece;
			bool flag = true;
			while (flag) {
				if (board[col, row - 1] == 0) {
					row -= 1;
				} else {
					board[col, row] = player;
					if(player == 1) {
						piece = Instantiate(piece1, transform);
					} else {
						piece = Instantiate(piece2, transform);
                    }
					Vector3 pos = new Vector3();
					pos.x = -6.4f + 1.6f * col;
					pos.y = -5.6f + 1.6f * row;
					piece.transform.position = pos;
					flag = false;
				}
			}
			//Check for win
			if (player == 1) {
				newPlayer = 2;
			} else {
				newPlayer = 1;
			}
		} else {
			newPlayer = player;
        }
		return board;
	}


	void Start()
	{
		
	}

	void Update()
	{
        if (Input.anyKey) {
			if(Input.GetKeyDown("1")) {
				board = dropCheck(board, 1, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("2")) {
				board = dropCheck(board, 2, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("3")) {
				board = dropCheck(board, 3, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("4")) {
				board = dropCheck(board, 4, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("5")) {
				board = dropCheck(board, 5, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("6")) {
				board = dropCheck(board, 6, player, out player, player1piece, player2piece);
			} else if (Input.GetKeyDown("7")) {
				board = dropCheck(board, 7, player, out player, player1piece, player2piece);
			}
		}
	}
}
