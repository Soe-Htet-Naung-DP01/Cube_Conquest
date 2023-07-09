using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateChecker : MonoBehaviour
{
    public bool isPlayerTurn;
    public bool isAITurn;
    public int turnCount;
    public bool turnChanged;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        isAITurn = false;
        turnCount = 0;
        turnChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnTracker()
    {
        
    }
}
