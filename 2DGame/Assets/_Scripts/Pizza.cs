using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pizza : MonoBehaviour
{
    private Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        transform.position = spawn;
    }
}
