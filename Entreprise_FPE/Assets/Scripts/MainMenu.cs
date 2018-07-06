using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public Button m_SelectLvl1;
	public Button m_SelectLvl2;

	public GameObject m_StartMenu;
	public GameObject m_SelectLvlMenu;
	public GameObject m_MenuPlayer1Select;
	public GameObject m_MenuPlayer2Select;

	public GameObject[] m_ShipPrefabs;
	public Transform[] m_Position;

	private bool m_Lvl2Active = false;
	private bool m_2player = false;
	private string m_Scenes;

	public void GoToSelectLvl()
	{
		m_StartMenu.SetActive(false);
		m_SelectLvlMenu.SetActive(true);
	}

	public void SetScenes(string a_ScenesName)
	{
		m_Scenes = a_ScenesName;
        m_SelectLvlMenu.SetActive(false);
        m_MenuPlayer1Select.SetActive(true);
	}

    public void SetSpaceShipWanted(int a_Choice)
    {
        if (!m_2player)
        {
            GameObject a_Player = Instantiate(m_ShipPrefabs[a_Choice], m_Position[a_Choice]);
            DontDestroyOnLoad(a_Player);
            m_MenuPlayer1Select.SetActive(true);

            SceneManager.LoadScene(m_Scenes);
        }
        else
        {
            GameObject a_Player = Instantiate(m_ShipPrefabs[a_Choice], m_Position[a_Choice]);
            DontDestroyOnLoad(a_Player);
            m_MenuPlayer1Select.SetActive(false);
            m_MenuPlayer2Select.SetActive(true);
            m_2player = !m_2player;
        }
    }

    public void Set2Player()
    {
        m_2player = !m_2player;
    }
}
