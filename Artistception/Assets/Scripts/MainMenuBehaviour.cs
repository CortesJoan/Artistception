using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour {
	public GameObject optionsMenu;
	SoundManager soundManager;


	public void LoadLevel(string levelName){
		SceneManager.LoadScene (levelName);
	}
 
 
	public void EndGame(){

		#if UNITY_EDITOR 
			UnityEditor.EditorApplication.isPlaying = false;
		#else 
			Application.Quit();
		#endif
	}
	 
	public void OpenOptions()
	{
	 
		optionsMenu.SetActive(true);
	}public void CloseOptions()
	{
	 
		optionsMenu.SetActive(false);
	}
	private void UpdateQualityLabel()
	{
		int currentQuality = QualitySettings.GetQualityLevel();
		string qualityName = QualitySettings.names[currentQuality];

		optionsMenu.transform.Find("QualityLevel").GetComponent<UnityEngine.UI.Text>().text = "Quality: " + qualityName;

	}

	private void UpdateMasterVolumeLabel()
	{
		Debug.Log(AudioListener.volume);
		float MasterAudioVolume = AudioListener.volume * 100;
		optionsMenu.transform.Find("MasterVolume").GetComponent<UnityEngine.UI.Text>().text = "Master Volume: " + MasterAudioVolume.ToString("f2") + "%";
		 
	}private void UpdateBGMVolumeLabel()
	{
		 
		float BgmAudioVolume = soundManager.AS[0].volume * 100;
		 	optionsMenu.transform.Find("BGMVolume").GetComponent<UnityEngine.UI.Text>().text = "BGM Volume: " + BgmAudioVolume.ToString("f2") + "%";
 }private void UpdateBGSVolumeLabel()
	{
		Debug.Log(AudioListener.volume);
	 
		float BgsAudioVolume = soundManager.AS[1].volume * 100;
	 

	 	optionsMenu.transform.Find("BGSVolume").GetComponent<UnityEngine.UI.Text>().text = "BGS Volume: " + BgsAudioVolume.ToString("f2") + "%";
	 }private void UpdateSEVolumeLabel()
	{ 
		float SEAudioVolume = soundManager.AS[2].volume * 100;

	 
		optionsMenu.transform.Find("SEVolume").GetComponent<UnityEngine.UI.Text>().text = "SE Volume: " + SEAudioVolume.ToString("f2") + "%";
	}

	 

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void IncreaseQuality()
	{
		QualitySettings.IncreaseLevel();
		UpdateQualityLabel();
	}

	public void DecreaseQuality()
	{
		QualitySettings.DecreaseLevel();
		UpdateQualityLabel();
	}

	public void SetMasterVolume(float value)
	{
		AudioListener.volume = value;
		UpdateMasterVolumeLabel();
	}public void SetBGMVolume(float value)
	{
		soundManager.AS[0].volume = value;
		UpdateBGMVolumeLabel();
	}public void SetBGSVolume(float value)
	{
		soundManager.AS[1].volume = value;
		UpdateBGSVolumeLabel();
	}public void SetSEVolume(float value)
	{
		soundManager.AS[2].volume = value;
		UpdateSEVolumeLabel();
	}

	private void Start()
	{
		soundManager = FindObjectOfType<SoundManager>();
		//Destroy(GameObject.Find("Main Camera").gameObject);
		UpdateBGMVolumeLabel();
		UpdateBGSVolumeLabel();
		UpdateMasterVolumeLabel();
		UpdateQualityLabel();
		UpdateSEVolumeLabel();

	}
}
