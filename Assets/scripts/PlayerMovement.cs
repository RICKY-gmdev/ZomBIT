using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public Camera mainCamera;
    public LineRenderer lazer;
    public Transform shootPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movement  = new Vector3(moveX,0,moveZ) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        

        Aim(); 
    }

    void Aim()
        {
               Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    float rayLength;

    if (groundPlane.Raycast(ray, out rayLength))
    {
        Vector3 pointToLook = ray.GetPoint(rayLength);
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        lazer.SetPosition(0, shootPoint.position);
        lazer.SetPosition(1, pointToLook);
    }
        }
}
