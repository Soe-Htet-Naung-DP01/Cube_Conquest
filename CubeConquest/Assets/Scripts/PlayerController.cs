using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float cubeSpeed = 5f;
    GameStateChecker gameStateChecker;
    [SerializeField] GameObject gameStateCube;
    private bool isMoving;

    private void Awake() 
    {
        gameStateChecker = gameStateCube.GetComponent<GameStateChecker>();
    }
    void Update()
    {
        if(isMoving) return;
        if(gameStateChecker.isAITurn) return;

        //Only move it is player's turn
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            if(gameStateChecker.isPlayerTurn == true)
            {
                RollAndMove(Vector3.left);
            }
            PlayerTurnChange();
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            if(gameStateChecker.isPlayerTurn == true)
            {
                RollAndMove(Vector3.right);
            }
            PlayerTurnChange();
        }
        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            if(gameStateChecker.isPlayerTurn == true)
            {
                RollAndMove(Vector3.forward);
            }
            PlayerTurnChange();
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            if(gameStateChecker.isPlayerTurn == true)
            {
                RollAndMove(Vector3.back);
            }
            PlayerTurnChange();
        }

        void RollAndMove (Vector3 dir)
        {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }

    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis) 
    {
        isMoving = true;
        for (var i = 0; i < 90 / cubeSpeed; i++) 
        {
            transform.RotateAround(anchor, axis, cubeSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }

    public void PlayerTurnChange()
    {
        gameStateChecker.isPlayerTurn = false;
        gameStateChecker.isAITurn = true;
        gameStateChecker.turnCount += 1;
    }
}
