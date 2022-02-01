using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    private void Start()
    {
        StartCoroutine(SetupCamera());
    }

    private IEnumerator SetupCamera()
    {
        while (target == null)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length > 0)
            {
                var player = players.First(p => p.GetComponent<NetworkBehaviour>().IsLocalPlayer);
                //var player = players[0];
                if (player != null) target = player.transform;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            var position = target.position;
            transform.position = new Vector3(position.x + offset.x, position.y + offset.y, position.z + offset.z);
        }
    }
}