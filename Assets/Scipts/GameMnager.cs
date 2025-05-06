using UnityEngine;

public class GameMnager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI texto;
    public static GameMnager gameManager;
    private int prefabCount;
    private SpawnManager spawnManager;

    private void Awake() {
        if (gameManager==null)
        {
            gameManager = this;
        }else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
     contarPrefabs(); 
    }

    public void contarPrefabs(){
       prefabCount=spawnManager.prefabActivos();
       texto.text = "prefabs:"+prefabCount;
    }
}
