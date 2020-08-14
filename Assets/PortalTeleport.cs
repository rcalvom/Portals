using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform receiver;

    private bool playerBump = false;
    // Update is called once per frame
    void Update()
    {
        if ( playerBump )
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if ( dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                //rotationDiff += 180;
                //player.Rotate(Vector3.up, rotationDiff);
                Debug.Log("OLA");
                Vector3 positionOffset = Quaternion.Euler(0f,rotationDiff,0f) * portalToPlayer;
                //player.position = receiver.position + positionOffset;
                player.position = new Vector3(100f, 10f, 10f);

                playerBump = false;

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerBump = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerBump = false;
        }
    }
}
