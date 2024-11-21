using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour, IMovable
{
    // Singleton
    public static ShipMovement Instance { get; private set; }

    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;

    // Properties
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = Mathf.Clamp(value, 0, 20); } // Clamp
    }

    public float RotationSpeed
    {
        get { return rotationSpeed; }
        set { rotationSpeed = Mathf.Clamp(value, 0, 200); }
    }

    
    public delegate void ShipAction(); // Delegate 
    public event ShipAction OnShipMove; // Event 

    // List
    private List<string> collectedItems = new List<string>();

    void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        HandleMovement();
    }

    public void Rotate()
    {
        HandleRotation();
    }

    private void HandleMovement()
    {
        bool moved = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            moved = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
            moved = true;
        }

        if (moved)
        {
            OnShipMove?.Invoke(); // Trigger
        }
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Debug.Log("Collided with: " + other.gameObject.name);
        }
        else if (other.CompareTag("PowerUp"))
        {
            collectedItems.Add(other.gameObject.name);
            Debug.Log("Collected: " + other.gameObject.name);
        }
    }

    void DisplayCollectedItems()
    {
        foreach (string item in collectedItems)
        {
            Debug.Log("Collected item: " + item);
        }
    }
}
