using UnityEngine;

public class MovingHole : MonoBehaviour
{
    [SerializeField] private float distance = 2f;
    [SerializeField] private float speed = 2f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = startPos +
            Vector3.right * Mathf.Sin(Time.time * speed) * distance;
    }
}