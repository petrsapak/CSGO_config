# CSGO_config for the Satturday night sessions!

## Where to copy the config
- <your_steam_directory>\steamapps\common\Counter-Strike Global Offensive\csgo\cfg\
- e.g. C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\cfg\gamemode_satturday_night.cfg

## How to start the server
- Start CS-GO
- Start "Practice With Bots" mode

<img src="https://user-images.githubusercontent.com/9948892/116783310-56024780-aa8e-11eb-9b6a-00cd77c648f4.png" width="350" height="250">

## How to start the game mode
- Once the server starts, open the Dev Console (by default by pressing '~', if nothing happens you have to enable the dev console in game settings)
- Execute this command:

```
exec gamemode_satturday_night
```

- Wait for the others to join
- If you need more or less bots use these commands:

```
bot_kick_t
bot_kick_ct
bot_add_t
bot_add_ct
```

- When everyone is ready execute:

```
mp_restartgame 5
```

## Other notes
- If you want to switch map execute:

```
map <map_name>
map de_dust2
changelevel <map_name>
changelevel de_dust2
```

- You will have to repeat the process in "How to start the game mode" section
- There should be a way to do it automatically https://developer.valvesoftware.com/wiki/CSGO_Custom_Game_Mode

## Important settings in this config

Feature | Command | Type | Value in this config | Notes
--- | --- | --- | --- | ---
Number of Rounds | mp_maxrounds | int | 30 | After 15 rounds the sides will switch
Half Time | mp_halftime | bool | 1 | 0 = off, 1 = on
Auto Team Balance | mp_autoteambalance | bool | 0 | 0 = off, 1 =  on
Limit Teams | mp_limitteams | int | 10 | Max. number of players on each side
Freeze Time | mp_freezetime | int | 5 |
Free Armor | mp_free_armor | int | 2 | 0 = no, 1 = kevlar, 2 = kevlar + helmet
Bot Difficulty | bot_difficulty | int | 2 | noobs = 0, 1, 2, 3 = little better noobs
Bot Quota Mode | bot_quota_mode | string | casual | - casual = the bots play normally <br> - competitive = the bots are stuck at spawn and do nothing

