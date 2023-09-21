using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMan : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed = 0.1f;
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float boostAmount = 2f;
    [SerializeField]
    private float slowAmount = 0.5f;

    private float boost;

    // Start is called before the first frame update
    void Start()
    {
        boost = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * (moveSpeed + boost);

        if(moveAmount > 0.05f || moveAmount < -0.05f)
        {
            transform.Rotate(0, 0, (moveAmount > 0 ? -steerAmount : steerAmount) * Time.deltaTime);
        }
        transform.Translate(0, moveAmount * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            boost += boostAmount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boost *= slowAmount;
    }
}
