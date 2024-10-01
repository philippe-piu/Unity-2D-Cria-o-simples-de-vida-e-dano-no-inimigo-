using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    //Cabeçalho e declaração de variáveis
    [Header("Referência da Unity")]
    private Rigidbody2D rbd;
    private Animator anima;

    [Header("Movimentação Player na Horizontal")]
    public float playerSpeed;
    private float horizontalMovimento;
    public bool movimentoDireitaPlayer = true;

    [Header("Ataque Player")]
    public float tempEsperaDeCadaAttackNoUnity;
    public float tempEsperaDeCadaAttackNoUnityFire2;
    public float tempEsperaDeCadaAttackNoUnityFire3;
    private float tempEsperaNextAttack;
    public int danoFire1;
    public int danoFire2;
    public int danoFire3;

    [Header("Life Controller")]
    public LifeController lifeController;
    public HeroCollisionAttack heroCollisionA;

    //Método padrão da Unity que inicia antes de tudo no jogo
    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        lifeController = GetComponent<LifeController>();
        //è Script de um GameObeject filho tem que passar como tal
        heroCollisionA = GetComponentInChildren<HeroCollisionAttack>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Se a Vida do Persogagem for 0 ele desabilita todas suas funções de andar, pular e atacar
        if (lifeController.lifeCharacter <= 0)
        {
            this.enabled = false
;
        }

        PlayerMovimentoHorizontal();
        Attack();
        
    }

    //Método de Movimento do Player pela horizontal
    private void PlayerMovimentoHorizontal()
    {
        horizontalMovimento = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(horizontalMovimento * playerSpeed, rbd.velocity.y);

        EspelharImagemCorpoPlayer();
    }

    //Método mover o rosto do personagem para esquerda quando clicar para ele ir para esquerda e direita quando clicar para direita
    private void EspelharImagemCorpoPlayer()
    {
        if (horizontalMovimento > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            movimentoDireitaPlayer = true;
            anima.SetBool("walk", true);
        }
        else if (horizontalMovimento < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            movimentoDireitaPlayer = false;
            anima.SetBool("walk", true);
        }

        if (horizontalMovimento == 0)
        {
            anima.SetBool("walk", false);
        }
    }

    //Método de Ataque do Player
    private void Attack()
    {
        // Incrementa o tempo de espera para o próximo ataque com o tempo passado desde o último frame
        tempEsperaNextAttack += Time.deltaTime;
        //Debug.Log(tempEsperaNextAttack);
        //Se o Botão esquerdo do mouse e o tempo de espera do para o proximo ataque for respeitado 
        if (Input.GetButtonDown("Fire1") && tempEsperaNextAttack > tempEsperaDeCadaAttackNoUnity)
        {
            // Reseta o tempo de espera para zero, pois o ataque está sendo executado agora
            tempEsperaNextAttack = 0;
            anima.Play("attack-1");
            heroCollisionA.Attack(danoFire1);

        }
        else if (Input.GetButtonDown("Fire2") && tempEsperaNextAttack > tempEsperaDeCadaAttackNoUnityFire2)
        {
            // Reseta o tempo de espera para zero, pois o ataque está sendo executado agora
            tempEsperaNextAttack = 0;
            anima.Play("attack-2");
            heroCollisionA.Attack(danoFire2);

        }
        else if (Input.GetKeyDown(KeyCode.Q) && tempEsperaNextAttack > tempEsperaDeCadaAttackNoUnityFire3)
        {
            // Reseta o tempo de espera para zero, pois o ataque está sendo executado agora
            tempEsperaNextAttack = 0;
            anima.Play("attack-3");
            heroCollisionA.Attack(danoFire3);

        }
    }
}
