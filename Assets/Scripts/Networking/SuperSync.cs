using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class SuperSync : MonoBehaviourPun, IPunObservable
{
    public Vector3 ObjPosition;
    public Quaternion ObjRotation;
    public Vector3 ObjScale;

    public float Lerpspeed = 3f;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(gameObject.transform.position);
            stream.SendNext(gameObject.transform.rotation);
            stream.SendNext(gameObject.transform.localScale);
        }
        else if (stream.IsReading)
        {
            ObjPosition = (Vector3)stream.ReceiveNext();
            ObjRotation = (Quaternion)stream.ReceiveNext();
            ObjScale = (Vector3)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            UpdateTransform();
        }
    }

    private void UpdateTransform()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, ObjPosition, Lerpspeed * Time.deltaTime);
        gameObject.transform.rotation=Quaternion.Lerp(gameObject.transform.rotation,ObjRotation, Lerpspeed * Time.deltaTime);
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, ObjScale , Lerpspeed * Time.deltaTime) ;
    }
}
