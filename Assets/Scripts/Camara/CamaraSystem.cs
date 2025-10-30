using UnityEngine;

public class CamaraSystem : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform objetivo;

    [Header("Movimiento cámara")]
    public float velocidadCamara = 0.025f;
    public Vector3 desplazamiento = new Vector3(0f, 4.2f, -10f);

    [Header("Fondo 2D para límites")]
    public SpriteRenderer fondo;

    private float minX, maxX, minY, maxY;
    private float camaraAltura, camaraAncho;

    void Start()
    {
        if (Camera.main == null || objetivo == null || fondo == null)
        {
            Debug.LogWarning("Faltan referencias importantes en CamaraSystem.");
            return;
        }

        
        camaraAltura = Camera.main.orthographicSize;
        camaraAncho = camaraAltura * Camera.main.aspect;

        
        Vector3 fondoPos = fondo.transform.position;
        Vector3 fondoSize = fondo.bounds.size;

        
        minX = fondoPos.x - fondoSize.x / 2 + camaraAncho;
        maxX = fondoPos.x + fondoSize.x / 2 - camaraAncho;
        minY = fondoPos.y - fondoSize.y / 2 + camaraAltura;
        maxY = fondoPos.y + fondoSize.y / 2 - camaraAltura;
    }

    void LateUpdate()
    {
        if (objetivo == null || fondo == null) return;

        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        posicionDeseada.x = Mathf.Clamp(posicionDeseada.x, minX, maxX);
        posicionDeseada.y = Mathf.Clamp(posicionDeseada.y, minY, maxY);

       
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
    }
}
