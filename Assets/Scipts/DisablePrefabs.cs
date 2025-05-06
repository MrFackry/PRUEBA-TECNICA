using UnityEngine;

public class DisablePrefabs : MonoBehaviour
{   
    
     private SpawnManager spawnManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//generamos un rayCastdesde la camara hasta el punto que queremos eliminar
            RaycastHit hit;//guarda el punto de colicion 
            if (Physics.Raycast(ray, out hit))//lanza el ray y comprueba si hay colicion 
            {
                spawnManager.DisablePrefabs(hit.collider.gameObject);//desatibamos el prefab al que le hicimos click
            }
        }
    }
}
