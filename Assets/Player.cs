using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xRange = 4f;
    [Tooltip("In ms^-1")][SerializeField] float yRange = 2f;
    [Tooltip("In ms^-1")][SerializeField] float speed = 12f;

    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float positionYawFactor = 4f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlYawFactor = 10f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
        float xOffsetFrame = xThrow * speed * Time.deltaTime;
        float rawNewXPos = Mathf.Clamp(transform.localPosition.x + xOffsetFrame, xRange * -1, xRange);

        transform.localPosition = new Vector3(rawNewXPos, transform.localPosition.y, transform.localPosition.z);

         yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetFrame = yThrow * speed * Time.deltaTime;
        float rawNewYPos = Mathf.Clamp(transform.localPosition.y + yOffsetFrame, yRange * -1, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, rawNewYPos, transform.localPosition.z);
    }
}
