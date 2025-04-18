// Score.cs
// À attacher sur un GameObject vide (par ex. "GameController").
// Gère le score et l'affichage des cœurs.
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    // Singleton pour y accéder depuis n'importe où
    public static GameScore Instance { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI text;     // Affichage du score
    public GameObject heart1;        // 1er cœur (UI Image)
    public GameObject heart2;        // 2e cœur
    public GameObject heart3;        // 3e cœur

    [HideInInspector]
    public int score = 0;            // Valeur du score

    private void Awake()
    {
        // Mise en place du singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Initialiser l'affichage au démarrage
        UpdateScoreText();
    }

    /// <summary>
    /// Appeler quand une banane touche un singe
    /// </summary>
    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    /// <summary>
    /// Affiche la nouvelle valeur du score
    /// </summary>
    private void UpdateScoreText()
    {
        text.text = "Score : " + score;
        Debug.Log("Score : " + score);
    }

    /// <summary>
    /// Appeler quand un singe touche le joueur
    /// </summary>
    public void LoseLife()
    {
        if (heart1.activeSelf)
            heart1.SetActive(false);
        else if (heart2.activeSelf)
            heart2.SetActive(false);
        else if (heart3.activeSelf)
            heart3.SetActive(false);

        Debug.Log("Life lost. Remaining hearts: " +
                  (heart1.activeSelf ? 3 : heart2.activeSelf ? 2 : heart3.activeSelf ? 1 : 0));
    }
}