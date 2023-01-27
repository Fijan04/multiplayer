using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class ShowNick : MonoBehaviourPun
{
    private Collider[] objects;
    private Collider[] objectp;
    public Texture texture;
    GUIContent content;

    private void Update()
    {
        objects = Physics.OverlapSphere(transform.position, 20f, LayerMask.GetMask("Water"));
        objectp = Physics.OverlapSphere(transform.position, 20f, LayerMask.GetMask("Neprijatelj"));
    }
    private void OnGUI()
    {
        GUI.color = Color.white;
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 screenpos = Camera.main.WorldToScreenPoint(objects[i].transform.position);
            screenpos.y = Screen.height - screenpos.y;
            content = new GUIContent(objects[i].name, texture);
            if (photonView.IsMine) GUI.Box(new Rect(screenpos.x, screenpos.y - 100, Screen.width / 8, Screen.height / 20), content);
        }
        for (int i = 0; i < objectp.Length; i++)
        {
            Vector3 screenpos = Camera.main.WorldToScreenPoint(objectp[i].transform.position);
            content = new GUIContent(objectp[i].GetComponent<PhotonView>().Owner.NickName, texture);
            if (photonView.IsMine) GUI.Box(new Rect(screenpos.x, screenpos.y - 100, Screen.width / 8, Screen.height / 20), content);
        }
    }
}
