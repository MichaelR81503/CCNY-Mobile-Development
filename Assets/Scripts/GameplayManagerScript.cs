using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameplayManagerScript : MonoBehaviour
{

    Health damage;
    [SerializeField] private GameObject hitPoints;
    [SerializeField] private Transform targetObject;
    [SerializeField] private Camera mainCam;
    Vector3 movementVector;
    public float lastHorizontalVector;
    public float lastVerticalVector;

    public Transform target;

    private bool isHolding = false;

    public enum MoveType
    {
        MoveDistance,
        MoveToTarget,
        MoveToClick
    }

    [Header("Movement")]
    public MoveType moveType;

    public float moveDistance = 2f;
    public float moveTime = 0.5f;

    public Transform targetPosition;

    [Header("Click Movement")]
    public Camera mainCamera;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
        if (mainCam == null)
            mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }

        if (Input.GetMouseButton(0))
        {
            isHolding = true;

            if (moveType == MoveType.MoveToClick)
            {
                MoveToClickedPosition(Input.mousePosition);
                
            }
            else
            {
                Move();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
        }


    }

    void Move()
    {
        //distance forward
        if (moveType == MoveType.MoveDistance)
        {
            Vector3 newPosition =  transform.position +transform.forward * moveDistance;
            transform.DOMove(newPosition, moveTime);
        }

        //move to gameobject
        if (moveType == MoveType.MoveToTarget)
        {
            transform.DOMove(targetPosition.position, moveTime);
        }
    }

    void MoveToClickedPosition(Vector2 screenPosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 newPosition = hit.point;
            newPosition.z = transform.position.z;
            transform.DOMove(newPosition, moveTime).SetEase(Ease.Linear);
            transform.LookAt(target);
            transform.LookAt(target, Vector3.left);
            //look at mouse 

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScore();
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER");

        }


    }


    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
