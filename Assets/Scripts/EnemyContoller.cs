using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    public EnemyPattern movementPattern;

    public bool initialUp = true;
    public bool initialRight = true;
    public int beatsPerMove = 2;
    public float moveDistance = 1f;
    public float moveDuration = 0.1f;

    private IEnemyPattern patternInstance;
    private int beatCounter = 0;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float moveTimer = 0f;

    void OnEnable()
    {
        Conductor.Instance.OnBeat += OnBeatReceived;
    }

    void OnDisable()
    {
        Conductor.Instance.OnBeat -= OnBeatReceived;
    }

    void Start()
    {
        patternInstance = movementPattern.CreateInstance();
        patternInstance.Initialize(this);
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
                CheckPlayerCollision(targetPosition);
            }
        }
    }

    void OnBeatReceived()
    {
        beatCounter++;

        if (beatCounter >= beatsPerMove)
        {
            Vector2Int direction = Move();
            beatCounter = 0;

            if (direction == Vector2Int.zero)
            {
                CheckPlayerCollision(transform.position);
            }
            else
            {
                StartMove(direction);
            }
        }
        else
        {
            CheckPlayerCollision(transform.position);
        }
    }

    Vector2Int Move()
    {
        if (patternInstance == null) return Vector2Int.zero;
        return patternInstance.GetDirection();
    }

    void StartMove(Vector2Int direction)
    {
        startPosition = transform.position;
        targetPosition = transform.position + (Vector3)(Vector2)direction * moveDistance;
        moveTimer = 0f;
        isMoving = true;

        CheckPlayerCollision(startPosition);
    }

    void CheckPlayerCollision(Vector3 positionToCheck)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(positionToCheck, player.transform.position);
            if (distance < 0.2f)
            {
                PlayerController p = player.GetComponent<PlayerController>();
                if (p != null)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
