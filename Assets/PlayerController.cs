using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 8f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 4.5f;
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 12f;

    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float positionYawFactor = 4f;

    [Header("Control-throw based")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = -25f;

    float xThrow;
    float yThrow;
    bool controlsEnabled = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnPlayerDeath()
    {
        controlsEnabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitch = positionPitchFactor * transform.localPosition.y + yThrow * controlPitchFactor;

        float yaw = positionYawFactor * transform.localPosition.x + xThrow * controlYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetFrame = xThrow * controlSpeed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffsetFrame, xRange * -1, xRange);

        transform.localPosition = new Vector3(rawNewXPos, transform.localPosition.y, transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetFrame = yThrow * controlSpeed * Time.deltaTime;
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffsetFrame, yRange * -1, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, rawNewYPos, transform.localPosition.z);
    }
}
