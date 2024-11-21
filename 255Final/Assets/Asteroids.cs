using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // Singleton
    public static Asteroids Instance { get; private set; }

    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float asteroidSpeed = 5f;
    [SerializeField] private float spawnRangeX = 10f;
    [SerializeField] private float spawnHeight = 10f;

    // Delegate and event
    public delegate void AsteroidAction(GameObject asteroid);
    public event AsteroidAction OnAsteroidSpawned;

    // List
    private List<GameObject> activeAsteroids = new List<GameObject>();

    // Properties
    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = Mathf.Clamp(value, 0.5f, 10f); } // Limit range
    }

    public float AsteroidSpeed
    {
        get { return asteroidSpeed; }
        set { asteroidSpeed = Mathf.Clamp(value, 1f, 20f); }
    }

    private void Awake()
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

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }

    private void SpawnAsteroid()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);
        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        newAsteroid.AddComponent<FallingAsteroid>().Initialize(asteroidSpeed);

        // Add to the active list and trigger event
        activeAsteroids.Add(newAsteroid);
        OnAsteroidSpawned?.Invoke(newAsteroid);
    }

    public void RemoveAsteroid(GameObject asteroid)
    {
        if (activeAsteroids.Contains(asteroid))
        {
            activeAsteroids.Remove(asteroid);
        }
    }

    private void Update()
    {
        // Looping
        for (int i = activeAsteroids.Count - 1; i >= 0; i--)
        {
            if (activeAsteroids[i] == null)
            {
                activeAsteroids.RemoveAt(i);
            }
        }
    }
}

public class FallingAsteroid : MonoBehaviour
{
    private float speed;

    public void Initialize(float asteroidSpeed)
    {
        speed = asteroidSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
            Asteroids.Instance.RemoveAsteroid(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with: " + other.gameObject.name);
            Destroy(gameObject);
            Asteroids.Instance.RemoveAsteroid(gameObject);
        }
    }
}
