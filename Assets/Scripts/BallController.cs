using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [Header("Launch Settings")]
    [SerializeField] private float maxDragDistance = 2f;
    [SerializeField] private float launchForce = 10f;

    [Header("References")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform aimArrow;

    [Header("Arrow")]
    [SerializeField] private float minArrowLength = 0.6f;
    [SerializeField] private float maxArrowLength = 1.5f;

    private Rigidbody2D rb;
    private Camera cam;

    private bool isDragging = false;
    private bool canShoot = true;

    private Vector2 dragStart;
    private Vector2 dragDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        aimArrow.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!canShoot)
            return;

        Vector2 pointerPos = GetPointerPosition();
        // Start dragging
        if (!isDragging && PointerPressed())
        {
            Collider2D hit = Physics2D.OverlapPoint(pointerPos);


        if (hit != null && hit.GetComponentInParent<BallController>() != null)
        {

            isDragging = true;
            dragStart = transform.position;

            aimArrow.gameObject.SetActive(true);
        }
        }

        // While dragging
        if (isDragging)
        {
            dragDirection = dragStart - pointerPos;
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxDragDistance);

            UpdateArrow();

            if (PointerReleased())
            {
                LaunchBall();
            }
        }
    }

    private void UpdateArrow()
    {
        float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
        aimArrow.rotation = Quaternion.Euler(0, 0, angle - 90f);

        // Calculate power (0 to 1)
        float power = dragDirection.magnitude / maxDragDistance;
        power *= power; // Smooth scaling

        // Move arrow further away as power increases
        float offset = Mathf.Lerp(0.35f, 0.8f, power);
        aimArrow.localPosition = dragDirection.normalized * offset;

        // Uniformly scale arrow
        float size = Mathf.Lerp(minArrowLength, maxArrowLength, power);
        aimArrow.localScale = Vector3.one * size;
    }

    private void LaunchBall()
    {
        isDragging = false;
        canShoot = false;

        aimArrow.gameObject.SetActive(false);

        rb.linearVelocity = dragDirection * launchForce;
        AudioManager.Instance.PlayLaunch();
    }

    private void FixedUpdate()
    {
        if (!canShoot)
        {
            if (rb.linearVelocity.magnitude < 0.1f)
            {
                rb.linearVelocity = Vector2.zero;
                canShoot = true;
            }
        }
    }

    private Vector2 GetPointerPosition()
    {
    #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return cam.ScreenToWorldPoint(Input.mousePosition);
    #else
        if (Input.touchCount > 0)
            return cam.ScreenToWorldPoint(Input.GetTouch(0).position);

        return Vector2.zero;
    #endif
    }

    private bool PointerPressed()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButtonDown(0);
#else
        return Input.touchCount > 0 &&
               Input.GetTouch(0).phase == TouchPhase.Began;
#endif
    }

    private bool PointerReleased()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButtonUp(0);
#else
        return Input.touchCount > 0 &&
               (Input.GetTouch(0).phase == TouchPhase.Ended ||
                Input.GetTouch(0).phase == TouchPhase.Canceled);
#endif
    }

    public void Respawn()
    {
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        canShoot = false;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = false;

        aimArrow.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        transform.position = spawnPoint.position;
        transform.rotation = Quaternion.identity;

        rb.simulated = true;

        isDragging = false;
        canShoot = true;
    }
}