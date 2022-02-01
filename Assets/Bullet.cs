using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
  //  public NetworkVariable<int> launcherNetworkId = new NetworkVariable<int>(NetworkVariableReadPermission.Everyone, 5);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player(Clone)")
        {
            Debug.Log("Bullet hit PLAYERS");
            other.gameObject.GetComponent<Player>().ResetPlayer();
            //NetworkObject networkObject = GetComponent<NetworkObject>();
           // other.gameObject.GetComponent<Player>().ResetPlayer(launcherNetworkId.Value);
        }
    }
}