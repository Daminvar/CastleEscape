
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
		dialogue("Guard Zach: Hey! You don't belong here |||| Jordan: I'm the plumber, just heading to the kitchen. |||| Guard Zach: That might have worked on the dungeon guards, but not on us intelligent hallway guards! ")
		var enemy = newEnemy("test-npe", "Guard Robert",50,3,2,2,10,null)
      		battle(player,enemy)
		
		setFlag("talked-to-guardRob")
		reloadMap()
	}
})

addNPE(guardRob)

var treasureChestH1 = new NPE()
treasureChestH1.Set
treasureChest1H1.SetPosition(14,4)

treasureChest1H1.SetInteractFunc(function(player) {
	if(!getFlag("hallway-1-chest"){
		
		dialogue("You found two health potions!")
		player.AddItem("Health Potion", "Restores health", 25,0,0)
		player.AddItem("Health Potion", "Restores health", 25,0,0)
	}
})

addNpe(treasureChestH1)


//TODO: Change textures
//addRandomEncounter("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
//addRandomEncounter("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)