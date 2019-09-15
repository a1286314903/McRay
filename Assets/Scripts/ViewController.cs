using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float speed = 1;
    public float mouseSpeed = 600;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouseSW = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed , Space.World);
        transform.Translate(new Vector3(0, -mouseSW, 0) * Time.deltaTime * mouseSpeed, Space.World);

    }
}
