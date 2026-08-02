using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleTrigger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ParticleSystem confetti;

    private bool levelComplete = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelComplete)
            return;

        BallController ball = other.GetComponent<BallController>();

        if (ball != null)
        {
            levelComplete = true;
            StartCoroutine(WinSequence());
        }
    }

    private IEnumerator WinSequence()
{   // Prevent the hole from triggering again
    GetComponent<Collider2D>().enabled = false;

    confetti.Play();
    
    AudioManager.Instance.PlayLevelWin();

    yield return new WaitForSeconds(1.5f);

    AudioManager.Instance.PlayWhoosh();

    LoadNextLevel();
}

    private void LoadNextLevel()
    {
        int next =
            SceneManager.GetActiveScene().buildIndex + 1;

        if (next < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(next);
        }
        else
        {
            AudioManager.Instance.PlayVictory();
            SceneManager.LoadScene("EndScene");
        }
    }
}