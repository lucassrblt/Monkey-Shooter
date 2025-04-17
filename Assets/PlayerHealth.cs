// PlayerHealth.cs
// À attacher sur la Main Camera (taguée Player).
// Gère la vie du joueur, la détection des ennemis via trigger, et le Game Over.
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;           // Vie du joueur
    private bool isGameOver = false; // Flag Game Over

    // Inflige des dégâts au joueur
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Le joueur a été touché. Vie : " + health);

        if (health <= 0 && !isGameOver)
            GameOver();
    }

    // Déclenché quand un autre collider Enter dans ce Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);                 // dégâts internes
            GameScore.Instance.LoseLife(); // enlève un cœur
            Destroy(other.gameObject);     // détruit le singe
            Debug.Log("Enemy hit player → lost 1 life");
        }
    }

    // Arrête le jeu et affiche le menu Game Over
    private void GameOver()
    {
        Debug.Log("Game Over !");
        isGameOver = true;
        Time.timeScale = 0;
    }

    // Affichage du bouton Recommencer
    private void OnGUI()
    {
        if (isGameOver)
        {
            int w = 200, h = 50;
            Rect rect = new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h);
            if (GUI.Button(rect, "Recommencer"))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}