using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DropdownScript : MonoBehaviour
{
    public float offset = 0.0f;
    public float speed = 100.0f;
    private float startTime;
    public Dropdown tideDropdown;
    TidalConstituent[] constituents;

    // Start is called before the first frame update
    void Start()
    {       
        startTime = Time.time;
        constituents = new TidalConstituent[0];
    }

    public void OnOptionChange(int option)
    {
        switch (option)
        {
            case 1: //Diurnal tides
                constituents = new TidalConstituent[]
                {
                    new TidalConstituent("M2", 0.17f, 332.8f, 28.984104f), // Principal lunar semidiurnal constituent
                    new TidalConstituent("S2", 0.057f, 337.6f, 30.0f), // Principal solar semidiurnal constituent
                    new TidalConstituent("N2", 0.04f, 329.6f, 28.43973f), // Larger lunar elliptic semidiurnal constituent
                    new TidalConstituent("K1", 0.148f, 293.4f, 15.041069f), // Lunar diurnal constituent
                    new TidalConstituent("M4", 0.002f, 126.9f, 57.96821f), // Shallow water overtides of principal lunar constituent
                    new TidalConstituent("O1", 0.136f, 293.2f, 13.943035f), // Lunar diurnal constituent
                    new TidalConstituent("M6", 0.002f, 353.8f, 86.95232f), // Shallow water overtides of principal lunar constituent
                    new TidalConstituent("MK3", 0.004f, 102.0f, 44.025173f), // Shallow water terdiurnal
                    new TidalConstituent("S4", 0.002f, 259.3f, 60.0f), // Shallow water overtides of principal solar constituent
                    new TidalConstituent("MN4", 0.002f, 140.0f, 57.423832f), // Shallow water quarter diurnal constituent
                    new TidalConstituent("NU2", 0.007f, 330.7f, 28.512583f), // Larger lunar evectional constituent
                    new TidalConstituent("S6", 0.001f, 309.7f, 90.0f), // Shallow water overtides of principal solar constituent
                    new TidalConstituent("MU2", 0.007f, 286.8f, 27.968208f), // Variational constituent
                    new TidalConstituent("2N2", 0.007f, 312.2f, 27.895355f), // Lunar elliptical semidiurnal second-order constituent
                    new TidalConstituent("OO1", 0.005f, 302.8f, 16.139101f), // Lunar diurnal
                    new TidalConstituent("LAM2", 0.002f, 316.6f, 29.455626f), // Smaller lunar evectional constituent
                    new TidalConstituent("S1", 0.027f, 16.6f, 15.0f), // Solar diurnal constituent
                    new TidalConstituent("M1", 0.005f, 315.5f, 14.496694f), // Smaller lunar elliptic diurnal constituent
                    new TidalConstituent("J1", 0.006f, 323.1f, 15.5854435f), // Smaller lunar elliptic diurnal constituent
                    new TidalConstituent("MM", 0.0f, 0.0f, 0.5443747f), // Lunar monthly constituent
                    new TidalConstituent("SSA", 0.03f, 66.2f, 0.0821373f), // Solar semiannual constituent
                    new TidalConstituent("SA", 0.075f, 167.6f, 0.0410686f), // Solar annual constituent
                    new TidalConstituent("MSF", 0.0f, 0.0f, 1.0158958f), // Lunisolar synodic fortnightly constituent
                    new TidalConstituent("MF", 0.0f, 0.0f, 1.0980331f), // Lunisolar fortnightly constituent
                    new TidalConstituent("RHO", 0.007f, 279.0f, 13.471515f), // Larger lunar evectional diurnal constituent
                    new TidalConstituent("Q1", 0.028f, 285.0f, 13.398661f), // Larger lunar elliptic diurnal constituent
                    new TidalConstituent("T2", 0.001f, 105.5f, 29.958933f), // Larger solar elliptic constituent
                    new TidalConstituent("R2", 0.009f, 6.2f, 30.041067f), // Smaller solar elliptic constituent
                    new TidalConstituent("2Q1", 0.003f, 289.8f, 12.854286f), // Larger elliptic diurnal
                    new TidalConstituent("P1", 0.038f, 284.7f, 14.958931f), // Solar diurnal constituent
                    new TidalConstituent("2SM2", 0.003f, 321.1f, 31.015896f), // Shallow water semidiurnal constituent
                    new TidalConstituent("M3", 0.004f, 71.8f, 43.47616f), // Lunar terdiurnal constituent
                    new TidalConstituent("L2", 0.003f, 337.2f, 29.528479f), // Smaller lunar elliptic semidiurnal constituent
                    new TidalConstituent("2MK3", 0.009f, 102.9f, 42.92714f), // Shallow water terdiurnal constituent
                    new TidalConstituent("K2", 0.017f, 338.3f, 30.082138f), // Lunisolar semidiurnal constituent
                    new TidalConstituent("M8", 0.001f, 180.9f, 115.93642f), // Shallow water eighth diurnal constituent
                    new TidalConstituent("MS4", 0.003f, 82.2f, 58.984104f) // Shallow water quarter diurnal constituent
                };
                break;

            case 2: //Semidiurnal tides
                constituents = new TidalConstituent[]
                {
                    new TidalConstituent("M2", 2.0f, 225.2f, 28.984104f),
                    new TidalConstituent("S2", 0.4f, 255.1f, 30.0f),
                    new TidalConstituent("N2", 0.4f, 215.1f, 28.43973f),
                    new TidalConstituent("K1", 0.27f, 112.3f, 15.041069f),
                    new TidalConstituent("M4", 0.05f, 334.7f, 57.96821f),
                    new TidalConstituent("O1", 0.21f, 101.4f, 13.943035f),
                    new TidalConstituent("M6", 0.06f, 340.4f, 86.95232f),
                    new TidalConstituent("MK3", 0.0f, 0.0f, 44.025173f),
                    new TidalConstituent("S4", 0.03f, 69.0f, 60.0f),
                    new TidalConstituent("MN4", 0.0f, 0.0f, 57.423832f),
                    new TidalConstituent("NU2", 0.08f, 216.4f, 28.512583f),
                    new TidalConstituent("S6", 0.02f, 143.7f, 90.0f),
                    new TidalConstituent("MU2", 0.05f, 195.3f, 27.968208f),
                    new TidalConstituent("2N2", 0.05f, 205.0f, 27.895355f),
                    new TidalConstituent("OO1", 0.01f, 123.9f, 16.139101f),
                    new TidalConstituent("LAM2", 0.01f, 239.1f, 29.455626f),
                    new TidalConstituent("S1", 0.0f, 0.0f, 15.0f),
                    new TidalConstituent("M1", 0.01f, 107.0f, 14.496694f),
                    new TidalConstituent("J1", 0.02f, 117.9f, 15.5854435f),
                    new TidalConstituent("MM", 0.0f, 0.0f, 0.5443747f),
                    new TidalConstituent("SSA", 0.09f, 42.4f, 0.0821373f),
                    new TidalConstituent("SA", 0.22f, 128.8f, 0.0410686f),
                    new TidalConstituent("MSF", 0.0f, 0.0f, 1.0158958f),
                    new TidalConstituent("MF", 0.0f, 0.0f, 1.0980331f),
                    new TidalConstituent("RHO", 0.01f, 96.7f, 13.471515f),
                    new TidalConstituent("Q1", 0.04f, 95.9f, 13.398661f),
                    new TidalConstituent("T2", 0.02f, 253.9f, 29.958933f),
                    new TidalConstituent("R2", 0.0f, 256.3f, 30.041067f),
                    new TidalConstituent("2Q1", 0.0f, 90.4f, 12.854286f),
                    new TidalConstituent("P1", 0.09f, 111.5f, 14.958931f),
                    new TidalConstituent("2SM2", 0.0f, 0.0f, 31.015896f),
                    new TidalConstituent("M3", 0.0f, 0.0f, 43.47616f),
                    new TidalConstituent("L2", 0.06f, 235.4f, 29.528479f),
                    new TidalConstituent("2MK3", 0.0f, 0.0f, 42.92714f),
                    new TidalConstituent("K2", 0.11f, 257.5f, 30.082138f),
                    new TidalConstituent("M8", 0.01f, 56.3f, 115.93642f),
                    new TidalConstituent("MS4", 0.0f, 0.0f, 58.984104f)
                };
                break;
            case 3: //Mixed semidiurnal tides
                constituents = new TidalConstituent[]
                {
                    new TidalConstituent("M2", 0.542f, 271.4f, 28.984104f),
                    new TidalConstituent("S2", 0.225f, 260.4f, 30.0f),
                    new TidalConstituent("N2", 0.126f, 255.5f, 28.43973f),
                    new TidalConstituent("K1", 0.337f, 88.0f, 15.041069f),
                    new TidalConstituent("M4", 0.003f, 151.7f, 57.96821f),
                    new TidalConstituent("O1", 0.214f, 81.0f, 13.943035f),
                    new TidalConstituent("M6", 0.004f, 86.5f, 86.95232f),
                    new TidalConstituent("MK3", 0.002f, 223.2f, 44.025173f),
                    new TidalConstituent("S4", 0.001f, 110.1f, 60.0f),
                    new TidalConstituent("MN4", 0.002f, 113.7f, 57.423832f),
                    new TidalConstituent("NU2", 0.025f, 261.6f, 28.512583f),
                    new TidalConstituent("S6", 0.001f, 68.1f, 90.0f),
                    new TidalConstituent("MU2", 0.015f, 228.2f, 27.968208f),
                    new TidalConstituent("2N2", 0.016f, 232.2f, 27.895355f),
                    new TidalConstituent("OO1", 0.011f, 112.7f, 16.139101f),
                    new TidalConstituent("LAM2", 0.003f, 258.3f, 29.455626f),
                    new TidalConstituent("S1", 0.005f, 209.0f, 15.0f),
                    new TidalConstituent("M1", 0.013f, 109.1f, 14.496694f),
                    new TidalConstituent("J1", 0.019f, 96.1f, 15.5854435f),
                    new TidalConstituent("MM", 0.0f, 0.0f, 0.5443747f),
                    new TidalConstituent("SSA", 0.0f, 0.0f, 0.0821373f),
                    new TidalConstituent("SA", 0.076f, 180.1f, 0.0410686f),
                    new TidalConstituent("MSF", 0.0f, 0.0f, 1.0158958f),
                    new TidalConstituent("MF", 0.0f, 0.0f, 1.0980331f),
                    new TidalConstituent("RHO", 0.008f, 77.1f, 13.471515f),
                    new TidalConstituent("Q1", 0.039f, 78.2f, 13.398661f),
                    new TidalConstituent("T2", 0.014f, 248.4f, 29.958933f),
                    new TidalConstituent("R2", 0.002f, 275.2f, 30.041067f),
                    new TidalConstituent("2Q1", 0.005f, 83.2f, 12.854286f),
                    new TidalConstituent("P1", 0.106f, 86.2f, 14.958931f),
                    new TidalConstituent("2SM2", 0.002f, 64.1f, 31.015896f),
                    new TidalConstituent("M3", 0.003f, 8.7f, 43.47616f),
                    new TidalConstituent("L2", 0.012f, 248.2f, 29.528479f),
                    new TidalConstituent("2MK3", 0.003f, 209.3f, 42.92714f),
                    new TidalConstituent("K2", 0.066f, 253.8f, 30.082138f),
                    new TidalConstituent("M8", 0.0f, 0.0f, 115.93642f),
                    new TidalConstituent("MS4", 0.002f, 91.2f, 58.984104f)
                };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float unscaledTime = Time.time - startTime;
        float scaledTime = unscaledTime * speed / 3600.0f;
        float height = offset;

        if (constituents.Length != 0)
        {
            foreach (TidalConstituent constituent in constituents)
            {
                float period = (360 / constituent.speed); //calculating the period for each one
                float omega = 2 * Mathf.PI / period;
                float tidalHeight = constituent.amplitude * Mathf.Sin(omega * scaledTime + constituent.phase)/10;
                height += tidalHeight;
            }
        }
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}


public class TidalConstituent
{
    public string name;
    public float amplitude;
    public float phase;
    public float speed;

    public TidalConstituent(string name, float amplitude, float phase, float speed)
    {
        this.name = name;
        this.amplitude = amplitude;
        this.phase = phase;
        this.speed = speed;
    }
}
