// attacher le script au singe, cocher Is Kinematic du rigidbody et is trigger au capsule collider.
// pour la banane mettre le composant sphere collider SANS le is trigger et un rigidbody avec un is kinematic d'activé
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameScore.Instance.AddScore();  
            Debug.Log("la banane a touché le singe");
        }
    }
}