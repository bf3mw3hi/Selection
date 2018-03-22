using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour {
    public List<GameObject> players;
    int playerTurn = 0;

	// Use this for initialization
	void Start () {
        players[0].SetActive(true);
        players[1].SetActive(false);
	}

    public int GetPlayerTurn()
    {
        return playerTurn;
    }
	public void NextTurn()
    {
        if (players[0].activeSelf)
        {
            players[0].SetActive(false);
            players[1].SetActive(true);
            playerTurn = 1;
        }
        else
        {
            players[0].SetActive(true);
            players[1].SetActive(false);
            playerTurn = 0;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
