
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
    time_of_day=night
    type=venue
    source=gh2
    creator=MiloHax
    
|Key| Value | Description |
|--|:--:|--|
| **name** | The Arena | Name of the venue, can be used on the Venue dropdown selector or any other use case in the future |
| **shortcode**| gh2_arena| Venue code to be used inside song.ini to specify a venue to be used |
| **location** | California | Just a input field, we can utilize this just for visuals when loading the song, in a tour mode, anything |
| **size** | 3 | Defines the type of venue, can be used to filter venue to be selected in a future Tour mode for example |
| **type** | venue | Defines if the venue is a proper venue or a  |
| **time_of_day** | night | Defines the time of day for the venue, can be used for any filtering we might need |
| **source**| gh2| Used to match venues with songs from same source, based on the selected setting|
| **creator** | MiloHax| Just like the charter tag used in song.ini |

### Venue Sizes
| Value | Desc |
|--|--|
| 1 | Small |
| 2 | Medium |
| 3 | Large |
| 4 | Special |

### Time of Day
| Value | Desc |
|--|--|
| day | Day |
| night | Night |
| dynamic | Uses outside light based on computers time |

### Extra fields that can be used on song.ini to specify a venue to be used

    venue=gh2_arena

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
 2. **song.ini** - Specified venue in the song.ini venue value
 3. **Source Specific** - Any random venue that has the same source as the song loaded
 4. **Selected in Settings** - Random or a specific one set in the Background Settings

---

**- What if the venue specified in the song.ini is not found inside the Venues folder for the user?**

*Selects the next Venue from the priority list.*
