using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal");
        Vector3 posicion = transform.position;
        transform.position = new Vector3(posicion.x + velocidadX, posicion.y, posicion.z);
    }
}
