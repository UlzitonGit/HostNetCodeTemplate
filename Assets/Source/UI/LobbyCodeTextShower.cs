using TMPro;
using UnityEngine;

public class LobbyCodeTextShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lobbyCodeText;

    private void Start()
    {
        _lobbyCodeText.text = NetworkLobbyData.LobbyCode;
        NetworkLobbyData.DebugLobbyCode();
    }
}
