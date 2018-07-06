using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	public Button m_SelectLvl1;
	public Button m_SelectLvl2;

	public GameObject m_StartMenu;
	public GameObject m_SelectLvlMenu;
	public GameObject m_Player1Select;
	public GameObject m_Player2Select;

	public GameObject[] m_ShipPrefabs;
	public Vector3[] m_Position;

	private bool m_Lvl2Active = false;
	private bool m_2player;
	private string m_Scenes;

	public void GoToSelectLvl()
	{
		m_StartMenu.SetActive(false);
		m_SelectLvlMenu.SetActive(true);
	}

	public void SetScenes(string a_ScenesName)
	{
		m_Scenes = a_ScenesName;
	}
}
