using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollisionAttack : MonoBehaviour
{
    //Cabeçalho e declaração de variáveis
    [Header("Referência do Dano")]
    private int dano;

    // Este método é utilizado para receber e armazenar o valor do dano
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
             * script LifeController no inimigo, chamo o método DanoCharacter e aplico um dano que será 
             * descontado diminuindo a vida do inimigo a vida do inimigo.*/
            collision.GetComponent<LifeController>().DanoCharacter(dano);
            Debug.Log("Ativação do Colidder do Hero Attack Collision");

        }
    }
}
