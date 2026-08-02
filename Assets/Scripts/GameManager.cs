using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Lives")]
    [SerializeField] private int maxLives = 5;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI livesText;

    private int currentLives;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        currentLives--;

        UpdateLivesUI();

        if (currentLives <= 0)
        {
            RestartLevel();
        }
    }

    private void UpdateLivesUI()
    {
        livesText.text = "x" + currentLives;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}