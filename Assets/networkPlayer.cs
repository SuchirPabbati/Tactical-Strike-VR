using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class networkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform body;

    private PhotonView photonView;



    GameObject origin;
    GameObject leftController;
    GameObject rightController;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        // get xrorigin
        origin = GameObject.Find("Main Camera");
        // get controllers 
        leftController = GameObject.Find("LeftHand Controller");
        rightController = GameObject.Find("RightHand Controller");

        if (photonView.IsMine) {
            body.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        // if (photonView.IsMine)
        // {
        //     head.GetComponent<MeshRenderer>().material.color = Color.blue;
        //     leftHand.GetComponent<MeshRenderer>().material.color = Color.blue;
        //     rightHand.GetComponent<MeshRenderer>().material.color = Color.blue;
        // }
        // else
        // {
        //     head.GetComponent<MeshRenderer>().material.color = Color.red;
        //     leftHand.GetComponent<MeshRenderer>().material.color = Color.red;
        //     rightHand.GetComponent<MeshRenderer>().material.color = Color.red;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            head.position = origin.transform.position;
            head.rotation = origin.transform.rotation;

            rightHand.position = rightController.transform.position;
            rightHand.rotation = rightController.transform.rotation;

            leftHand.position = leftController.transform.position;
            leftHand.rotation = leftController.transform.rotation;

            body.position = origin.transform.position - new Vector3(0, 0.1f, 0);

        }

    }

    // collision add sc


}
