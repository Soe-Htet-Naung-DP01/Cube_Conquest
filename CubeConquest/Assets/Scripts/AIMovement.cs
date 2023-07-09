using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float aiCubeSpeed = 5f;
    GameStateChecker gameStateChecker;
    [SerializeField] GameObject gameStateCube;
    private bool isMoving;
    [SerializeField] int dirInt = 0;
    private void Awake() 
    {
        gameStateChecker = gameStateCube.GetComponent<GameStateChecker>();
    }
    void Update()
    {
        if(isMoving) return;
        if(gameStateChecker.isPlayerTurn) return;
        if(gameStateChecker.isAITurn)
        {
            
            //Temporary movement
            dirInt = Random.Range(1,5);
            if(dirInt == 1)
            {
                RollAndMove(Vector3.forward);
                AITurnChange();
            }
            else if(dirInt == 2)
            {
                RollAndMove(Vector3.back);
                AITurnChange();
            }
            else if(dirInt == 3)
            {
                RollAndMove(Vector3.left);

                AITurnChange();
            }
            else if(dirInt == 4)
            {
                RollAndMove(Vector3.right);
                AITurnChange();
            }
            dirInt = 0;
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
        for (var i = 0; i < 90 / aiCubeSpeed; i++) 
        {
            transform.RotateAround(anchor, axis, aiCubeSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }

    public void AITurnChange()
    {   
        gameStateChecker.isPlayerTurn = true;
        gameStateChecker.isAITurn = false;
    }

}
