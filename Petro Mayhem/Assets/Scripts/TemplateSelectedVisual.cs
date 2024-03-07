using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateSelectedVisual : MonoBehaviour
{
    //[SerializeField] private VehicleActionSystem _vehicleActionSystem;

    [SerializeField] private Transform _selectedTemplate;

    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private LayerMask _templateLayermask;

    private bool _templateIsSelected = false;
    // Start is called before the first frame update

    private void Awake()
    {
        //_meshRenderer = GetComponentInChildren<MeshRenderer>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleTemplateSelection();
            UpdateVisual();
        }
        
    }

    /*private void OnSelectedTemplateChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }*/

    private void HandleTemplateSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _templateLayermask))
        {
            if (raycastHit.transform.TryGetComponent<Transform>(out Transform template))
            {
                SetSelectedTemplate(template);
                _templateIsSelected = true;
                TemplateIsSelected();
            }
        }
    }

    private void SetSelectedTemplate(Transform template)
    {
        _selectedTemplate = template;
        Debug.Log("Selected template is: " +  template);

        //OnSelectedVehicleChanged?.Invoke(this, EventArgs.Empty);
    }

    public Transform GetSelectedTemplate()
    {
        return _selectedTemplate;
    }

    private void UpdateVisual()
    {
        //if (VehicleActionSystem.Instance.GetSelectedVehicle() == _vehicle)
        if(_selectedTemplate != null)
        {
            _meshRenderer.enabled = true;
        }

        else
        {
            _meshRenderer.enabled = false;
        }
    }

    private void TemplateIsSelected()
    {
        // Assuming the script you want to access is attached to another GameObject
        GameObject otherObject = GameObject.Find("VehicleActionSystem");

        if (otherObject != null)
        {
            // Access the script component on the other GameObject
            VehicleActionSystem anotherScript = otherObject.GetComponent<VehicleActionSystem>();

            if (anotherScript != null)
            {
                // Now you can use methods or variables from AnotherScript
                anotherScript.TemplateSelected();
            }
            else
            {
                Debug.LogWarning("AnotherScript component not found on the other GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("Could not find the GameObject with the specified name.");
        }
    }
}
