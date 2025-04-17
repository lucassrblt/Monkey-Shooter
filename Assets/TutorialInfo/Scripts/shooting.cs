using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject banana; // L'objet banane à lancer
    public float shootingForce = 15f; // Force du tir
    public Transform SpawnPoint; // Point d'apparition de la banane
    public Camera playerCamera; // La caméra utilisée pour viser
    public float maxRayDistance = 100f; // Distance maximum pour tirer si rien n'est touché
    
    //recuperer la rotation de larme
    public Transform rotation;
    void Start()
    {
        // Vérifie si une caméra est assignée
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Assignation automatique à la caméra principale
        }

        Debug.Log("Le script de tir est prêt.");
    }

    void Update()
    {
        // Écouter si l'utilisateur clique avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0)) // Bouton gauche de la souris
        {
            AimAndShoot();
        }
    }

    void AimAndShoot()
    {
        if (banana == null || SpawnPoint == null)
        {
            Debug.LogWarning("Banana ou SpawnPoint n'est pas assigné.");
            return;
        }

        // Créer un rayon depuis la position du curseur de la souris
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;

        // Vérifier si le rayon touche un objet
        if (Physics.Raycast(ray, out RaycastHit hit)) // Si un objet est touché
        {
            targetPoint = hit.point; // S'assurer que le point ciblé est celui de l'objet touché
            Debug.Log($"Objet touché à la position : {hit.point}");
        }
        else
        {
            // Si aucun objet n'est touché, calculer un point éloigné à partir du rayon
            targetPoint = ray.origin + ray.direction * maxRayDistance; // Point dans l'espace
            Debug.Log("Aucun objet touché, tir dans une direction lointaine.");
        }

        // Faire une rotation de `SpawnPoint` en direction du point visé
        Vector3 targetDirection = targetPoint - SpawnPoint.position;
        SpawnPoint.rotation = Quaternion.LookRotation(targetDirection);
        

        // Instancier la banane au niveau du SpawnPoint
        GameObject bananaInstance = Instantiate(banana, SpawnPoint.position, SpawnPoint.rotation);
        Rigidbody rb = bananaInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Appliquer une force sur la banane pour la tirer en avant
            rb.AddForce(SpawnPoint.forward * shootingForce, ForceMode.Impulse);
            Debug.Log("Banane tirée !");
        }
        else
        {
            Debug.LogError("Le prefab de banana n'a pas de Rigidbody.");
        }
    }
}

   