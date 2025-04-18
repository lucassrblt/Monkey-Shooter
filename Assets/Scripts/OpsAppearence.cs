using UnityEngine;

public class OpsApparition : MonoBehaviour
{
    public GameObject opsPrefab; 
    public float spawnInterval = 2f; 
    public float spawnDistance = 10f;
    public float opsSpeed = 2f;
    public float speedIncreaseInterval = 15f; // time between speed boosts
    public float speedIncreaseAmount = 0.5f;   // how much speed increases

    private float timeSinceLastIncrease = 0f;

    void Start()
    {
        InvokeRepeating("SpawnOps", 2f, spawnInterval);
    }

    void Update()
    {
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= speedIncreaseInterval)
        {
            opsSpeed += speedIncreaseAmount;
            timeSinceLastIncrease = 0f;
            Debug.Log("Ops speed increased to: " + opsSpeed);
        }
    }

    void SpawnOps()
    {
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = 0f;
        spawnDirection.Normalize();

        Vector3 spawnPosition = transform.position + spawnDirection * spawnDistance;
        spawnPosition.y = transform.position.y;

        GameObject ops = Instantiate(opsPrefab, spawnPosition, Quaternion.identity);
        ops.transform.LookAt(transform);

        Rigidbody rb = ops.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = (transform.position - spawnPosition).normalized * opsSpeed;
        }
    }
}