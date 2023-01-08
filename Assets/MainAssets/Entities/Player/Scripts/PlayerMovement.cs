using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Button _jumpButton;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    private void OnEnable()
    {
        _jumpButton.onClick.AddListener(Jump);
    }

    private void OnDisable()
    {
        _jumpButton.onClick.RemoveListener(Jump);
    }

    private void Jump()
    {
        _rb.isKinematic = false;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _jumpForce);
    }
}
