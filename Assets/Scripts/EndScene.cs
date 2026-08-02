using UnityEngine;

public class EndScene : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayVictory();
    }
}