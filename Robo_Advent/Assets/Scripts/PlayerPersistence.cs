using UnityEngine;

public static class PlayerPersistence
{
	public static void SaveData(Player player)
    {
        PlayerPrefs.SetFloat("playerHP", player.playerStats.Health);
        PlayerPrefs.SetFloat("playerStamina", player.playerStats.Stamina);
        PlayerPrefs.SetFloat("playerPunch", player.playerStats.Punch);
        PlayerPrefs.SetFloat("playerBlaster", player.playerStats.Blaster);
        PlayerPrefs.SetFloat("playerWalkingSpeed", player.playerStats.WalkingSpeed);
        PlayerPrefs.SetFloat("playerRunningSpeed", player.playerStats.RunningSpeed);
    }

    public static PlayerStats LoadData()
    {
        int playerHp = PlayerPrefs.GetInt("playerHP");
        int playerStamina = PlayerPrefs.GetInt("playerStamina");
        int playerPunch = PlayerPrefs.GetInt("playerPunch");
        int playerBlaster = PlayerPrefs.GetInt("playerBlaster");
        int playerWalkingSpeed = PlayerPrefs.GetInt("playerWalkingSpeed");
        int playerRunningSpeed = PlayerPrefs.GetInt("playerRunningSpeed");

        PlayerStats playerStats = new PlayerStats()
        {
            Health = playerHp,
            Stamina = playerStamina,
            Punch = playerPunch,
            Blaster = playerBlaster,
            WalkingSpeed = playerWalkingSpeed,
            RunningSpeed = playerRunningSpeed
        };

        return playerStats;
    }
}
