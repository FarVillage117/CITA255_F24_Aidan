using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.Loading;

public class Drag : MonoBehaviour
{
    private const string FILE_DIR = "/Saves/";
    private string FILE_NAME = "<name>.json";
    private string FILE_PATH;
    void Start()
    {
        FILE_NAME = FILE_NAME.Replace("<name>", name);
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        if (File.Exists(FILE_PATH))
        {
            string jsonString = File.ReadAllText(FILE_PATH);
            transform.position = JsonUtility.FromJson<Vector3>(jsonString);
        }
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 position = Input.mousePosition;
        position.z = Camera.main.WorldToScreenPoint(transform.position).z;
        position = Camera.main.ScreenToWorldPoint(position);
        return position;
    }

    private void OnApplicationQuit()
    {
       string fileContent = JsonUtility.ToJson(transform.position, prettyPrint: true);

        if (!Directory.Exists(path: Application.dataPath + FILE_DIR))
        {
            Directory.CreateDirectory(path: Application.dataPath + FILE_DIR);
        }
        File.WriteAllText(FILE_PATH, contents: fileContent);
    }

    
}
