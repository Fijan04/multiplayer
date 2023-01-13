using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private PhotonView PV;
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (PV.IsMine)
            Movement();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void Movement()
    {
        float yMov = Input.GetAxis("Vertical");
        float xMov = Input.GetAxis("Horizontal");
        transform.position += new Vector3(xMov / 30f, 0, yMov / 30f);
    }
}
