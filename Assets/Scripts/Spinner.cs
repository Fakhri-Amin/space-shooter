using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float minSpin = 15f;
    public float maxSpin = 120f;
    private float speedOfSpin;

    // Start is called before the first frame update
    void Start()
    {
        speedOfSpin = Random.Range(minSpin, maxSpin);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speedOfSpin * Time.deltaTime);
    }
}
