HazeronAdviser
==============

City status and ship log viewer for [Shores of Hazeron](http://hazeron.com/).

Introduction
==============

My name is **Deantwo** and this is my little C# program that I have been working on for a little while.<br>
I started after seeing **se5a**'s [HazeronMapper](https://github.com/se5a/HazeronMapper) and thought it would be fun to try my self.

What is it
==============

**HazeronAdviser** is a simple little program written in C# that scans through all your HMails that are locally saved on your computer.<br>
Once loaded it is able to nicely list all your cities and ships, and then point you to the ones that require your attention.

Requirements
==============

- .Net Framework 4.0

How to use
==============

1. Log into **Hazeron** with your character
2. Open the *Governance* window (F12)
3. Go to the *Places* tab
4. Select all your cities on the list and right-click them, there click "Recent Report by Mail..."
5. Open the *Mail* window (F2)
6. Click the "Request New Messages" button
7. Start **HazeronAdviser** (if you hadn't already)
8. Click "Scan HMails"

Features
==============

- Scan all Hazeron mails automatically with one click
- Lists all cities, ships and officers
- Highlights cities that need attention (low morale, bad jobs/homes ratio, abandonment, ect.)
- Calculates the time before abandonment decay starts
- Visually shows population, homes, and jobs
- Visually shows morale
- Better overview of all officers and their home (in charge of ships, on planet, etc.)

Planned
==============

- More attention highlights for cities (no/low food, more?)
- Attention highlights for ships (no/low fuel, damaged, more?)
- A better overview of building TLs in a city
- An overview of resources in city storage
- Calculate the highest TL spacecraft that can be build
- What is keeping it from making higher TL spacecrafts
- Better overview of all officers and their home (in charge of ships, on planet, etc.) [(problem)](http://hazeron.com/phpBB3/viewtopic.php?f=5&t=6893)
- New tab just for "detected enermies" and the like
- Include scan results for a city's system ([now impossible](http://hazeron.com/phpBB3/viewtopic.php?f=3&t=6952) ([unless this](http://hazeron.com/phpBB3/viewtopic.php?f=5&t=6991)) )

Want to help
==============

First of all I'd love some feedback and more ideas.<br>
There are some things that I am not sure how to tackle just yet, I'll be making issues tagged with "Help Wanted" if so.<br>
But other than that, it is an open source code, so if any of you know how to write C# you can help out. ^^

Links
==============

- [GitHub](https://github.com/Deantwo/HazeronAdviser)
- [Hazeron Forum Thread](http://hazeron.com/phpBB3/viewtopic.php?f=3&t=6867)
