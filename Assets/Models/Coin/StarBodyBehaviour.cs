using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarBodyBehaviour : MonoBehaviour
{
    public float smoothTime = 50.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 currentVelocity = Vector3.zero;

    private bool movingToTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, 200 * Time.deltaTime);

        Vector3 destination = movingToTarget ? targetPosition : startPosition;

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref currentVelocity, smoothTime);

        if (Vector3.Distance(transform.position, destination) < 0.1f)
            movingToTarget = !movingToTarget;
    }
}
