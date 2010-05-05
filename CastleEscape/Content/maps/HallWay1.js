
name("HallWay 1")
mapfile("HallWay1.tmx")
battleTexture("test-battle-background")

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
		dialogue("Guard Zach: Hey! You don't belong here | Jordan: I'm the plumber, just heading to the kitchen. | Guard Zach: That might have worked on the dungeon guards, but not on us intelligent hallway guards! ")
		var enemy = newEnemy("test-npe", "Guard Robert",50,3,2,2,10,null)
      		battle(player,enemy)
		
		setFlag("talked-to-guardRob")
		reloadMap()
	}
})

addNPE(guardRob)

var treasureChest1H1 = newNPE()
treasureChest1H1.SetTexture("treasure")
treasureChest1H1.SetPosition(14,4)

treasureChest1H1.SetInteractFunc(function(player) {
	if(!getFlag("hallway-1-chest"))
	{
		
		dialogue("You found two health potions!")
		var healthpot = newItem("Health Potion", "Restores hp",25,0,0)
		player.AddItem(healthpot)
		player.AddItem(healthpot)
		setFlag("hallway-1-chest")
		reloadMap()
	}
})

addNPE(treasureChest1H1)


var snake = newEnemy("snake", "snake in your boot", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "ghost from the past", 100, 9, 2, 3, 22, null)

addRandomEncounter(snake)
addRandomEncounter(ghost)