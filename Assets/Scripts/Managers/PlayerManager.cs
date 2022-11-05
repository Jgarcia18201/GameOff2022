using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<Player> players = new List<Player>();

    private void awake()
    {
        instance = this;
    }

    public void AssignTurn(int currentPlayerTurn)
    {
        foreach(Player player in players)
        {
            player.myTurn = player.ID == currentPlayerTurn;

            //one way to do this
            /*if(player.ID == currentPlayerTurn)
            {
                player.myTurn = true;
            }
            else
            {
                player.myTurn = false;
            }*/
        }
        //another way of doing this
        //Lambda expression that goes through players to which are x to determine which player's turn it is
        //Player player = players.Find(x => x.ID == currentPlayerTurn);
        
    }
}
