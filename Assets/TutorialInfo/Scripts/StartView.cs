using UnityEngine;

public class StartView : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
      Quaternion deviceRotation = Input.gyro.attitude;
      deviceRotation = Quaternion.Euler(90f, 0f, 0f) *
                       new Quaternion(-deviceRotation.x, -deviceRotation.y, deviceRotation.z, deviceRotation.w);
      transform.localRotation = deviceRotation;  
    }
}
