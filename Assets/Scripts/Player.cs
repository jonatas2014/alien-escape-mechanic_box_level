
using System.Collections;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerInputActions _input;
    private Vector2 _moveInput;
    private float _cameraRotateInput;
    private CameraControl _camera;
    private bool rotating = false;
    [SerializeField] private float timeToRotate;

    public float Speed;

    public Transform headPoint;

    private Menu _menu;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = new PlayerInputActions();
        _camera = FindObjectOfType<CameraControl>();
        _menu = FindObjectOfType<Menu>();

    }

    private void OnEnable()
    {
        _input.Enable();
        Debug.Log(Physics2D.gravity);
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void FixedUpdate()
    {
        //Debug.Log(_camera.transform.localEulerAngles.z);

        _moveInput = _input.Game.Move.ReadValue<Vector2>();

        //Debug.Log(_moveInput);

        if (!rotating)
        {

            var inputForce = transform.right * (_moveInput.x * 0.2f);
            _rigidbody2D.AddForce(inputForce, ForceMode2D.Impulse);

        }
        
        
        _cameraRotateInput = _input.Game.CameraRoll.ReadValue<float>();
        if (rotating) return;
        switch (_cameraRotateInput)
        {
            case > 0f:
                _camera.RotateRight();
                StartCoroutine(Rotate(90));
                rotating = true;
                break;
            case < 0f:
                _camera.RotateLeft();
                StartCoroutine(Rotate(-90));
                rotating = true;
                break;
        }

    }

    private IEnumerator Rotate(float degrees)
    {
        var time = 0f;
        var currentRotation = transform.rotation;
        var desiredRotation = transform.rotation *= Quaternion.Euler(0, 0, degrees);
        while (time < timeToRotate)
        {
            transform.rotation = Quaternion.Slerp(currentRotation, desiredRotation, time);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = desiredRotation;
        Physics2D.gravity = new Vector2( 9.81f, 9.81f) *-transform.up;
        Debug.Log(Physics2D.gravity);
        rotating = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            if (_menu != null)
            {
                _menu.OpenDefeatPanel();
                Time.timeScale = 0f;
            }
        }
    }

}
