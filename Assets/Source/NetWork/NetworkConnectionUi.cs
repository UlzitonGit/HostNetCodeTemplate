using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkConnectionUi : MonoBehaviour
{
    [SerializeField] private GameObject _networkConnectionUIPrefab;
    [SerializeField] private Button _hostButton;
    [SerializeField] private Button _clientButton;

    private void Awake()
    {
        _hostButton.onClick.AddListener (() =>
        {
            NetworkManager.Singleton.StartHost();
            HideConnectionUI();
        });
        _clientButton.onClick.AddListener (() =>
        {
            NetworkManager.Singleton.StartClient();
            HideConnectionUI();
        });
    }

    private void HideConnectionUI()
    {
        _networkConnectionUIPrefab.SetActive(false);
    }
}
