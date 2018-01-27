using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speedX = 1.0f;
    [SerializeField] private float speedY = 1.0f;

    [Header("Camera Bounds")]
    [Space(10)]
    [SerializeField] private bool bounds = true;

    [Space(10)]
    [SerializeField] private Vector3 minCameraPosition;
    [SerializeField] private Vector3 maxCameraPosition;

    [Space(5)]
    [Header("Deadzone")]
    [Tooltip("Each parameter should have a value between 0 and 1.")]
    [Space(10)]
    [SerializeField] private Rect Deadzone;

    [Header("Camera offset")]
    [Space(10)]
    [SerializeField] private bool useOffset = true;
    [SerializeField] private Vector2 offset2D;

    private Camera mainCam;

    private void Start()
    {
        mainCam = GetComponent<Camera>();

        if(!useOffset)
        {
            offset2D = new Vector2(transform.position.x - target.position.x,
                                 transform.position.y - target.position.y);
        }
    }

    private void LateUpdate()
    {
        if(target == null)
        {
            Debug.LogWarning("Camera has no object to focus on.");
            return;
        }

        Vector3 viewPos = mainCam.WorldToViewportPoint(target.position);

        float posX = transform.position.x;
        float posY = transform.position.y;

        if(IsOutSideDeadZoneX(viewPos))
        {
            posX = MoveTowardsTargetX();
        }

        if (IsOutSideDeadZoneY(viewPos))
        {
            posY = MoveTowardsTargetY();
        }

        transform.position = new Vector3(posX, posY, transform.position.z);

        if(bounds)
        {
            ClampCamera();
        }
    }

    private bool IsOutSideDeadZoneX(Vector3 viewPos)
    {
        return viewPos.x >= Deadzone.width || viewPos.x <= Deadzone.x;
    }

    private bool IsOutSideDeadZoneY(Vector3 viewPos)
    {
        return viewPos.y <= Deadzone.y || viewPos.y >= Deadzone.height;
    }

    private float MoveTowardsTargetX()
    {
        return Mathf.MoveTowards(transform.position.x, target.position.x + offset2D.x, speedX * Time.deltaTime);
    }

    private float MoveTowardsTargetY()
    {
        return Mathf.MoveTowards(transform.position.y, target.position.y + offset2D.y, speedY * Time.deltaTime);
    }
  
    private void ClampCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
                                         Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
                                         Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
    }
}
