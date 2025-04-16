// Attacher ce script à l'objet joueur (la caméra) pour gérer la vie du joueur et l'affichage du Game Over.
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Vie du joueur
    private bool isGameOver = false;

    // Fonction damage joueur
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Le joueur a été touché. Vie : " + health);

        if (health <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    // Fonction game over
    private void GameOver()
    {
        Debug.Log("Game Over !");
        isGameOver = true;
        Time.timeScale = 0;
    }

    // UI Game Ovr
    private void OnGUI()
    {
        if (isGameOver)
        {
            // Dimensions pour le bouton de redémarrage
            int buttonWidth = 200;
            int buttonHeight = 50;
            Rect restartButtonRect = new Rect(
                (Screen.width - buttonWidth) / 2,
                (Screen.height - buttonHeight) / 2,
                buttonWidth,
                buttonHeight
            );

            if (GUI.Button(restartButtonRect, "Recommencer"))
            {
                // Remettre le temps à la normale
                Time.timeScale = 1;
                // Recharger la scène actuelle
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}