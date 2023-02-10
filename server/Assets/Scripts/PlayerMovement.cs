using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    private Vector2 rotate;
    public float speed = 5f;
    public Rigidbody rb;

    private GameObject kameranaigracu;
    Vector3 offset;
    private float speedRotacija = 1f;

    void Start()
    {
        kameranaigracu = Camera.main.gameObject;
        offset = new Vector3(0f, 3f, -10f);

        Cursor.lockState = CursorLockMode.Locked;
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (PV.IsMine)
        {
            Movement();
            MouseLook();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            kameranaigracu.transform.position = gameObject.transform.position + kameranaigracu.transform.rotation * offset;
            kameranaigracu.transform.rotation = Quaternion.Lerp(kameranaigracu.transform.rotation, gameObject.transform.rotation, speedRotacija * 10 * Time.deltaTime);
        }
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    void MouseLook()
    {
        rotate.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(-rotate.y, rotate.x, 0);
    }
}
