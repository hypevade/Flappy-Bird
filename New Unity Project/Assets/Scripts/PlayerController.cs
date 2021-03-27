using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float h = 99f;
    public static bool isJump = false;
    private Rigidbody2D rb;
    public static bool isDead = false;
    public Animator animator;
    [SerializeField] private Camera cam;
    public Text Score;
    public Text Score_shadow;
    public static int score_ = 0;
    [SerializeField] private AudioSource Hit;
    [SerializeField] private AudioSource Game_Over_sound;
    [SerializeField] private AudioSource Score_Up;

    private bool IsKick = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Score.text = score_.ToString();
        Score_shadow.text = Score.text;
    }
    

    void Update()
    {

        Score.text = score_.ToString();
        Score_shadow.text = Score.text;

    }

    private void FixedUpdate()
    {
        if (isJump && !isDead && Pause_script.GameIsStarted)
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(0f, 500f));
            isJump = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            isDead = true;
            if (!IsKick && Pause_script.SoundOn)
            {
                Hit.Play();
                IsKick = true;
                Game_Over_sound.Play();

            }
            
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Counter"))
        {
            score_++;
            if (Pause_script.SoundOn)
                Score_Up.Play();

        }
    }
    public void Start_game()
    {
        Pause_script.GameIsStarted = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
        animator.SetBool("StartGame", true);
    }

}
