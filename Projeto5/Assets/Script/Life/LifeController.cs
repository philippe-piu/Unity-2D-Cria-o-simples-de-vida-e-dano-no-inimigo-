using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    //Cabeçalho e declaração de variáveis
    [Header("Referência da Unity")]
    private Rigidbody2D rbd;
    private Animator anima;

    [Header("Vida")]
    public int lifeCharacter;

    //Método padrão da Unity que inicia antes de tudo no jogo
    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método de De Diminuição de vida 
    public void DanoCharacter(int dano)
    {
        lifeCharacter -= dano;
        Debug.Log("Vida Atual em "+lifeCharacter);
        if(lifeCharacter <= 0)
        {
            anima.Play("die");

            Destroy(gameObject, 1.5f);
        }
    }



}
