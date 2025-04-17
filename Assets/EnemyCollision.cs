// attacher ce script au prefab ennemi.
// vérifie si l'ennemi est touché par une banane ou par le joueur.
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // la méthode est appelée lors d'une collision physique (vérifier que le composant n'a pas le "Is Trigger" de coché)
    private void OnCollisionEnter(Collision collision)
    {
        //  si ennemi est touché par une banane
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // détruis la banane
            Destroy(collision.gameObject);
            // détruis le singe
            Destroy(gameObject);
        }
        // si l'ennemi entre en collision avec le joueur
        else if (collision.gameObject.CompareTag("Player"))
        {
            // prends le script de gestion de la vie du joueur attaché au joueur
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}