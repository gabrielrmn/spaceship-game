using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esse script sera responsavel por verificar se as teclas que possuem a funcao de 
  modificar o jogo de forma global estao pressionadas. Nesse caso, a tecla R possui a 
  funcao de reiniciar o game.*/

public class ControllerOfScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //Verifica se a tecla R foi pressionada.
        {
            Application.LoadLevel(0); //Volta o jogo para seu estado inicial.
        }
    }
}
