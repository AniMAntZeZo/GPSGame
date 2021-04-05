using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerehodOnMain : MonoBehaviour
{
    public void ScenMenegering()
    {
        SceneManager.LoadScene("mainScen", LoadSceneMode.Single);
    }
}
