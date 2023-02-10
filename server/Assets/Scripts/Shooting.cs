using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public float shootForce, upForce;
    public float reloadTime;
    public float timeBeetweenShooting;
    public int magazine;
    public bool allowButtonHold;
    public Camera cam;
    public Transform bulletLanding;
    private bool allowInvoke = true;
    int bulletsLeft;
    int bulletsShot;
    bool shooting;
    bool ready;
    bool reloading;
    public TextMeshProUGUI ammunition;
    private Camera kamera;
    private PhotonView view;

    private void Start()
    {
        kamera = Camera.main;
        view = GetComponent<PhotonView>();
    }
    void Update()
    {
        MyInput();
        ResetShot();
        if (ammunition != null)
        {
            ammunition.SetText(bulletsLeft + "/" + magazine);
        }
    }
    private void Awake()
    {
        bulletsLeft = magazine;
        ready = true;
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazine && !reloading)
        {
            Reload();
        }
        if (ready && shooting & !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        ready = false;
        Ray ray = kamera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(69);
        }
        Vector3 directionWithoutSpread = targetPoint - bulletLanding.position;
        GameObject currentProjectile = Instantiate(projectile, bulletLanding.position, Quaternion.identity);
        currentProjectile.transform.forward = directionWithoutSpread.normalized;
        currentProjectile.GetComponent<Rigidbody>().AddForce(directionWithoutSpread * shootForce, ForceMode.Impulse);
        //currentProjectile.GetComponent<Rigidbody>().AddForce(cam.transform.up * upForce, ForceMode.Impulse); >------- za bombe itd -------<

        bulletsLeft--;
        bulletsShot++;
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBeetweenShooting);
            allowInvoke = false;
        }
    }
    public void ResetShot()
    {
        ready = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazine;
        reloading = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && view.IsMine && other.transform.parent != transform)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (view.AmOwner) view.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
            PhotonNetwork.Destroy(other.gameObject);
            PhotonNetwork.Disconnect();
        }
    }
}
