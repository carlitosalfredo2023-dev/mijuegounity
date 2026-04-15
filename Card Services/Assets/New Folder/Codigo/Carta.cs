using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Carta : MonoBehaviour
{
    bool puedeSerRecogida;
    Cartero cartero;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if( puedeSerRecogida && Keyboard.current.eKey.wasPressedThisFrame)
        {
            cartero.cartaEnMano = transform.root.gameObject;
            transform.root.gameObject.SetActive(false);
        }

        if (cartero != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            cartero.cartaEnMano= null;
            transform.root.gameObject.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            cartero = other.GetComponent<Cartero>();
            puedeSerRecogida = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            cartero = null;
            puedeSerRecogida = false;
        }
    }

}
