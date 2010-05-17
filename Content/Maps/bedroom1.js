
name("Sir J's Room")
mapfile("bedroom1.tmx")
<<<<<<< HEAD:Content/maps/bedroom1.js
battleTexture("bedroom-bg.png")
=======
overworldMusic("bedroom-song")
randomBattleMusic("regular-battle-song")
battleTexture("bedroom-bg")
>>>>>>> a2ce46f0bfef883f197d1131694022ed4608951a:CastleEscape/Content/maps/bedroom1.js

west("bedroom2.js")
north("HallWay2.js")

var john = newNPE()
john.SetTexture("guyHat-front.png")

if (!getFlag("gave-johnston-food")) {
	john.SetPosition(7, 4)
} else {
	john.SetPosition(4, 4)
}

john.SetInteractFunc(function(player) {
	if (!getFlag("gave-johnston-food")) {
		dialogue("Sir Johnston:Pray tell, what are you doing in my room? And why are you wearing such strange... hey! Is that food for me?|Jordan: Er, actually...|Sir Johnston: Why is that herring pie? *om-gargle-snarf*|Jordan:...|Sir Johnston: That was delicious! Here, have this item behind me.")
		setFlag("gave-johnston-food")
		reloadMap()
	} else if (!getFlag("defeated-lillina-guard")) {
		dialogue("Sir Johnston: Hey, you seem to be a pretty tough guy. I'd be willing to give you another item if you go and tell Lillina in the next room to be quiet! She's been singing all day and it's given me a massive headache.")
	} else if (!getFlag("johnston-relieved")) {
		dialogue("Sir Johnston: Ah, peace and quiet. Here, have another item.")
		setFlag("johnston-relieved")
		reloadMap()
	} else {
		dialogue("Sir Johnston: Ah, peace and quiet. Castle life is wonderful...")
	}
})

addNPE(john)

var treasureChest1 = newNPE()
treasureChest1.SetTexture("treasure.png")
treasureChest1.SetPosition(7, 3)

treasureChest1.SetInteractFunc(function(player) {
	dialogue("You found a jar of peanut butter!")
	var pb = newItem("Peanut Butter", "A jar of peanut butter", 200, 0, 0)
	player.AddItem(pb)
	setFlag("bedroom-1-treasure-chest-1")
	reloadMap()
})

if (!getFlag("bedroom-1-treasure-chest-1")) {
	addNPE(treasureChest1)
}

var treasureChest2 = newNPE()
treasureChest2.SetTexture("treasure.png")
treasureChest2.SetPosition(2, 3)

treasureChest2.SetInteractFunc(function(player) {
	dialogue("You found an aged bottle of wine!")
	var wine = newItem("Wine", "An aged bottle of wine", 0, 40, 0)
	player.AddItem(wine)
	setFlag("bedroom-1-treasure-chest-2")
	reloadMap()
})

if (getFlag("johnston-relieved") && !getFlag("bedroom-1-treasure-chest-2")) {
	addNPE(treasureChest2)
}

<<<<<<< HEAD:Content/maps/bedroom1.js
//TODO: Change textures
var servant = newEnemy("ghostie.png", "Fanatic Servant", 100, 50, 10, 10, 30, null)
var lazyGuard = newEnemy("ghostie.png", "Lazy Guard", 200, 60, 10, 5, 80, null)
=======
var servant = newEnemy("soldier1_battle", "Fanatic Servant", 180, 58, 10, 8, 45, null)
var lazyGuard = newEnemy("soldier2_battle", "Lazy Guard", 200, 55, 10, 5, 53, null)
>>>>>>> a2ce46f0bfef883f197d1131694022ed4608951a:CastleEscape/Content/maps/bedroom1.js
addRandomEncounter(servant)
addRandomEncounter(lazyGuard)
