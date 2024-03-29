﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Pipe")))
            Destroy(other.gameObject);
    }
}