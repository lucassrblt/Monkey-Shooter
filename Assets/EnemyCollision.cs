// EnemyCollision.cs
// À attacher sur le prefab Ennemi (Singe).
// Ne gère plus la collision joueur, seulement les projectiles.
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Collision physique (Is Trigger décoché).
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);    // détruit la banane
            Destroy(gameObject);              // détruit le singe
            GameScore.Instance.AddScore();    // incrémente le score
            Debug.Log("Banana hit enemy → score +1");
        }
    }
}