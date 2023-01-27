using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNickname : MonoBehaviourPun
{
    [SerializeField] private TextMesh nameText;
    private void Start()
    {
        if (photonView.IsMine)
        {
            return;
        }
        SetName();
    }

    void Update()
    {
        
    }
    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
