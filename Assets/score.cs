using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

public class score : MonoBehaviour
{
    PhotonView pv;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            pv = collision.gameObject.GetComponent<PhotonView>();
            pv.Owner.AddScore(1);
        }
    }

}
