using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esse script sera responsavel por controlar a resolucao do Game (permitir o redimensionamento).*/

public class ScriptCamera : MonoBehaviour
{
    //Variavel responsavel pelo ajuste no tamanho da janela.
    public KeyCode switchResolution;

    //Contador para verificar o numero de vezes em que a tecla foi pressionada.
    int keyDownCounter = 0;

    //Variavel para verificar se a tecla esta pressionada ou nao.
    bool checkSwitchKey = false;


    void Start()
    {
        //Inicializa a tela como 1024x768.
        Screen.SetResolution(1024, 768, true);
    }

    //Verifica se a tecla esta pressionada ou nao.
    void Update()
    {
        if (Input.GetKeyDown(switchResolution))
            checkSwitchKey = true;
        else
            checkSwitchKey = false;
    }

    private void FixedUpdate()
    {
        /*Se a tecla definida para o ajuste da janela estiver pressionada e o contador estiver em zero, o jogo é redimensionado 
        para o modo janela.*/
        if (checkSwitchKey && keyDownCounter == 0)
        {

            Screen.SetResolution(1024, 768, false);

            keyDownCounter = 1;

        }
        //Se a tecla definida para o ajuste da janela estiver pressionada e o contador estiver em 1, o jogo passa a ser em fullscreen.
        else if (checkSwitchKey && keyDownCounter == 1)
        {

            Screen.SetResolution(1024, 768, true);

            keyDownCounter = 0;
        }


    }
}
