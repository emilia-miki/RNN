using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LaunchScript : MonoBehaviour
{
    public TMP_Dropdown track, cars, simtest;
    private string trackNumber;
    private int carsInt;
    private bool simulation = false;

    private void InitializeScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Track" + trackNumber));

        // spawn cars
        int iter = carsInt;
        foreach (GameObject car in GameObject.FindGameObjectsWithTag("car"))
        {
            if (iter <= 0)
            {
                car.SetActive(false);
            }
            else
            {
                car.SetActive(true);
            }

            iter--;
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Track" +  trackNumber);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        InitializeScene();
    }

    public void OnClick()
    {
        Object.DontDestroyOnLoad(FindObjectOfType(typeof(LaunchScript)));

        // check for simulation
        if (simtest.options[simtest.value].text == "Simulation")
        {
            simulation = true;
        }

        // get cars
        carsInt = int.Parse(cars.options[cars.value].text);

        // get track
        trackNumber = track.options[track.value].text;

        // load track
        StartCoroutine(LoadYourAsyncScene());
    }
}
