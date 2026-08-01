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
            StartCoroutine(WinSequence(ball));
        }
    }

    private IEnumerator WinSequence(BallController ball)
    {   Debug.Log("Win!");

        confetti.Play();

        yield return new WaitForSeconds(2f);

        LoadNextLevel();
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = false;

        // Tiny sink
        ball.transform.position += Vector3.down * 0.08f;
        yield return new WaitForSeconds(1.5f);
        // Hide the ball
        ball.gameObject.SetActive(false);


        yield return new WaitForSeconds(1.5f);

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
            Debug.Log("Game Complete!");
        }
    }
}