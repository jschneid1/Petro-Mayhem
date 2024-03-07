using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelectedVisual : MonoBehaviour
{
     [SerializeField] private Transform _vehicle;

    [SerializeField] private MeshRenderer _meshRenderer;
    // Start is called before the first frame update

    private void Awake()
    {
        //_meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    void Start()
    {
        VehicleActionSystem.Instance.OnSelectedVehicleChanged += VehicleActionSystem_OnSelectedVehicleChanged;

        UpdateVisual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VehicleActionSystem_OnSelectedVehicleChanged(object sender, EventArgs empty) 
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (VehicleActionSystem.Instance.GetSelectedVehicle() == _vehicle)
        {
            _meshRenderer.enabled = true;
        }

        else
        {
            _meshRenderer.enabled = false;
        }
    }
}
