using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;


public class FireBulletOnActivate : MonoBehaviourPunCallbacks
{
    public float bulletSpeed = 250f;
    public Transform spawnPoint;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();
        grabInteractable.activated.AddListener(OnActivate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnActivate(ActivateEventArgs arg)
    {
        //play sound
        audioSource.Play();
        GameObject bullet = PhotonNetwork.Instantiate("bullet", spawnPoint.position, spawnPoint.rotation);
        bullet.transform.position = spawnPoint.position;
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        //destroy bullet after 5 seconds with photon
        //create delayed courtine 5 seconds
        StartCoroutine(DestroyBullet(bullet));
    }
    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.Destroy(bullet);
    }
}
