
name("Dungeon 3") // The name of the map (eg. "Kitchen", "Main Hallway", etc.)
mapfile("dungeon_3.tmx") // The tmx map file being used
overworldMusic("dungeon-song")
randomBattleMusic("regular-battle-song")
battleTexture("stone-wall") // The texture for the background in battles

south("dungeon_2.js")

var drunkenGuard = newNPE() // New NPE creates a new NPE object.
drunkenGuard.SetTexture("guard1_front") // Sets the overworld texture for the NPE

drunkenGuard.SetPosition(18,3)

//if (getFlag("talked-to-guard")) { //getFlag(<string>) returns true if the key is set, false otherwise
//	bob.SetPosition(21,16)
//} else {
//	bob.SetPosition(6, 9)
//}

drunkenGuard.SetInteractFunc(function(player) { //Sets the interact function for the specified NPE
	if (getFlag("has-hat")) {
		dialogue("Marim: uuuuggghhhh...||||Jordan: (Good riddance.)") // Pushes on a dialogue state with the selected text
	} else {
		dialogue("Marim: Uuugghhh... my head...|Hey, who're you...?|Jordan: ...No one important... (I need to find an exit somewhere!)||Marim: ...ain't you that prishoner...?|Jordan: (No! He's really drunk... maybe I can fool him!)|No, I'm... a janitor!|Ludovic: <A JANITOR? Really?! That wouldn't convince a fool, kid.>|Marim: ...get backta yer cell!")
		var drunkItems = []
		drunkItems[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
		var enemy = newEnemy("soldier1_battle", "Drunken Guard Marim", 60, 30, 3, 0, 30, null)
		battle(player, enemy, "regular-battle-song") //Starts a battle with the player and the enemy
		dialogue("The guard was holding a very bright red hat, which Jordan picks up.")
		setFlag("has-hat") // Sets a flag to "true"
		reloadMap() // Reloads the map
	}
})

// Adds an NPE to the room. It's important that you call this function.
//Otherwise, the NPE won't appear in the room.
addNPE(drunkenGuard)

var bar = newNPE()
bar.SetTexture("store-left")
bar.SetPosition(4, 4)

bar.SetInteractFunc(function(player) {
	var items = [] //Create a Javascript array as such.
	//newItem() creates a new item object. Parameters are...
	// Item name, item description, health bonus, mana bonus, cost
	items[0] = newItem("Bottle of Mead", "A tasty, tasty bottle of mead.", 100, 30, 10)
	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
})

addNPE(bar)

var spirits = []
spirits[0] = newItem("Spirit's Spirit", "An aged bottle of wine.", 150, 20, 0)

var ghost = newEnemy("ghost1_battle", "Ghost of Doom", 30, 25, 1, 1, 10, null)
var pauper = newEnemy("skeleton1_battle", "Skeleton of Evil", 50, 27, 1, 1, 10, null)
var spirit = newEnemy("ghost2_battle", "Spirit", 85, 22, 1, 2, 17, spirits)
addRandomEncounter(ghost) //Adds a random encounter to the room
addRandomEncounter(pauper)
addRandomEncounter(spirit)
