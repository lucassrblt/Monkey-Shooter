using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Configuration du tir")]
    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private float shootingForce = 15f;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxRayDistance = 100f;

    [Header("Réglages de la rotation du pistolet")]
    [SerializeField] private Transform rotationTransform;
    [SerializeField] private float rotationSmoothness = 10f;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        if (bananaPrefab == null || spawnPoint == null || rotationTransform == null)
        {
            Debug.LogError("Assurez-vous que bananaPrefab, spawnPoint et rotationTransform sont bien assignés !");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * maxRayDistance;
        }

        Vector3 direction = (targetPoint - spawnPoint.position).normalized;

        // Tourne le point de spawn vers la cible
        spawnPoint.rotation = Quaternion.LookRotation(direction);

        GameObject bananaInstance = Instantiate(bananaPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = bananaInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shootingForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Le prefab 'bananaPrefab' doit contenir un Rigidbody !");
        }

        Destroy(bananaInstance, 5f);
    }
}
