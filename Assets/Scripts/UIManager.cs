using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Transform> players = new List<Transform>();
    [SerializeField] private Text currentPlayerCount;
    [SerializeField] private GameObject winPanel;
    private int playerCount;
    private bool gameEnded = false;
    void Start()
    {
        playerCount = players.Count;
    }

    void Update()
    {
        currentPlayerCount.text ="Players:" + players.Count + "/" + playerCount;
        foreach (Transform t in players)
        {
            if (t == null)
            {
                players.Remove(t);
            }
        }
        
        if(players.Count == 1 && players[0].tag == "Player" && !gameEnded)
        {
            gameEnded = true;
            winPanel.SetActive(true);
            Debug.Log("!!WIN!!"); // add win ui here
        }
    }
}
