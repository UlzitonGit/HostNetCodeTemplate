using UnityEngine;
using Unity.Netcode;

public class PlayerInputs : NetworkBehaviour
{
    [SerializeField] private PlayerMovement _playerController;
    
    private Vector2 _input;
    private Vector3 _direction;

    void Update()
    {
        if(!IsOwner) return;
        GetInputs();
        _playerController.BasicMovement(_direction, _input);
    }
    private void GetInputs()
    {
        _input =new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _direction = Quaternion.Euler(0, Camera.allCameras[0].transform.eulerAngles.y, 0) * new Vector3(_input.x, 0, _input.y);
    }
}
