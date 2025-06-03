using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static ScoreManager;


public class PlayerController : MonoBehaviour
{
    public float moveDistance = 1f;
    public float beatLeeway = 0.4f;
   
    private Vector2 inputDirection;
    private bool canMove = false;

    private Rigidbody2D rb;


    void OnEnable()
    {
        Conductor.Instance.OnBeat += AllowMove;
    }

    void OnDisable()
    {
        Conductor.Instance.OnBeat -= AllowMove;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!canMove) return;

        Vector2 inputDirection = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.W)) inputDirection = Vector2.up;
        if (Input.GetKeyDown(KeyCode.S)) inputDirection = Vector2.down;
        if (Input.GetKeyDown(KeyCode.A)) inputDirection = Vector2.left;
        if (Input.GetKeyDown(KeyCode.D)) inputDirection = Vector2.right;

        if (inputDirection != Vector2.zero)
        {            
            float distanceToBeat = Mathf.Min(Conductor.Instance.GetTimeSinceLastBeat(), Conductor.Instance.secPerBeat - Conductor.Instance.GetTimeSinceLastBeat());

            if (distanceToBeat <= beatLeeway)
            {
                HitAccuracy accuracy;

                if (distanceToBeat < 0.07f)
                    accuracy = HitAccuracy.Perfect;
                else if (distanceToBeat < 0.15f)
                    accuracy = HitAccuracy.Good;
                else
                    accuracy = HitAccuracy.Miss;

                ScoreManager.Instance.RegisterHit(accuracy);                
            
                Vector2 targetPosition = rb.position + inputDirection.normalized * moveDistance;
                if (!IsBlocked(inputDirection))
                {
                    rb.MovePosition(targetPosition);
                }
                canMove = false;
            }
            else
            {
                ScoreManager.Instance.RegisterHit(HitAccuracy.Miss);
                canMove = false;
            }
            
        }
    }

    void AllowMove()
    {
        canMove = true;
    }

    bool IsBlocked(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, moveDistance, LayerMask.GetMask("Wall"));
        return hit.collider != null;
    }


}
