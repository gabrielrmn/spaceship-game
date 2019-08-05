using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esse script sera responsavel por controlar as funcionalidades do projetil: dano dado, velocidade de movimento
efeito de impacto*/

public class BulletRed : MonoBehaviour
{
    //Variaveis responsaveis por definir a quantidade de dano que sera causado por um projetil e a velocidade com que ele se desloca.
    private int damage = 25;
    public float speed = 2.5f;

    public Rigidbody2D body;//Declara o corpo rigido do projetil.

    public GameObject impact;//Declara o efeito de impacto.

    void Start()
    {
        body.velocity = transform.up * speed;//Adiciona velocidade ao projetil.
    }

    //Essa funcao sera responsavel por detectar se o projetil entrou em colisao com outro objeto.
    void OnTriggerEnter2D(Collider2D hit )
    {
        LifeBlue enemy = hit.GetComponent<LifeBlue>();//Declaracao da vida do inimigo.

        if (enemy != null)
        { 
            enemy.takeDamage(damage);//Adiciona dano a vida do inimigo, de modo a modificar a barra de vida.
        }

        //Como o buraco negro nao deve colidir com os outros corpos, verificamos a colisao exceto para ele.
        if (hit.name != "BlackHole")
        {
            Destroy(gameObject);//Se uma colisao for detectada, o objeto deve ser destruido.
            Instantiate(impact, transform.position, transform.rotation);//Instancia o efeito de impacto.
        }
    }
}
