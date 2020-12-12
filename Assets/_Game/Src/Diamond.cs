using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] float animationSpeed = 0.5f;
    [SerializeField] float movementInterval = 0.3f;

    float originalY;

    private void Awake()
    {
        originalY = transform.position.y;
    }

    private void Update()
    {
        float y = Mathf.PingPong(Time.time * animationSpeed, movementInterval);

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            originalY + y,
            transform.localPosition.z
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) GameManager.Collect(this);
    }

}
