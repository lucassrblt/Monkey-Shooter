// À attacher sur le canvas (avec les 3 assets et le text d'importé).
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public static GameScore Instance { get; private set; }

    [Header("UI")]
    public TextMeshProUGUI text;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    [HideInInspector]
    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        text.text = "Score : " + score;
        Debug.Log("Score : " + score);
    }

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