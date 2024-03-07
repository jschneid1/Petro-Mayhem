using System; //needed when using events
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleActionSystem : MonoBehaviour
{
    public static VehicleActionSystem Instance { get; private set; }

    public event EventHandler OnSelectedVehicleChanged;

    [SerializeField] private Transform _selectedVehicle;
    [SerializeField] private LayerMask _vehicleLayermask;
    private bool _templateSelected = false;

    private void Awake()
    {
        if (Instance!=null)
        {
            Debug.LogError("There is more than one VehicleActionSystem " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _templateSelected == false) 
        {
            HandleVehicleSelection();
        }        
    }

    private void HandleVehicleSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _vehicleLayermask))
        {
            if (raycastHit.transform.TryGetComponent<Transform>(out Transform vehicle))
            {
                SetSelectedVehicle(vehicle);
            }
        }
    }

    private void SetSelectedVehicle(Transform vehicle)
    {
        _selectedVehicle = vehicle;

        OnSelectedVehicleChanged?.Invoke(this, EventArgs.Empty);
    }

    public Transform GetSelectedVehicle()
    {
        return _selectedVehicle;
    }

    public void TemplateSelected()
    {
        _templateSelected = true;
    }
}
