using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esse script sera responsavel por configurar o Buraco Negro*/

public class Blackhole : MonoBehaviour
{

    private Rigidbody2D body;//Declara o corpo rigido do buraco negro.

    public float Angle = 10;//Angulo escolhido para comandar a rotacao do corpo.

    void Start()
    {
        body = GetComponent<Rigidbody2D>();//Armazena o "corpo" em uma variavel.
    }

    void Update()
    {
        body.transform.Rotate(0, 0, Angle*Time.deltaTime); //Faz o buraco negro ficar girando.
    }
}
