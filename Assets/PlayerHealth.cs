// PlayerHealth.cs
// À attacher sur la Main Camera (mettre le tag: Player, rigidbody avec is kinematic activé et is trigger sur le sphere collider activé également).
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    private bool isGameOver = false;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Le joueur a été touché. Vie : " + health);

        if (health <= 0 && !isGameOver)
            Debug.Log("game over");
    }

    // se déclenche quand un collider entre dans un trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            GameScore.Instance.LoseLife();
            Destroy(other.gameObject); 
            Debug.Log("Enemy hit player → lost 1 life");
        }
    }
}