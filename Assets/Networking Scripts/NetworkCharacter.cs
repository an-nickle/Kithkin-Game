using UnityEngine;
using Photon;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour
{
    // The correct player position and rotation to lerp to.
    // These are not used if this computer owns the GameObject (wasn't created on another computer)
    private Vector3 correctPlayerPos;
    private Quaternion correctPlayerRot;

    void Update()
    {
        // photonView.isMine represents whether the GameObject was created on this computer,
        // whether or not we created this GameObject
        if (!photonView.isMine)
        {
            // Lerp to the correct position. Lerping makes the transition much smoother.
            // If we have teleporting, this will become an issue.
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
        }
        else
        {
            // Nothing here. Position is handled in a different component
        }
    }

    // Whenever it's time to send/recieve data (handled in the same function
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Sending Data (meaning we own this object)
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }

        // Receiving Data (meaning we don't own this object)
        else
        {
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
