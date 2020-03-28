# AION Database Parser
[![Build status](https://ci.appveyor.com/api/projects/status/dk8dn6ry2rynhkh0?svg=true)](https://ci.appveyor.com/project/Iswenzz/aion-database-parser)
[![CodeFactor](https://www.codefactor.io/repository/github/iswenzz/aion-database-parser/badge)](https://www.codefactor.io/repository/github/iswenzz/aion-database-parser)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

This application serves as a webscraper to pull information from http://aiondatabase.net and parse it into useable data to be output later to both the console window and an `.XML` file. The intended purpose of this application is to retrieve all of the items that NPCs will drop throughout the world of AION. 

Things that will be parsed include the name of the item, its rarity, its ID number, and the level of the item. There are a few ways to get more specified output, such as searching on the AION database directly, from the `AL-Game` spawn `.XML` template which will get the NPC IDs from this `.XML` file, then reference the AION database to retrieve all of the items, or by a text file containing one or more NPC IDs which will get all of the items dropped by only those NPCs.

![](https://i.imgur.com/UpQWlIz.png)

## Parser

* From MAP ID
* From AL-Game spawn XML template
* From TXT files with NPC IDS

## Config items

* Drop chance
* Min Max amount
* Groups

The Drop Chance is loosely based off of AION 1.0's drop chances, but you can add your own custom values if you want. Min/max values as well as item groups can be fully customized by following the example I've provided in the text file attached to the release of this program.
