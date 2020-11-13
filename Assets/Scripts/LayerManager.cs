using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] private int sortingOrderBase = 5000;
    [SerializeField] private Renderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y);
    }
}
