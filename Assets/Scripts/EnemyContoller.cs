using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    public enum PatternType { UpDown, Square, Square2, LeftRight }
    public PatternType pattern;

    public int beatsPerMove = 2; // Moverse cada 1, 2, 3 beats...
    private int beatCounter = 0;

    public float moveDistance = 1f;

    private bool movingRight = true;

    // o dirección aleatoria

    private int squareStep = 0;
    private int squareStep2 = 1;

    private Vector2Int[] squarePattern = new Vector2Int[]
    {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
    };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnEnable()
    {
        Conductor.Instance.OnBeat += OnBeatReceived;
    }

    void OnDisable()
    {
        Conductor.Instance.OnBeat -= OnBeatReceived;
    }
    

    void OnBeatReceived()
    {
        beatCounter++;

        if (beatCounter >= beatsPerMove)
        {
            Move();
            beatCounter = 0;
        }
    }

    void Move()
    {

        Vector2Int direction = Vector2Int.zero;
        

        
            switch (pattern)
            {
                case PatternType.UpDown:
                    if (movingRight)
                    {
                        direction = Vector2Int.up;
                    }
                    else
                    {
                        direction = Vector2Int.down;
                    }
                    movingRight = !movingRight;

                    break;

                case PatternType.Square:
                
                direction = squarePattern[squareStep];
                squareStep = (squareStep + 1);
                if (squareStep == 4)
                {
                    squareStep -= 4;
                }
                break;

            case PatternType.Square2:
                
                direction = squarePattern[squareStep2];
                squareStep2 = (squareStep2 + 1) % squarePattern.Length;
                if (squareStep2 == 4)
                {
                    squareStep2 -= 4;
                }
                break;

            case PatternType.LeftRight:


                if (movingRight)
                {
                    direction = Vector2Int.right;
                }
                else
                {
                    direction = Vector2Int.left;
                }
                movingRight = !movingRight;

                break;
        }


        
            transform.position += (Vector3)(Vector2)direction * moveDistance;
        
    }

    


}
