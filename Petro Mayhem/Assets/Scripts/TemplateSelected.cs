using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateSelected : MonoBehaviour
{
    [SerializeField] private TemplateSelectedVisual _templateSelectedVisual;
    [SerializeField] Transform _selectedTemplate;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject otherObject = GameObject.Find("NameOfOtherObject"); // Replace with the actual name or tag
        _templateSelectedVisual = GetComponent<TemplateSelectedVisual>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedTemplate(Transform template)
    {
        _selectedTemplate = template;
    }
}
