using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListaIgraca : MonoBehaviourPunCallbacks
{
    Vector2 scrollPos; 

    private void OnGUI()
    {
        var a = 0; GUILayout.BeginArea(new Rect(2000, 5, 300, 300)); scrollPos.Set(100, 20);
        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(100), GUILayout.Height(100));
        GUILayout.EndArea();
        foreach (Player player1 in PhotonNetwork.PlayerList)
        {
            GUILayout.Label(player1.NickName.ToString());
        }
        GUILayout.EndScrollView();
        a++;
    }
}
