using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class GameSetup : MonoBehaviourPunCallbacks
{
    void Start()
    {
        CreatePlayer();   
    }
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs",
                "PhotonPlayer"), Vector3.zero, Quaternion.identity);
    }
}
