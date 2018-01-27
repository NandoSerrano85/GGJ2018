using UnityEngine;

public static class PlayerPersistence
{
	public static void SaveData(Player player)
    {
		PlayerPrefs.SetFloat("playerLevel", player.playerStats.Level);
        PlayerPrefs.SetFloat("playerHP", player.playerStats.Health);
        PlayerPrefs.SetFloat("playerStamina", player.playerStats.Stamina);
        PlayerPrefs.SetFloat("playerPunch", player.playerStats.Punch);
        PlayerPrefs.SetFloat("playerBlaster", player.playerStats.Blaster);
        PlayerPrefs.SetFloat("playerWalkingSpeed", player.playerStats.WalkingSpeed);
        PlayerPrefs.SetFloat("playerRunningSpeed", player.playerStats.RunningSpeed);
		PlayerPrefs.SetFloat("playerExperience", player.playerStats.Experience);
    }

    public static PlayerStats LoadData()
    {
		int playerLevel = PlayerPrefs.GetInt("playerLevel", 1);
        int playerHp = PlayerPrefs.GetInt("playerHP", 10);
        int playerStamina = PlayerPrefs.GetInt("playerStamina", 10);
        int playerPunch = PlayerPrefs.GetInt("playerPunch", 5);
        int playerBlaster = PlayerPrefs.GetInt("playerBlaster", 5);
        int playerWalkingSpeed = PlayerPrefs.GetInt("playerWalkingSpeed", 5);
        int playerRunningSpeed = PlayerPrefs.GetInt("playerRunningSpeed", 7);
		int playerExperience = PlayerPrefs.GetInt("playerExperience", 0);

        PlayerStats playerStats = new PlayerStats()
        {
			Level = playerLevel,
            Health = playerHp,
            Stamina = playerStamina,
            Punch = playerPunch,
            Blaster = playerBlaster,
            WalkingSpeed = playerWalkingSpeed,
            RunningSpeed = playerRunningSpeed,
			Experience = playerExperience
        };

        return playerStats;
    }
}
