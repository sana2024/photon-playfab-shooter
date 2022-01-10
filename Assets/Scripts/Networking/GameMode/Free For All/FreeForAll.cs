using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class FreeForAll : MonoBehaviourPun, IPunObservable
{
    public float SpawnTime;
    bool HasPlayerSpawned = false;
    float timer;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

        }
        else if (stream.IsReading)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= SpawnTime)
        {
            if (!HasPlayerSpawned)
            {
                PhotonNetwork.Instantiate("Soldier", Vector3.zero, Quaternion.identity, 0);
                HasPlayerSpawned = true;
            }
            timer = 0;
        }
    }
}
