using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float SceneDelay = 1.0f;
    [SerializeField] AudioClip collisionAudio;
    [SerializeField] ParticleSystem CrashExplosion;
    [SerializeField] ParticleSystem successPlosion;

    AudioSource m_AudioSource;
    
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Obstacle":
                CrashSequenceFailure();   
                break;
            case "Pad":
                Debug.Log("Collided with Pad");
                break;
            case "FinishPad":
                LoadNextLevel();
                m_AudioSource.PlayOneShot(collisionAudio);
                successPlosion.Play();
                break;
            case "Fuel":
                Debug.Log("Collided with Fuel");
                break;
            default:
                CrashSequenceFailure();
                break;
        }
    }

    void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void CrashSequenceFailure()
    {
        m_AudioSource.PlayOneShot(collisionAudio);
        CrashExplosion.Play();
        GetComponent<PlayerMovement>().enabled = false;

        StartCoroutine(SceneDelayRespawning());
        
    }

    IEnumerator SceneDelayRespawning()
    {
        yield return new WaitForSeconds(SceneDelay);

        ReloadLevel();
    }


    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
