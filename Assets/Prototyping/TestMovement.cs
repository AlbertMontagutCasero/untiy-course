using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + Vector3.forward * 1 * Time.deltaTime;
    }
}
