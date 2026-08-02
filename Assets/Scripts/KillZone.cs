using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController ball = other.GetComponent<BallController>();

        if (ball != null)
        {
            GameManager.Instance.LoseLife();
            AudioManager.Instance.PlayLoseLife();
            ball.Respawn();
        }
    }
}