using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    const string Key = "bZ6c1Bj15QciY0IipGyKpyDwwAJl1D4a";

    public Renderer maprender;
    Vector2 PlayerPosition = new Vector2(42.3627f, -71.05686f);

    int _zoom = 17;
    string _maptype = "map";
    string _url;

    public TestLocationServis gpslocation;
    public Text lanti;
    public Text longi;

    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        gpslocation = GetComponent<TestLocationServis>();

        Debug.Log(gpslocation.latitudeValue);
        Debug.Log(gpslocation.longitudeValue);

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            StartLoadMap(PlayerPosition);
        }
           
    }



    private void StartLoadMap(Vector2 playerPosition)
    {

        

       // Debug.Log(_url);



        StartCoroutine(LoadImage());
    }

    void urlseach(Vector2 playerPosition)
    {
        playerPosition = new Vector2(gpslocation.latitudeValue, gpslocation.longitudeValue);
        _url = "http://open.mapquestapi.com/staticmap/v4/getmap?key=" + Key + "&size=1280,1280&zoom=" + _zoom + "&type=" + _maptype + "&center=" + playerPosition.x + "," + playerPosition.y;

        lanti.text = gpslocation.latitudeValue.ToString();
        longi.text = gpslocation.longitudeValue.ToString();
    }

    private IEnumerator LoadImage()
    {
        while (true)
        {
            urlseach(PlayerPosition);

#pragma warning disable CS0618 // Тип или член устарел
            var www = new WWW(_url);
#pragma warning restore CS0618 // Тип или член устарел
            while (!www.isDone)
            {
                // Debug.Log("progress = " + www.progress);
                yield return null;
            }

            if (www.error == null)
            {
                Debug.Log("Updating map 100 %");
                Debug.Log("Map Ready!");
                yield return new WaitForSeconds(0.5f);
                maprender.material.mainTexture = null;
                Texture2D tmp;
                tmp = new Texture2D(1280, 1280, TextureFormat.RGB24, false);
                maprender.material.mainTexture = tmp;
                www.LoadImageIntoTexture(tmp);
            }
            else
            {
                Debug.Log("Map Error: " + www.error);
                yield return new WaitForSeconds(1);
                maprender.material.mainTexture = null;
            }

            maprender.enabled = true;

            yield return new WaitForSeconds(10f);
        }

    }

}
