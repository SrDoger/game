using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Camera Camera;
    public int playerSpeed = 1;
    public float mouseSpeed = 2.0f;
    private Vector3 startPosition;

    
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private float mouseX;
    private float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        bodyMotion();
        bodyRotation();
    }

    void bodyMotion() {

        if (Input.GetKey(KeyCode.LeftShift))
            playerSpeed = 20;
        else
            playerSpeed = 5;

        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
    }
    void bodyRotation() {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        xRotation += mouseX * mouseSpeed;
        yRotation += mouseY * mouseSpeed;
        if(Camera.transform.eulerAngles.y > 90)
        {
            yRotation = 90;
        }
        
        Camera.transform.eulerAngles = new Vector3(yRotation, xRotation, 0.0f);
        transform.eulerAngles = new Vector3(0, xRotation, 0.0f);

    }
}
