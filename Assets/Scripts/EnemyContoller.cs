using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    public enum PatternType { UpDown, Square, Square2, LeftRight }
    public PatternType pattern;

    public int beatsPerMove = 2;
    private int beatCounter = 0;

    public float moveDistance = 1f;
    public float moveDuration = 0.15f;

    private bool movingRight = true;

    private int squareStep = 0;
    private int squareStep2 = 1;

    private Vector2Int[] squarePattern = new Vector2Int[]
    {
    Vector2Int.up,
    Vector2Int.right,
    Vector2Int.down,
    Vector2Int.left
    };

    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float moveTimer = 0f;

    private float contactTimer = 0f;
    private float contactThreshold = 0.01f;
    private bool playerInside = false;
    private PlayerController playerRef;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null && !player.IsMoving())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        if (other.CompareTag("Player"))
        {
            playerRef = other.GetComponent<PlayerController>();
            playerInside = true;
            contactTimer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            contactTimer = 0f;
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

    void Update()
    {
        if (isMoving)
        {
            moveTimer += Time.deltaTime;
            float t = Mathf.Clamp01(moveTimer / moveDuration);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                isMoving = false;
            }

            if (!playerRef.IsMoving() && !isMoving)
            {
                contactTimer += Time.deltaTime;
                if (contactTimer >= contactThreshold)
                {
                    float distance = Vector2.Distance(transform.position, playerRef.transform.position);
                    if (distance < 0.1f) 
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                    else
                    {                        
                        contactTimer = 0f;
                        playerInside = false;
                    }
                }
            }
        }
    }

    void OnBeatReceived()
    {
        beatCounter++;
        if (beatCounter >= beatsPerMove && !isMoving)
        {
            Vector2Int direction = Move();
            StartMove(direction);
            beatCounter = 0;

            /*Move();
            beatCounter = 0;*/
        }
    }

    Vector2Int Move()
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
        return direction;
    }
    void StartMove(Vector2Int direction)
    {
        startPosition = transform.position;
        targetPosition = transform.position + (Vector3)(Vector2)direction * moveDistance;
        moveTimer = 0f;
        isMoving = true;
    }
}
