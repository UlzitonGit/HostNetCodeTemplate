using UnityEngine;
using Unity.Netcode;
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private PlayerAnimator _animatorController;
    
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
  
    #region Movement
    public void BasicMovement(Vector3 _direction, Vector2 _input)
    {
        Vector3 moveDirection = new Vector3(_direction.x * _speed, _rb.linearVelocity.y, _direction.z * _speed);
        _rb.linearVelocity = moveDirection;
        if (Physics.Raycast(Camera.allCameras[0].ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Vector3 diff = hit.point - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * _rotationSpeed);
            _direction = transform.InverseTransformDirection(_direction);

        }
        _animatorController.PlayMoveAnimations(_direction, _input);
    }
   
    #endregion
}
