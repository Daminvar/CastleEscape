
name("Sir Johnston's Room")
mapfile("bedroom1.tmx")
battleTexture("test-battle-background") //TODO

//north("todo")
west("bedroom2.js")
north("HallWay2.js")

//TODO: Change textures
var john = newNPE()
john.SetTexture("test-npe")
john.SetPosition(7, 4)

john.SetInteractFunc(function(player) {
	dialogue("Pray tell, what are you doing in my room? And why are you wearing such strange clothes?")
})

addNPE(john)

var treasureChest1 = newNPE()
//TODO: Add treasure chest texture
treasureChest1.SetPosition(2, 3)

treasureChest1.SetInteractFunc(function(player) {
	if (!getFlag("opened-bedroom-1-treasure-chest-1")) {
		dialogue("You found 50 gold coins!")
		//player.SetMoney(player.GetMoney() + 50)
		setFlag("opened-bedroom-1-treasure-chest-1")
	} else {
		dialogue("There's nothing left in the chest...")
	}
})

addNPE(treasureChest1)

var treasureChest2 = newNPE()
//TODO: Add treasure chest texture
treasureChest2.SetPosition(7, 3)

treasureChest2.SetInteractFunc(function(player) {
	if (!getFlag("opened-bedroom-1-treasure-chest-2")) {
		dialogue("You found a vial of mana potion!")
		//TODO: Add potion
		setFlag("opened-bedroom-1-treasure-chest-2")
	} else {
		dialogue("There's nothing left in the chest...")
	}
})

addNPE(treasureChest2)

//TODO: Change textures
var servant = newEnemy("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
var lazyGuard = newEnemy("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)
addRandomEncounter(servant)
addRandomEncounter(lazyGuard)