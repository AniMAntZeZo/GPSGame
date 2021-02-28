using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLocationServis : MonoBehaviour
{
    public float latitudeValue;
    public float longitudeValue;
    public Text LantitudText;
    public Text LongitudText;

    private void Start()
    {
        StartCoroutine(GPSLog());
    }

    IEnumerator GPSLog()
    {
        Debug.Log("2");

        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;
        Debug.Log("3");
        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        Debug.Log("4");

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            InvokeRepeating("UpdateGPSData", 0.5f, 1f);
        }
    }

    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            latitudeValue = Input.location.lastData.latitude;
            longitudeValue = Input.location.lastData.longitude;
            LantitudText.text = Input.location.lastData.latitude.ToString();
            LongitudText.text = Input.location.lastData.longitude.ToString();
        }
        else
        {
            
        }
    }

}
