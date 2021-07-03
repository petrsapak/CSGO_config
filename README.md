# CSGO configs and tools for the Satturday night sessions!

## Satturday.cfg

### Where to copy the config files
- <your_steam_directory>\steamapps\common\Counter-Strike Global Offensive\csgo\cfg\
- e.g. C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\csgo\cfg\satturday.cfg

### How to start the server
- Start CS-GO
- Start "Practice With Bots" mode

<img src="https://user-images.githubusercontent.com/9948892/116783310-56024780-aa8e-11eb-9b6a-00cd77c648f4.png" width="350" height="250">

### How to start the game mode
- Once the server starts, open the Dev Console (by default by pressing '~', if nothing happens you have to enable the dev console in game settings)
- Execute this command:

```
exec satturday
```

- Wait for the others to join
- If you need more or less bots use these commands:

```
bot_kick t
bot_kick ct
bot_kick all
bot_add_t
bot_add_ct
```

- When everyone is ready use one of these commands:

```
mp_restartgame <number_of_seconds_till_restart>
e.g. mp_restartgame 5
```

### Other notes
- If you want to switch map use one of these commands:

```
map <map_name>
e.g. map de_dust2
changelevel <map_name>
e.g. changelevel de_dust2
```
- Some of our favourite maps:
  - de_dust2, de_inferno, de_mirage, de_nuke
  - cs_office, cs_italy, cs_militia, cs_assault, cs_apollo
- You will have to repeat the process in "How to start the game mode" section (However there should be a way to do it automatically https://developer.valvesoftware.com/wiki/CSGO_Custom_Game_Mode)

### Important settings in this config

Feature | Command | Type | Value in this config | Notes
--- | --- | --- | --- | ---
Number of Rounds | mp_maxrounds | int | 20 | After 10 rounds the sides will switch
Half Time | mp_halftime | bool | 1 | 0 = off, 1 = on
Auto Team Balance | mp_autoteambalance | bool | 0 | 0 = off, 1 =  on
Limit Teams | mp_limitteams | int | 10 | Max. number of players on each side
Freeze Time | mp_freezetime | int | 5 |
Free Armor | mp_free_armor | int | 2 | 0 = no, 1 = kevlar, 2 = kevlar + helmet
Free Defuser | mp_defuser_allocation | int | 2 | 0 = no, 1 = one random player, 2 = everybody
Bot Difficulty | bot_difficulty | int | 2 | 0 = noobs, 1 = normal, 2 = experts, 3 = beyond experts
Bot Quota Mode | bot_quota_mode | string | casual | - casual = the bots play normally <br> - competitive = the bots are stuck at spawn and do nothing

## Pratice.cfg
- This config file was created by http://csgoconsole.com/resources/training-configs.html and I put it here only to have all my favourite configs in one location.
- Great for practicing smokes and tactics
- The way to start this config is the same as Satturday.cfg
- Also I recomment do use

```
bind "<key_you_want_to_use>" "noclip" 
e.g. bind "C" "noclip"
```
now if you press C you can move freely on the map without any collisions. Press C again to return to normal state.

## Random team generator - first release
- Wpf application which takes in account the rank of the player and tries to create balanced teams.

### Instalation
- Download TeamGenerator.zip archive from this repository
- Expand it wherever you see fit and the installation is complete

### How to use the app
- To start the application run the TeamGenerator.Shell.exe
- The UI is pretty simple and workflow very straightforward


![image](https://user-images.githubusercontent.com/9948892/124349762-220fe380-dbf1-11eb-9af6-4d88057d20ba.png)

#### Add player
- Insert Nick and Rank in the "Add player" section, then click on the "Add" button.
- Troubleshoot
  - The "Add" button is disabled
    - You already have player with this nick in "Available players" list
    - The player has invalid "Nick" (at this moment the only invalid nick is an empty string)
    - You still have focus in the "Nick" text box (press TAB or click outside the text box)

#### Delete player
- Select player in "Available players" section and press DELETE key

#### Generate teams
- Press "Generate teams" button
- You can press this button as many times as you want - it will create different & balanced teams from the "Available players" list
- Troubleshoot
  - The "Generate teams" button is disabled
    - There are no available players in the "Available players" list


![image](https://user-images.githubusercontent.com/9948892/124350199-80d65c80-dbf3-11eb-97a8-4847ccd95eae.png)

