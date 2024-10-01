using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollisionAttack : MonoBehaviour
{
    //Cabe�alho e declara��o de vari�veis
    [Header("Refer�ncia do Dano")]
    private int dano;

    // Este m�todo � utilizado para receber e armazenar o valor do dano
    public void Attack(int danoattack)
    {
        dano = danoattack;
        Debug.Log("Dano com valor de " + dano);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*Quando o personagem colide com um objeto que possui a tag "Enemy", acessa o 
             * script LifeController no inimigo, chamo o m�todo DanoCharacter e aplico um dano que ser� 
             * descontado diminuindo a vida do inimigo a vida do inimigo.*/
            collision.GetComponent<LifeController>().DanoCharacter(dano);
            Debug.Log("Ativa��o do Colidder do Hero Attack Collision");

        }
    }
}
