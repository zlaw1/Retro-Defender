using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image text;
    public Text score;
    public Slider healthBar;
    private int finalScore = 0; 
    public Button sceneLoader; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update() 
    {
    score.text = finalScore.ToString();
        
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value -= damage;
        if(currentHealth <= 0)
        {
            
            text.gameObject.SetActive(true);
            sceneLoader.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        //trigger a you lose restart scene
    }
    public void RestoreHealth()
    {
        
        currentHealth += 40;
        healthBar.value += 40;
        if(currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void ReloadScene(){Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);}
    public void AddScore(int score)
    {
        finalScore += score;
        
    }
}
