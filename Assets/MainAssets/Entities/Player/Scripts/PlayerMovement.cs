using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    private void OnEnable()
    {
        InputHandler.OnJumpButtonClick += Jump;
        InputHandler.OnWaitButtonClick += Jump;
    }

    private void OnDisable()
    {
        InputHandler.OnJumpButtonClick -= Jump;
        InputHandler.OnWaitButtonClick -= Jump;
    }

    private void Jump()
    {
        _rb.isKinematic = false;
        _rb.simulated = true;

        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce);
    }
}
