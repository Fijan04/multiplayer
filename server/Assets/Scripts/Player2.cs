using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player2 : MonoBehaviour
{
    private PhotonView PV;
    private float speed = 15f;
    private float skok = 5f;
    private float speedRotacija = 1f;
    private float udaljenostPoda = 0.9f;
    private bool isGrounded;
    private Rigidbody playerRB;
    private GameObject kameranaigracu;
    private bool skakanje;
    Vector3 offset; private void Start()
    {
        kameranaigracu = Camera.main.gameObject;
        PV = GetComponent<PhotonView>();
        playerRB = this.GetComponent<Rigidbody>();
        offset = new Vector3(0f, 5f, -15f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            skakanje = true;
            if (PV.IsMine)
            {
                kameranaigracu.transform.position = gameObject.transform.position + kameranaigracu.transform.rotation * offset;
                kameranaigracu.transform.rotation = Quaternion.Lerp(kameranaigracu.transform.rotation, gameObject.transform.rotation, speedRotacija * 10 * Time.deltaTime);
                if (Physics.Raycast(transform.position, Vector3.down, udaljenostPoda))
                {
                    isGrounded = true;
                }
                else
                {
                    isGrounded = false;
                }
                if (skakanje)
                {
                    skakanje = false; playerRB.AddForce(Vector3.up * skok, ForceMode.Impulse);
                }
                if (Input.GetKey(KeyCode.UpArrow)) { playerRB.transform.Translate(Vector3.forward * speed * Time.deltaTime); }
                if (Input.GetKey(KeyCode.DownArrow)) { playerRB.transform.Translate(Vector3.back * speed * Time.deltaTime); }
                if (Input.GetKey(KeyCode.LeftArrow)) { playerRB.transform.Rotate(Vector3.up, -1 * speedRotacija); }
                if (Input.GetKey(KeyCode.RightArrow)) { playerRB.transform.Rotate(Vector3.up, 1 * speedRotacija); }
            }
        }
    }
}
