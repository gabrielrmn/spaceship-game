using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Esse script sera responsavel pelo controle do Player 1 (Spaceship Blue).
Nele, verificamos, se as teclas que possuem funcao de mover,freiar, atirar e rotacionar estao pressionadas e assim, damos funcionalidade 
a elas.*/

public class ControllerBlue : MonoBehaviour
{
    //Variaveis que representam as teclas com funcoes de rotacionar, mover, e freiar.
    public KeyCode turnRight, turnLeft;
    public KeyCode move,brake;

    /*Variavel que sera responsavel por armazenar e manipular a posicao e a rotacao de um objeto
    O objeto nesse caso é o projetil.*/
    public Transform firePoint;

    //Declara os objetos de jogo da nave: o projetil e o efeito de explosao.
    public GameObject bulletPrefab;
    public GameObject explosion;

    //Declara o corpo rigido da nave.
    private Rigidbody2D body;

    /*Variaveis que seram atribuidas a cada tipo de movimentacao da nave. Essa nave possui 
    uma movimentacao mais rapida.*/
    public float moveSpeed = 5f;
    public float rotSpeed = 3;
    public float brakeFactor = -1.2f;

    //Variaveis que checam se as teclas estao pressionadas.
    bool moveControll = false;
    bool brakeControll = false;
    bool leftControll = false;
    bool rightControll = false;
    bool fireControll = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); //Armazena o "corpo" em uma variavel.
    }

    /*Essa funcao sera responsavel por verificar se as teclas funcionais foram/estao pressionadas e
     atribuir true as variaveis de controle. OBS: Chamada uma vez por frame.*/
    void Update()
    {
        if (Input.GetKey(turnRight))
            rightControll = true;
        else
            rightControll = false;
        if (Input.GetKey(turnLeft))
            leftControll = true;
        else
            leftControll = false;
        if (Input.GetKey(move))
            moveControll = true;
        else
            moveControll = false;
        if (Input.GetKey(brake))
            brakeControll = true;
        else
            brakeControll = false;
        if (Input.GetButtonDown("Fire1"))
        {
            if (!fireControll)
            {
                //Inicia uma "rotina" para a funcao Shoot().
                StartCoroutine(Shoot());
                fireControll = true;
            }
        }
       
    }

    //Funcao responsavel por fazer a nave atirar o projetil.
    IEnumerator Shoot()
    {
        //Instancia o projetil na tela.
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Intervalo de tempo minimo para tiros consecutivos.
        yield return new WaitForSeconds(.5f);
        fireControll = false;
    }

    /*Funcao utilizada pois estao sendo utilizadas forcas fisicas para o corpo rigido.
   Recomenda-se ela para esse tipo de caso.*/
    void FixedUpdate()
    {
        if (rightControll)
            body.transform.Rotate(0, 0, -rotSpeed);

        if (leftControll)
            body.transform.Rotate(0, 0, rotSpeed);

        if (moveControll)
            body.AddForce(transform.up * Time.deltaTime * moveSpeed);

        if (brakeControll)
        {
            body.AddForce(transform.up * Time.deltaTime * moveSpeed * brakeFactor);

            /*Verifica se a velocidade esta proxima de zero. Dessa forma, a nave ira parar e nao iniciar um
            movimento para tras*/

            if (body.velocity.sqrMagnitude < 0.1)
                body.Sleep();
        }
    }

    //Verifica se a nave em questao colidiu com a sua inimiga e a destroi.
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "SpaceshipRed")
            Explode();

    }

    //Funcao responsavel por explodir a nave.
    public void Explode()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation); //Instancia o efeito de explosao na tela.
    }
}
