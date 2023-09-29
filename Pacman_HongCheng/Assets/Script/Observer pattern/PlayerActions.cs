using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour, IObserver
{

    [SerializeField] int _HitCount = 0;
    int _destroyThreshold = 5;
    Coroutine _currentHitResetRoutine = null;
    Coroutine _currentPowerUpResetRoutine = null;
    public AudioSource _audioPlayer1, _audioPlayer2;
    public AudioClip _shootAudioClip;
    public Animator comboAnim;
    public AudioClip _comboAudioClip;
    public AudioClip _collectAudioClip;
    public CameraScript CS;
    public GameObject powerUpIcon; 

   
    public void OnNotify(Action actionType)
    {
        Debug.Log("I got notified");
        switch (actionType)
        {
            case (Action.OnEnemyShot):
                Debug.Log("enemy shot");
                if (_currentHitResetRoutine != null)
                {
                    StopCoroutine(_currentHitResetRoutine);
                } 
                _HitCount += 1;

                if (_HitCount == _destroyThreshold)
                {
                    comboAnim.SetTrigger("Play");
                    _audioPlayer1.clip = _comboAudioClip;
                    _audioPlayer1.Play();
                }

                _currentHitResetRoutine = StartCoroutine(HitResetRoutine());
                break; //(exits the switch)
                //default(exits the whole void function)

            case (Action.OnPlayerShoot):
                Debug.Log("shooting");
                CS.ShakeCam(0.1f, 0.5f);
                 
                _audioPlayer2.clip = _shootAudioClip;
                _audioPlayer2.Play();
                break;

            case (Action.OnPowerUpCollect):
                Debug.Log("collect power up");
                if (_currentPowerUpResetRoutine != null)
                {
                    StopCoroutine(_currentPowerUpResetRoutine);
                }
                _audioPlayer1.clip = _collectAudioClip;
                _audioPlayer1.Play();
                powerUpIcon.SetActive(true);
                _currentPowerUpResetRoutine = StartCoroutine(PowerUpResetRoutine());
                break;

            default:
                Debug.Log("Not an action type."); 
                break;
        }
        Debug.Log(actionType.ToString());
    }


    IEnumerator HitResetRoutine()
    {
        yield return new WaitForSeconds(3f);
        _HitCount = 0;
    }

    IEnumerator PowerUpResetRoutine()
    {
        yield return new WaitForSeconds(5f);
        powerUpIcon.SetActive(false);
    }
}
