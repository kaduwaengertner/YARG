# Venues

Proposal for Backgrounds in YARG (Images/Videos/Venues)

## Venue Structure
Having a Venues folder on the game (YARG/Venues)
Each folder would have this structure

> YARG/Venues/**GH2_Arena**
>  - bg.yarground
>  - venue.png/jpg
>  - venue.ini

### Structure of venue.ini

    name=The Arena
    shortcode=gh2_arena
    location=California
    size=3
    source=gh2
    creator=MiloHax
    
|Key| Value | Description |
|--|:--:|--|
| **name** | The Arena | Name of the venue, can be used on the Venue dropdown selector or any other use case in the future |
| **shortcode**| gh2_arena| Venue code to be used inside song.ini to specify a venue to be used |
| **location** | 3 | Defines the type of venue, can be used to filter venue to be selected in a future Tour mode for example |
| **source**| gh2| Used to match venues with songs from same source, based on the selected setting|
| **creator** | MiloHax| Just like the charter tag used in song.ini |

## Settings for Backgrounds

|Setting| Description | Value | 
|--|--|--|
| **Type** | Selects between Image, Video, Venues or None(Black background) | Dropdown |
| **Background** | Dropdown with the content of the type selected and a Random option on Top | Dropdown |

### Extra settings for Venues
If the user selected **Venue** in the **Type** also show this extra settings:
|Setting| Description | Value | 
|--|--|--|
| **Song Specific Overwrite** | Overwrite the selected background using the one inside the song folder | Toggle |
| **Source Specific Overwrite** | Overwrite the selected background using one venue that uses the same source from the song | Toggle|

## Venue Priority
How the venues should be loaded in case the user has all the options selected:

 1. **Song Specific** - Inside the song folder
 2. **Source Specific** - Any random venue that has the same source as the song loaded
 3. **Selected in Settings** - Random or a specific one set in the Background Settings
