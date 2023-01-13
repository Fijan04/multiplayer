using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectTest : MonoBehaviourPunCallbacks
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("spajanje");
            PhotonNetwork.ConnectUsingSettings(); //uzima sve potrebne postavke za spajanje
            PhotonNetwork.GameVersion = "0.0.1"; //zapisuje verziju igre
            //SceneManager.LoadScene("Loading");
           // DontDestroyOnLoad(gameObject);
        }
    }

    public override void OnConnectedToMaster() //prepoznaje kada smo spojeni na server
    {
        print("spojen na server");
        //SceneManager.LoadScene("Spojen");
       // DontDestroyOnLoad(gameObject);
    }

    public override void OnDisconnected(DisconnectCause razlog) //prepoznaje kad smo odspojeni i daje nam razlog zasto
    {
        print("odspojen sa servera zbog" + razlog.ToString());
        //SceneManager.LoadScene("Odspojen");
        //DontDestroyOnLoad(gameObject);
    }   
}
