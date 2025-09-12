using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionButtons : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _joinCodeTextField;
    [SerializeField] private Button _createLobbyButton;
    [SerializeField] private Button _joinLobbyButton;
    [SerializeField] private TestGameLobby _testGameLobby;
    void Awake()
    {
        _createLobbyButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            _testGameLobby.CreateLobby();
        });
        _joinLobbyButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            _testGameLobby.JoinLobbyByCode(_joinCodeTextField.text);
        });
    }
    
}
