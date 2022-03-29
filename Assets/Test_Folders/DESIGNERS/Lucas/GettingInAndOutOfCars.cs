using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Cameras;
using UnityStandardAssets.Vehicles.Car;

public class GettingInAndOutOfCars : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] AutoCam mCamera = null;
    
    [Header("Human")]
    [SerializeField] private GameObject human = null;

    [SerializeField] private float closeDistance = 10f;
    
    [Space, Header("Car Stuff")]
    [SerializeField] private GameObject car = null;
    [SerializeField] CarUserControl carController = null;
    [SerializeField] private CarController carEngine = null;

    [Header("Input")]
    [SerializeField] private KeyCode enterExitKey = KeyCode.E;

    private bool inCar = false;

    private void Start()
    {
        inCar = car.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((enterExitKey)))
        {
            if(inCar)
                GetOutOfCar();
            
            else if (Vector3.Distance(car.transform.position, human.transform.position) < closeDistance) //if out of car
                GetIntoCar();
        }
    }

    void GetOutOfCar()
    {
        inCar = false;
        
        human.SetActive((true));

        human.transform.position = car.transform.position + car.transform.TransformDirection(Vector3.left);

        mCamera.SetTarget((human.transform));

        carController.enabled = false;

        carEngine.enabled = false;
        
        

    }

    void GetIntoCar()
    {
        inCar = true;
        
        human.SetActive((false));
        
        mCamera.SetTarget(car.transform);

        carController.enabled = true;

        carEngine.enabled = true;
    }
}