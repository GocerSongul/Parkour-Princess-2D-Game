using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointofplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private AudioSource _audio;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        textMeshPro.text = score.totalscore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Elmas"))
        {
            _audio.Play();
            Destroy(collision.gameObject);
            score.totalscore++;
            textMeshPro.text=score.totalscore.ToString();
        }
        if(collision.gameObject.CompareTag("engel"))
        {
            score.totalscore = 0;
        }
    }
}
