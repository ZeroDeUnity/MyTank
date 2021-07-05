using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MapDataMananger : MonoBehaviour
{
    List<ArrayList> MapDataList = new List<ArrayList>();

    private void Awake()
    {
        ExcelTool.CreateItemArrayWithExcel("MapConfigData", 1);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
