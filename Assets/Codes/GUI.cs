using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour
{
	public void OnClick(int Game)
	{
		SceneManager.LoadScene(Game);
	} 
}