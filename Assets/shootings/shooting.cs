using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Configuration du tir")]
    public GameObject banana;
    public float shootingForce = 15f;
    public Transform SpawnPoint;
    public Camera playerCamera;
    public float maxRayDistance = 100f;

    [Header("Réglages de la rotation du pistolet")]
    public Transform rotation;
    private Quaternion originalRotation;

    void Start()
    {
        // Initialiser la rotation initiale de l'arme
        if (rotation != null)
        {
            originalRotation = rotation.rotation;
        }
        else
        {
            Debug.LogWarning("L'objet rotation (pistolet) n'est pas assigné !");
        }

        // Affecter la caméra principale si elle n'est pas assignée
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        // Vérifications préalables des objets nécessaires
        if (banana == null || SpawnPoint == null || rotation == null)
        {
            Debug.LogError("Assurez-vous que tous les objets nécessaires (banana, SpawnPoint, rotation) sont assignés !");
        }

        Debug.Log("Le script de tir a été initialisé avec succès.");
    }

    void Update()
    {
        // Détecter le clic gauche pour tirer
        if (Input.GetMouseButtonDown(0))
        {
            AimAndShoot();
        }
    }

    void AimAndShoot()
    {
        // Vérifier si les objets nécessaires sont bien assignés
        if (banana == null || SpawnPoint == null || rotation == null) return;

        // Création du rayon à partir de la position de la souris
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;

        // Déterminer la position visée
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * maxRayDistance;
        }

        // Calculer la direction visée et ajuster le SpawnPoint
        Vector3 targetDirection = targetPoint - SpawnPoint.position;
        SpawnPoint.rotation = Quaternion.LookRotation(targetDirection);

        // Ajuster la rotation du pistolet en fonction de sa position initiale
        rotation.rotation = originalRotation * Quaternion.LookRotation(targetDirection);

        // Instancier la banane et lui appliquer une force
        GameObject bananaInstance = Instantiate(banana, SpawnPoint.position, SpawnPoint.rotation);
        Rigidbody rb = bananaInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(SpawnPoint.forward * shootingForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Le prefab de banana n'a pas de Rigidbody, le tir échoue.");
        }

        // Détruire la banane après 16 secondes
        Destroy(bananaInstance, 5f);
    }
}