using UnityEngine;

public class dayNightCycle : MonoBehaviour
{
    [SerializeField] private Material skyboxMaterial;
    [SerializeField] private float cycleDuration = 24f;
    [SerializeField] private int rotationDecimalPlaces = 1;

    private float currentRotation = 0f;
    private float cycleStartTime;
    private float cycleProgress;

    private bool sunCycle = true;
    private bool moonCycle = false; 

    private float thickness;

    private void Start()
    {
        cycleStartTime = Time.time;
    }

    private void Update()
    {
        cycleProgress = (Time.time - cycleStartTime) / cycleDuration;
        currentRotation = Mathf.Lerp(-10f, 200f, cycleProgress);

        // Round off the rotation value to a certain number of decimal places
        currentRotation = Mathf.Round(currentRotation * Mathf.Pow(10, rotationDecimalPlaces)) / Mathf.Pow(10, rotationDecimalPlaces);

        if (currentRotation >= 200f)
        {
            if (moonCycle) {
                moonCycle = false;
                sunCycle = true;
            }

            else if (sunCycle) {
                sunCycle = false;
                moonCycle = true;
            }

            currentRotation = -10f;
            cycleStartTime = Time.time;
        }

        transform.rotation = Quaternion.Euler(currentRotation, -26.8f, 0f);

        if (sunCycle) {
            thickness = Mathf.Lerp(0.5f, 1.9f, cycleProgress);
        }

        else if (moonCycle) {
            thickness = Mathf.Lerp(0f, 0.15f, cycleProgress*30);
        }

        skyboxMaterial.SetFloat("_AtmosphereThickness", thickness);
    }
}