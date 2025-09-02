using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void PlayMoveAnimations(Vector3 _direction, Vector2 _input)
    {
        _animator.SetFloat("Input", _input.magnitude, 0.1f, Time.deltaTime);
        _animator.SetFloat("Hor", _direction.x, 0.2f, Time.deltaTime);
        _animator.SetFloat("Ver", _direction.z, 0.2f, Time.deltaTime);
    }
}
