using UnityEngine;

public class OpsApparition : MonoBehaviour
{
    public GameObject opsPrefab; 
    public float spawnInterval = 2f; 
    public float spawnDistance = 10f;
    public float opsSpeed = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnOps", 2f, spawnInterval);
    }

    // Update is called once per frame
    void SpawnOps()
    {
        Vector3 spawnDirection = Random.onUnitSphere;
        spawnDirection.y = 0f; // Flatten direction to horizontal plane
        spawnDirection.Normalize(); // Ensure it's still a unit vector
        
        Vector3 spawnPosition = transform.position + spawnDirection * spawnDistance;
        spawnPosition.y = transform.position.y; // Lock Y to player's Y
        
        GameObject ops = Instantiate(opsPrefab, spawnPosition, Quaternion.identity);
        ops.transform.LookAt(transform);
        Rigidbody rb = ops.GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            //rb.linearVelocity = (transform.position - spawnPosition).normalized * opsSpeed;
            rb.linearVelocity = (transform.position - spawnPosition).normalized * opsSpeed;
        }
    }
}
