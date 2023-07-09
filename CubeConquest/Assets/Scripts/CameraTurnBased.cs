using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnBased : MonoBehaviour
{
    [SerializeField] Transform playerObj;
    [SerializeField] Transform aiObj;
    GameStateChecker gameStateChecker;
    [SerializeField] GameObject gameStateCube;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    private void Awake() 
    {
        gameStateChecker = gameStateCube.GetComponent<GameStateChecker>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameStateChecker.isPlayerTurn)
        {
            ShowCurrentTurn(playerObj);
        }
        else if(gameStateChecker.isAITurn)
        {
            ShowCurrentTurn(aiObj);
        }
    }

    public void ShowCurrentTurn(Transform objToShow)
    {
        transform.position = objToShow.position + offset;
    }
}
