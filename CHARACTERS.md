
# Characters
Character system proposal for YARG

## Character Structure

> YARG/Characters/**GH2_Axel_Steel**
>  - character.yarcharacter
>  - character.png/jpg
>  - character.ini

### Structure of character.ini
    name=Axel Steel
    shortcode=gh2_axel_steel
    source=gh2
    type=musician
    author=Neversoft
|Key| Value | Description |
|--|:--:|--|
| **name** | Axel Steel | Character name |
| **shortcode**| gh2_axel_steel| Code to specify a character to be used |
| **type** | musician| Defines if it is a playable character or a character to be used in crowd/other situations |
| **source**| gh2| Used to match characters with songs from same source, based on the selected setting|
| **author** | Neversoft | Just like the charter tag used in song.ini |

### Extra fields that can be used on song.ini to specify a character to be used

    guitarist=gh2_axel_steel
    bassist=gh2_bassist
    vocalist=gh2_vocalist_male
    drummer=gh2_drummer
    pianist=gh2_pianist
    crowd=gh2_crowd
---

### Addition to Venues:
Venues should have placeholders for each character type to specify where the character needs to spawn in the venue:

- Guitarist
- Bassist
- Pianist
- Vocalist
- Drummer
- Crowd

---

Guitarist/Bassist/Pianist/Vocalist/Drummer placeholders spawn 2 Objects:
- Character
- Instrument

---
## Customization

### Characters
#### Head
- Hat
- Hair
- Glasses
- Facial Hair
- Mask

#### Body
- Top Part
	-	Necklaces
- Arms
	- Bracelets
- Bottom Part
- Shoes

### Instruments
#### Guitar/Bass
- Headstock
- Neck
- Body

#### Drums
- Cymbals
- Pads
- Pedals

#### Keys
- Keys
- Body

#### Microphone
- Head
- Body

---

## Settings for Characters
Characters settings are only visible if the user have Venues selected as background
Each profile can have a character selected in the player settings
