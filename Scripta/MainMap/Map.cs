using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    const string Key = "bZ6c1Bj15QciY0IipGyKpyDwwAJl1D4a";

    public GameObject map;
    public GameObject Player;
    public Renderer maprender;
    Vector2 PlayerPosition = new Vector2(0f, 0f);
    Vector2 PlayerPositionSmesh;

    int _zoom = 17;
    string _maptype = "map";
    string _url;

    public TestLocationServis gpslocation;
    public Text lanti;
    public Text longi;

    Vector3 smesh;
    public float speed;

    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        gpslocation = GetComponent<TestLocationServis>();
        PlayerPosition = new Vector2(gpslocation.latitudeValue, gpslocation.longitudeValue);
        PlayerPositionSmesh = PlayerPosition;

      //  Debug.Log(gpslocation.latitudeValue);
      //  Debug.Log(gpslocation.longitudeValue);

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
        PlayerPosition = new Vector2(gpslocation.latitudeValue, gpslocation.longitudeValue);
        StartCoroutine(LoadImage());
    }


    void urlseach(Vector2 playerPosition)
    {
        _url = "http://open.mapquestapi.com/staticmap/v4/getmap?key=" + Key + "&size=2560,2560&zoom=" + _zoom + "&type=" + _maptype + "&center=" + playerPosition.x + "," + playerPosition.y;

       // lanti.text = playerPosition.x.ToString();
       // longi.text = playerPosition.y.ToString();

        Debug.Log(_url);
    }


    private IEnumerator LoadImage()
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
                tmp = new Texture2D(2560, 2560, TextureFormat.RGB24, false);
                maprender.material.mainTexture = tmp;
                www.LoadImageIntoTexture(tmp);
                Debug.Log(PlayerPosition);
                Player.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("Map Error: " + www.error);
                yield return new WaitForSeconds(1);
                maprender.material.mainTexture = null;
            }

            maprender.enabled = true;

    }

    private void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.W)) PlayerPositionSmesh.y += 0.00001f;
         if (Input.GetKeyDown(KeyCode.S)) PlayerPositionSmesh.y -= 0.00001f;
         if (Input.GetKeyDown(KeyCode.D)) PlayerPositionSmesh.x += 0.00001f;
         if (Input.GetKeyDown(KeyCode.A)) PlayerPositionSmesh.x -= 0.00001f;

         if (PlayerPosition.x != PlayerPositionSmesh.x || PlayerPosition.y != PlayerPositionSmesh.y)
         {
             smesh.x = (PlayerPositionSmesh.x - PlayerPosition.x) * speed;
             smesh.z = (PlayerPositionSmesh.y - PlayerPosition.y) * speed;

             Player.transform.position += smesh;
             PlayerPosition.x = PlayerPositionSmesh.x;
             PlayerPosition.y = PlayerPositionSmesh.y;
         }*/

        if (PlayerPosition.x != gpslocation.latitudeValue || PlayerPosition.y != gpslocation.longitudeValue)
        {
            smesh.x = (gpslocation.latitudeValue - PlayerPosition.x) * speed;
            smesh.z = (gpslocation.longitudeValue - PlayerPosition.y) * speed;

            if (smesh.x < 6f || smesh.z < 6f)
            {
                Player.transform.position += smesh;
                PlayerPosition.x = gpslocation.latitudeValue;
                PlayerPosition.y = gpslocation.longitudeValue;
            }
            else
            {
                StartLoadMap(PlayerPosition);
            }

        }
    }

    private void OnTriggerEnter(Collider trig)
    {
        StartLoadMap(PlayerPosition);
    }

}
