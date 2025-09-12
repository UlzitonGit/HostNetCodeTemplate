using UnityEngine;

public static class NetworkLobbyData
{
    public static string LobbyCode { get; set; }

    public static void DebugLobbyCode()
    {
        Debug.Log(LobbyCode);
    }
}
