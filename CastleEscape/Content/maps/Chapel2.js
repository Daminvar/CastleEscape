name("Chapel")
mapfile("Chapel2.tmx")
battleTexture("test-battle-background")

west("Chapel1.js")

var priest= newNPE()
priest.SetTexture("waiter_front")

priest.SetPosition(3,3)

priest.SetInteractFunc(function(player){
	if(!getFlag("winston-first-talk"))
	{
	dialogue("Priest Winston: Welcome! | Priest Winston: Have you come to take part in today's services or something else? | Jordan: I need help, I can't get to the armory to talk to Kristof. | Priest Windston: If you really want to visit him i can give you a special item to pass the guard, but you'll have to answer a question first. Which king saved Euphor from dire peril with his diplomatic skills? ")
	setFlag("winston-first-talk")
	}
	else if(!getFlag("holy-water"))
		dialogue("Any luck with finding out which king saved Euphor from dire peril with his diplomatic skills?")
		
else{
		dialogue("Priest Winston: Make good use of that holy water!")
		return
	}
	if(getFlag("pierre-grave-read"))
	{
		dialogue("Jordan:  That was King Pierre, who saved Euphor during dark times. | Priest Winston: Why yes! You seem to be well versed in Euphor's history, have this holy water as a reward")
		setFlag("holy-water")
	}
	else	
		dialogue("Jordan: I have no idea. | Priest Winston: Come back when you have paid your respects for the dead.")

})
	

addNPE(priest)

var churchgoer21 = newNPE()
churchgoer21.SetTexture("bGuard-back")

churchgoer21.SetPosition(2,9)

churchgoer21.SetInteractFunc(function(player){
	dialogue("Anthony: Mind your manners in church!")
})
	
addNPE(churchgoer21)

var churchgoer22 = newNPE()
churchgoer22.SetTexture("test-npe")

churchgoer22.SetPosition(14,4)

churchgoer22.SetInteractFunc(function(player){
	dialogue("Tyler: Those books on the shelves over there are some of the oldest books i've ever seen. | Jordan: Do any of them even have any useful information in them? | Tyler: EXCUSE ME? Those books are the priest's books, show some respect boy.")
})
	
addNPE(churchgoer22)


var snake = newEnemy("snake", "snake in your boot", 90, 10, 2, 2, 20, null)
var ghost = newEnemy("ghostie", "ghost from the past", 100, 9, 2, 3, 22, null)

addRandomEncounter(snake)
addRandomEncounter(ghost)