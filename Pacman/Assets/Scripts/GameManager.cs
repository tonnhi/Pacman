using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;

    public Pacstudent pacstudent;

    public Transform pellets;

    public int score { get; private set; }

    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }
    
    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
    
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void NewRound()
    {
        foreach (Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }
    }

    private void ResetState()
    {
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[1].gameObject.SetActive(true);
        }
        this.pacstudent.gmeObject.SetActive(true);
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[1].gameObject.SetActive(false);
        }
        this.pacstudent.gmeObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost)
    {
        SetScore(this.acore + ghost.points);
    }

    public void PacmanEaten()
    {
        this.pacstudent.gameObject.SetActive(false);

        SetLivea(this.lives -1);

        if(this.lives > 0) {
            Invoke(Nameof(ResetState), 3.0f);
        } else {
            GameOver();
        }
    }
}
