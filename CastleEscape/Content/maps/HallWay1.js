name("HallWay 1")
mapfile("HallWay1.tmx")
overworldMusic("hallway-song")
randomBattleMusic("regular-battle-song")
battleTexture("hallway-bg")

north("Kitchen1.js")
west("dungeon_4.js")
east("Hallway2.js")


var guardRob = newNPE()
guardRob.SetTexture("guard1_left")

if(getFlag("talked-to-guardRob")) {
	guardRob.SetPosition(11,10)
}
	else {
	guardRob.SetPosition(11,10)
}


guardRob.SetInteractFunc(function(player) {
	if(getFlag("talked-to-guardRob")) {
	    	dialogue("Guard Zach: You're not that strong...")
	} else {
		dialogue("Guard Zach: Hey! You don't belong here!!| Jordan: I'm the plumber, just heading to the kitchen.|Guard Zach: That might have worked on the dungeon guards, but not on us intelligent hallway guards!")
		var enemy = newEnemy("captain1_battle", "Guard Zach",50,3,2,2,10,null)
      		battle(player,enemy,"regular-battle-song")
		
		setFlag("talked-to-guardRob")
		reloadMap()
	}
})

addNPE(guardRob)

var treasureChest1H1 = newNPE()
treasureChest1H1.SetTexture("treasure")
treasureChest1H1.SetPosition(14,4)

treasureChest1H1.SetInteractFunc(function(player) {
	dialogue("You found two health potions!")
	var healthpot = newItem("Health Potion", "Restores hp",50,0,0)
	player.AddItem(healthpot)
	player.AddItem(healthpot)
	setFlag("hallway-1-chest")
	reloadMap()
})

if(!getFlag("hallway-1-chest"))
	addNPE(treasureChest1H1)


var guardF = newEnemy("soldier3_battle", "Castle Guard", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghost1_battle", "Ghost", 100, 9, 2, 3, 22, null)

addRandomEncounter(guardF)
addRandomEncounter(ghost)