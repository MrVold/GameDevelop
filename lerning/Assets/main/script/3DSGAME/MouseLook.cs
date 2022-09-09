using UnityEngine;

[AddComponentMenu("Control Script/Mouse Controll")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY =  2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float _mouseSensitivityHor = 9.0f;
    public float _mouseSensitivityVer = 9.0f;

    public float _minVert = -45.0f;
    public float _maxVert = 45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _mouseSensitivityHor, 0);
        }
        else if(axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _mouseSensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _mouseSensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

            float delta = Input.GetAxis("Mouse X") * _mouseSensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
