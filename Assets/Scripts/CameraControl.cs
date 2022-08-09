using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float timeToRotate;
    private bool rotating;

    public void RotateRight()
    {
        if (rotating) return;
        StartCoroutine(Rotate(90f));
        rotating = true;

    }
    
    public void RotateLeft()
    {
        if (rotating) return;
        StartCoroutine(Rotate(-90f));
        rotating = true;
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
        rotating = false;

    }
    
}
