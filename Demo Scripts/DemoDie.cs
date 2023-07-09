using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDie : MonoBehaviour
{
    public float destroyObjectStartTime = 5;
    public float destroyCounter;

    // Start is called before the first frame update
    void Start()
    {
        destroyCounter = destroyObjectStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        destroyCounter -= Time.deltaTime;
        if (destroyCounter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
