using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    public int beatsPerMove = 2; // Moverse cada 1, 2, 3 beats...
    private int beatCounter = 0;

    public float moveDistance = 1f;

    private Vector2 currentDirection = Vector2.right; // o dirección aleatoria

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(RestartLevel());
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
                
        currentDirection = GetRandomDirection();
        transform.position += (Vector3)currentDirection * moveDistance;
    }

    Vector2 GetRandomDirection()
    {
        System.Random alea = new System.Random();
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        return directions[alea.Next(0, directions.Length)];
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
