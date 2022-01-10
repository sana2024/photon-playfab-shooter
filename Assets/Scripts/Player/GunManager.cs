using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class GunManager : MonoBehaviourPun
{
    public GameObject HoldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if (Input.GetKeyDown(KeyCode.E))
            {
             if(Physics.Raycast(ray, out hit , 3f))
        {
            if(hit.collider.tag == "Weapon")
            {
                        // PhotonNetwork.Destroy(hit.collider.GetComponent<PhotonView>)
                        photonView.RPC("ClaimWeapon", RpcTarget.All, hit.collider.GetComponent<PhotonView>().ViewID); 
            }
        }
        }
            }
       
      
    }
    [PunRPC]
    void ClaimWeapon(int id)
    {
        GameObject gun = PhotonView.Find(id).gameObject;
        gun.transform.SetParent(gameObject.transform);
        gun.transform.position = HoldPosition.transform.position;
        gun.transform.rotation = HoldPosition.transform.rotation;

    }
}
