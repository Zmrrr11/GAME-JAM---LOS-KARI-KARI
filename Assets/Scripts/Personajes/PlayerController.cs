using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaRebote = 5f;
    public int vida = 3;
    private bool recibiendoDanio;
    public bool muerto;
    private Rigidbody2D rb;
     //public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!muerto)
        {
        float velocidadX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime * velocidad;
        //animator.SetFloat("movement", velocidadX * velocidad);

        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        Vector3 posicion = transform.position;
        if (!recibiendoDanio)
        transform.position = new Vector3(posicion.x + velocidadX, posicion.y, posicion.z);
        }
    }
    public void recibeDanio(Vector2 direccion, int cantDanio)
{
    if (!recibiendoDanio)
    {
        recibiendoDanio = true;
        vida -= cantDanio;
        if (vida <= 0)
        {
            muerto = true;
        }
        if (!muerto)
        {
        Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized;
        rb.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);

        // Llama a la corrutina para recuperar control después de 0.5 segundos
        StartCoroutine(RecuperarControl(1f));
        }
    }
}
public void desactivaDanio() { recibiendoDanio = false; }
private IEnumerator RecuperarControl(float tiempo)
{
    yield return new WaitForSeconds(tiempo);
    desactivaDanio();
}
}
