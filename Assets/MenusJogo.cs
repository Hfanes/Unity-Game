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


    
    
    // Start is called before the first frame update
    void Start()
    {
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

   //Fun��o que leva o utilizador para o primeiro n�vel
   public void Jogar()
   {
        canvasMenuPrincipal.SetActive(false);
        SceneManager.LoadScene("lvl1");
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
    public void VoltarMI_MP()
    {
        canvasMenuInstrucoes.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }


    //Para voltar para o Menu Principal, estando no Menu da Hist�ria
    public void VoltarMH_MP()
    {
        canvasMenuHistoria.SetActive(false);
        canvasMenuPrincipal.SetActive(true);
    }

    //Para ver a p�gina da Descricao do Poder, estando no Menu da Hist�ria
    public void VerLivro()
    {
        canvasMenuHistoria.SetActive (false);
        canvasDescricaoPoder.SetActive(true);
    }

    //Para voltar para o Menu da Hist�ria, estando na P�gina da Descri��o do Poder
    public void VoltarDP_MH()
    {
        canvasDescricaoPoder.SetActive (false);
        canvasMenuHistoria.SetActive(true);
    }

    //Para voltar para o Menu Principal, estando no Menu dos Cr�ditos
    public void VoltarMC_MP()
    {
        canvasMenuCreditos.SetActive (false);
        canvasMenuPrincipal.SetActive(true);
    }

    //-------------------------------------------------MENU SECUND�RIO--------------------------------------------------------------------

    //Volta para 1� N�vel
    public void NovoJogo()
    {
        canvasMenuSecundario.SetActive(false);
        SceneManager.LoadScene("lvl1");
    }

    //Continuar a jogar
    public void ContinuarJogo()
    {
        canvasMenuSecundario.SetActive(false);

        //#if UNITY_EDITOR
        //    UnityEditor.EditorApplication.isPaused = false;
        //#endif
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