using System;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGameLobby : MonoBehaviour
{
    private float _heartbeatTimer = 15;
    private Lobby _hostLobby;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("SignedIn" + AuthenticationService.Instance.PlayerId);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    //private void Update()
   //{
        //HandleLobbyHeartbeat();
   // }

    private async void HandleLobbyHeartbeat()
    {
        if (_hostLobby != null)
        {
            _heartbeatTimer -= Time.deltaTime;
            if (_heartbeatTimer <= 0)
            {
                float heartbeatTimer = 15;
                await LobbyService.Instance.SendHeartbeatPingAsync(_hostLobby.Id);
            }
        }
    }

    public async void CreateLobby()
    {
        try //19.00
        {
            string lobbyName = "lobby";
            int maxPlayers = 2;
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = true,
            };
            
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);
            Debug.Log(lobby.LobbyCode);
            _hostLobby = lobby;
            NetworkLobbyData.LobbyCode = _hostLobby.LobbyCode;
            SceneLoader.LoadNetwork(SceneLoader.Scene.TestGameLevel);
        }
        catch (LobbyServiceException e)
        {
            Console.WriteLine(e);
        }
    }
    
    private async void ListLobbies()
    {
        try
        {
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync();
        }
        catch (LobbyServiceException e)
        {
            Console.WriteLine(e);
        }
    }

    public async void JoinLobbyByCode(string lobbyCode)
    {
        try
        {
            await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
        }
        catch (LobbyServiceException e)
        {
            Console.WriteLine(e);
        }
    }
    
}
