using UnityEngine;
using System.Collections;

public class SpermLife : MonoBehaviour
{

    
    
    public GameObject _DestroyEffect;
    public GameObject _DestroyEffectPrefab;
    public GameObject _DestroyEffectGroup;
    public AudioSource _EnemySound;
    private bool _isNameDisplayed;

    // Use this for initialization
    void Start()
    {
        // Instantiate(_DestroyEffectPrefab);

        _DestroyEffectGroup = GameObject.Find("DestroyEffectGroup");
        _EnemySound = GameObject.Find("EnemySoundEffects").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator PauseEmission()
    {
        yield return new WaitForSeconds(1f);
        
    }

    public void Die()
    {
        if (!_isNameDisplayed)
        {
            _isNameDisplayed = true;
            _DestroyEffect = Instantiate(_DestroyEffectPrefab, _DestroyEffectGroup.transform) as GameObject;
            _DestroyEffect.transform.position = transform.position;
            _DestroyEffect.GetComponent<ParticleSystem>().Emit(50);
            if (!_EnemySound.isPlaying)
            {
                _EnemySound.Play();
            }
            Destroy(gameObject);
        }
        StartCoroutine(PauseEmission());
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WALL"))
        {

            Die();
        }

    }
}
