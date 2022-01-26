using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DJD{
public class MenusJogo : MonoBehaviour
{
    
    public GameObject canvasMenuPrincipal;
    public GameObject canvasMenuHistoria;
    public GameObject canvasMenuInstrucoes;
    public GameObject canvasMenuCreditos;
    public GameObject canvasMenuSecundario;
    public GameObject canvasDescricaoPoder;
    public GameObject canvasGameOver;
    InputHandler inputHandler;



    
    
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = FindObjectOfType<InputHandler>();
        canvasMenuPrincipal.SetActive(false);
        canvasMenuInstrucoes.SetActive(false);
        canvasMenuCreditos.SetActive(false);
        canvasMenuHistoria.SetActive(false);
        canvasMenuSecundario.SetActive(false);
        canvasDescricaoPoder.SetActive(false);
        canvasGameOver.SetActive(false);
    }


    public void MenuEntrar(){
        canvasMenuPrincipal.SetActive(true);
    }
    public void MenuSair(){
        canvasMenuPrincipal.SetActive(false);
    }



   //Fun��o que leve o utilizador a sair do jogo
   public void Sair()
   {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
   }

    //Interface que cont�m as intru��es do jogo
    public void Instrucoes()
    {
        canvasMenuInstrucoes.SetActive (true);
        canvasMenuPrincipal.SetActive(false);
    }

    //Interface que cont�m a hist�ria do jogo
    public void Historia()
    {
        canvasMenuPrincipal.SetActive(false);
        canvasMenuHistoria.SetActive(true);
    }

    //Interface que cont�m os cr�ditos do jogo
    public void Creditos()
    {
        canvasMenuPrincipal.SetActive(false);
        canvasMenuCreditos.SetActive(true);
    }

    //Para voltar para o Menu Principal, estando no Menu das Instru��es
    public void VoltarDeInstruçoes()
    {
        canvasMenuInstrucoes.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }


    //Para voltar para o Menu Principal, estando no Menu da Hist�ria
    public void VoltarDeHistoria()
    {
        canvasMenuHistoria.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }

    //Para ver a p�gina da Descricao do Poder, estando no Menu da Hist�ria
    public void HistoriaToPoder()
    {
        canvasMenuHistoria.SetActive (false);
        canvasDescricaoPoder.SetActive(true);
    }

    //Para voltar para o Menu da Hist�ria, estando na P�gina da Descri��o do Poder
    public void VoltarDePoder()
    {
        canvasDescricaoPoder.SetActive (false);
        canvasMenuHistoria.SetActive(true);
    }

    //Para voltar para o Menu Principal, estando no Menu dos Cr�ditos
    public void VoltarDeCreditos()
    {
        canvasMenuCreditos.SetActive (false);
        canvasMenuPrincipal.SetActive(true);
    }

    //-------------------------------------------------MENU SECUND�RIO--------------------------------------------------------------------

    //Volta para 1� N�vel
    public void NovoJogo()
    {
        canvasMenuSecundario.SetActive(false);
        SceneManager.LoadScene("Menus");
        inputHandler.gamePaused = false;
        Time.timeScale = 1;
    }

    //Continuar a jogar
    public void ContinuarJogo()
    {
        canvasMenuPrincipal.SetActive(false);
        Time.timeScale = 1;
        inputHandler.gamePaused = false;


    }

    //Ir do Menu Secund�rio para o Menu Principal
    public void IrMenuPrincipal()
    {
        canvasMenuSecundario.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }

    public void gameOver(){
        canvasGameOver.SetActive(true);
    }

    
}
}