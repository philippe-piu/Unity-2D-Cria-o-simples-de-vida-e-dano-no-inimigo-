using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Cabeçalho e declarações de variáveis
    [Header("Referências da Unity")]
    private GameObject player;

    [Header("Eixo")]
    public float offset_Y = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Informações chamadas frame a frame no caso várias vezes
    void Update()
    {
        Camera();
    }

    //Método de criação da câmera para seguir o posicionamento do personagem
    private void Camera()
    {
        if (player != null)
        {
            Vector3 posicao = new Vector3(player.transform.position.x, player.transform.position.y + offset_Y, -10);
            this.transform.position = posicao;
        }

    }
}
