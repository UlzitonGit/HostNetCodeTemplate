using Unity.Netcode;
using UnityEngine;

public class PlayerSpawnMananger : NetworkBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    
    public override void OnNetworkSpawn()
    {
        if (IsHost)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
            
       
            foreach (var clientId in NetworkManager.Singleton.ConnectedClientsIds)
            {
                SpawnPlayer(clientId);
            }
        }
    }

    private void SpawnPlayer(ulong clientId)
    {
        if (!IsHost) return;
        
        GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        
        NetworkObject networkObject = playerInstance.GetComponent<NetworkObject>();
        networkObject.SpawnAsPlayerObject(clientId);
        
        Debug.Log($"Spawned player for client {clientId} at position {spawnPoint}");
    }

    public override void OnNetworkDespawn()
    {
        if (IsHost)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayer;
        }
    }
}