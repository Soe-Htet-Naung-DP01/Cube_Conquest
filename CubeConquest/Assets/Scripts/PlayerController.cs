using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float cubeSpeed = 5f;
    private bool isMoving;

    void Update()
    {
        if(isMoving) return;

        //Only move it is player's turn
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            RollAndMove(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D)) 
        {
            RollAndMove(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.W)) 
        {
            RollAndMove(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.S)) 
        {
            RollAndMove(Vector3.back);
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
}
