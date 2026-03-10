using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TicTacToeGrid : MonoBehaviour
{
    char[,] tictactoeGrid = new char[3, 3];
    [SerializeField] Image[,] symbols = new Image[3, 3];
    [SerializeField] Sprite xSymbol;
    [SerializeField] Sprite oSymbol;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] Image turnSymbol;
    char turn;

    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                tictactoeGrid[i, j] = ' ';
                symbols[i, j] = transform.GetChild((i * 3) + j).GetChild(0).GetComponent<Image>();
            }
        }

        turn = 'X';
    }

    public void PlayTurn(int position)
    {
        int x = position / 3;
        int y = position % 3;
        if (tictactoeGrid[x, y] == ' ')
        {
            tictactoeGrid[x, y] = turn;
            SetSymbol(x, y);
            VerifyVictory();
            ChangeTurn();          
        }
    }

    public void ChangeTurn()
    {
        if(turn == 'X')
        {
            turn = 'O';
            turnSymbol.sprite = oSymbol;
        }
        else
        {
            turn = 'X';
            turnSymbol.sprite = xSymbol;
        }
    }

    public void VerifyVictory()
    {
        //TODO Vous devrez programmer la vérification de victoire ici
        //S'il y a un gagnant, appeller la fonction ShowWinner(turn)
        //En cas d'égalité, appeller la fonction ShowWinner et faite en sorte que celle-ci gère les partie nulle

        for (int i = 0; i < tictactoeGrid.Length; i++)
        {
            //for (int j = 0; j<3; j++)
            {
                if (tictactoeGrid[0, 0]=='X'&& tictactoeGrid[0, 1]=='X'&& tictactoeGrid[0, 2]=='X' || tictactoeGrid[0, 0]=='O'&& tictactoeGrid[0, 1]=='O'&& tictactoeGrid[0, 2]=='O')
                {
                    ShowWinner(turn);
                }
            }
            //for (int j = 1; j<4; j++)
            {
                if (tictactoeGrid[1, 0]=='X'&& tictactoeGrid[1, 1]=='X'&& tictactoeGrid[1, 2]=='X' || tictactoeGrid[1, 0]=='O'&& tictactoeGrid[1, 1]=='O'&& tictactoeGrid[1, 2]=='O')
                {
                    ShowWinner(turn);
                }
                
            }
            //for (int j = 2; j<5; j++)
            {
                if (tictactoeGrid[2, 0]=='X'&& tictactoeGrid[2, 1]=='X'&& tictactoeGrid[2, 2]=='X' || tictactoeGrid[2, 0]=='O'&& tictactoeGrid[2, 1]=='O'&& tictactoeGrid[2, 2]=='O')
                {
                    ShowWinner(turn);
                }
                
            }

            for (int j = 0; j<7; j++)
            {
                if (tictactoeGrid[0, 0]=='X'&& tictactoeGrid[1, 0]=='X'&& tictactoeGrid[2, 0]=='X' || tictactoeGrid[0, 0]=='O'&& tictactoeGrid[1, 0]=='O'&& tictactoeGrid[2, 0]=='O')
                {
                    ShowWinner(turn);
                }
            }
            //for (int j = 0; j<9; j++)
            {
                if (tictactoeGrid[0, 1]=='X'&& tictactoeGrid[1, 1]=='X'&& tictactoeGrid[2, 1]=='X' || tictactoeGrid[0, 1]=='O'&& tictactoeGrid[1, 1]=='O'&& tictactoeGrid[2, 1]=='O')
                {
                    ShowWinner(turn);
                }
            }
            //for (int j = 0; j<10; j++)
            {
                if (tictactoeGrid[0, 2]=='X'&& tictactoeGrid[1, 2]=='X'&& tictactoeGrid[2, 2]=='X' || tictactoeGrid[0, 2]=='O'&& tictactoeGrid[1, 2]=='O'&& tictactoeGrid[2, 2]=='O')
                {
                    ShowWinner(turn);
                }
            }
            //for (int j = 0; j<10; j++)
            {
                if (tictactoeGrid[0, 0]=='X'&& tictactoeGrid[1, 1]=='X'&& tictactoeGrid[2, 2]=='X' || tictactoeGrid[0, 0]=='O'&& tictactoeGrid[1, 1]=='O'&& tictactoeGrid[2, 2]=='O')
                {
                    ShowWinner(turn);
                }
            }
            //for (int j = 0; j<8; j++)
            {
                if (tictactoeGrid[0, 2]=='X'&& tictactoeGrid[1, 1]=='X'&& tictactoeGrid[2, 0]=='X' || tictactoeGrid[0, 2]=='O'&& tictactoeGrid[1, 1]=='O'&& tictactoeGrid[2, 0]=='O')
                {
                    ShowWinner(turn);
                }
            }
          

            

        }
    }

    public void PlayRandomTurn()
    {
        //TODO Vous devrez programmer une fonction qui permettra de jouer le tour actuel aléatoirement
    }

    public void SetSymbol(int x, int y)
    {
        if(turn == 'X')
        {
            symbols[x, y].sprite = xSymbol;
        }
        else
        {
            symbols[x, y].sprite = oSymbol;
        }
    }

    public void ShowWinner(char winner)
    {
        //TODO Vous aurez à modifier légèrement cette fonction afin de faire fonctionner les partie nulle
       
        for (int i = 0; i<tictactoeGrid.Length; i++)
        {
           
            if (i<tictactoeGrid.Length)
            {
                winnerPanel.SetActive(true);
                winnerText.text = "Le gagnant est : " + winner;

            }
            else
            {
                for (int y = 0; y<tictactoeGrid.Length; i++) 
                {
                    if (symbols[i,y].sprite=xSymbol)
                        symbols[i,y].sprite = null;
                    else
                        symbols[i,y].sprite =null;
                    
                       
                }
                   

            }
        }
             
        
            
        
       
    }


}
