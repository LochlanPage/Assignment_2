using UnityEngine;
using System.Collections;
using System;

public class WaveCharacter : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 3.0f;

    [SerializeField]
    float acceleration = 10;

    [SerializeField]
    float minSpeed = 2;

    [SerializeField]
    float waveDuration = 0.5f;

    private float currentTargetSpeed;

    public static bool waving;

    public float speed;

    public event Action onWave;

    private void Awake()
    {
        currentTargetSpeed = minSpeed;
    }

    private void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

        // Movement
        transform.position += transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;

        float moveInput = Input.GetAxisRaw("Vertical");

        // Waving
        if (!waving)
            speed = Mathf.MoveTowards(speed, currentTargetSpeed * moveInput, acceleration * Time.deltaTime);

        if (!waving && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Wave());
        }
    }

    private IEnumerator Wave()
    {
        if (onWave != null)
        {
            onWave();
        }

        waving = true;

        yield return new WaitForSeconds(waveDuration);

        waving = false;
    }
}
