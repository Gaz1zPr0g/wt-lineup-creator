# Lineup creator for War Thunder
If you`ve ever organized events in War Thunder with special lineups, you know how hard vehicle lineup creation is. The main task of this program is to help you with vehicle lineup creation.
> NOTE: This program downloads images from the [official War Thunder wiki](https://wiki.warthunder.com/Main_Page), so stay connected!
<br>

---

### Installation

Click [Download](https://github.com/Gaz1zPr0g/wt-lineup-creator/archive/refs/heads/main.zip) and install program manually

<br>

## How to use

`File->Open` or CTRL+O opens .json saves \
`File->Save` or CTRL+S creates .json schemes \
`File->Save as..` or CTRL+SHIFT+S creates .png/.jpeg files 

<br>

#### Countries and flags

`flag` button allows you to add your own flag. Download by link or open in file explorer \
`Country` combobox selects templates and automatically adds a country flag (if flag is unlocked). \
`flag locked` or `flag unlocked` button determines whether the flag will change when the country is selected.
> NOTE: There's no hard connection between table content and country, so you can create lineups with vehicles from different tech trees.

<br>

#### Tables and slots

![image](https://github.com/Gaz1zPr0g/wt-lineup-creator/assets/81079946/828b9c69-199f-4367-9d10-ce08f48552c7)

Vehicles are divided by 5 classes
- Tanks
- Planes
- Helicopters
- Coastal fleet
- Bluewater fleet
  
They work similarly. \
`Add row` adds rows \
`+` adds colums \
Table sizes are unlimited. 

CTRL+SHIFT+T - clear tanks table \
CTRL+SHIFT+P - clear planes table \
CTRL+SHIFT+H - clear helicopters table \
CTRL+SHIFT+C - clear coastal fleet table \
CTRL+SHIFT+B - clear bluewater fleet table 


<br>

#### Slot editing and deliting data
![image](https://github.com/Gaz1zPr0g/wt-lineup-creator/assets/81079946/59df6ea4-7b6a-4acb-ade5-20dc6740409e)
![image](https://github.com/Gaz1zPr0g/wt-lineup-creator/assets/81079946/2a70f173-2510-42c9-ac74-61b7e0262119)

The program can be run in 2 modes
1. Edit mode (to turn on press E) allows editing slots
2. Delete mode (to turn on press D) allows deleting slots data
   
The current mode is shown at the menu.

<br>

Slot editor features.
- `Vehicle name` combobox contains templates for chosen country and vehicle type. A vehicle can be found by its name.
- `Vehicle text` contains text that will be shown on the image.
- `Linked icon` combobox contains link to every icon in the game.
- `Background` combobox contains every background image in the game.
- Image preview
  
> NOTE: Im using Windows Forms, so there is no true transparency. Preview can look bad.
