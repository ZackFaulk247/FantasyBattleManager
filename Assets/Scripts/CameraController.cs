
using UnityEditorInternal;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panlimit;

    private new Camera camera;
    private float zoomTarget;

    [SerializeField]
    private float scrollSpeed = 20f, minZoom = 1f, maxZoom = 10f, smoothTime = .1f;
    private float velocity = 0f;

    private void Start()
    {
        camera = GetComponent<Camera>();
        zoomTarget = camera.orthographicSize;
    }

    void Update() {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness){
            pos.y += panSpeed * Time.deltaTime;            
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }



        zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed * 100f* Time.deltaTime;
        zoomTarget = Mathf.Clamp(zoomTarget, minZoom, maxZoom);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoomTarget, ref velocity, smoothTime);

        pos.x = Mathf.Clamp(pos.x, -panlimit.x, panlimit.x);
        pos.y = Mathf.Clamp(pos.y, -panlimit.y, panlimit.y);

        transform.position = pos; 
    }
}