using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Cabe�alho e declara��es de vari�veis
    [Header("Refer�ncias da Unity")]
    private GameObject player;

    [Header("Eixo")]
    public float offset_Y = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Informa��es chamadas frame a frame no caso v�rias vezes
    void Update()
    {
        Camera();
    }

    //M�todo de cria��o da c�mera para seguir o posicionamento do personagem
    private void Camera()
    {
        if (player != null)
        {
            Vector3 posicao = new Vector3(player.transform.position.x, player.transform.position.y + offset_Y, -10);
            this.transform.position = posicao;
        }

    }
}
