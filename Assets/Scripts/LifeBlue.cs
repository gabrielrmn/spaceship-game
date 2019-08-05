using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Esse script sera responsavel pela configuracao da vida do Player 1 (Spaceship Blue): 
dano sofrido, modificacao da imagem que determina a vida (barra de vida)*/

public class LifeBlue : MonoBehaviour
{
    public Image life; //declaracao da barra de vida.

    public float initialLife; //valor da vida inicial.
    private float currentLife; //valor da vida atual.

    void Start()
    {
        currentLife = initialLife; //inicializa-se a vida atual com o valor a vida inicial.
    }

    public void takeDamage(float damage)
    {
        currentLife -= damage; //reduzimos a vida atual de acordo com o dano sofrido pelo inimigo.

        life.fillAmount = currentLife / initialLife;  //modifica-se a imagem de acordo com a razao entre a vida atual e a vida inicial.

        if (currentLife <= 0) //verifica se o personagem ainda tem vida.
        {
            transform.GetComponent<ControllerBlue>().Explode(); //se a condicao for verdadeira, a Spaceship Blue explode.
        }
    }
}
