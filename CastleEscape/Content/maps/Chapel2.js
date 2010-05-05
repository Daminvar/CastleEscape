name("Chapel")
mapfile("Chapel2.tmx")
battleTexture("test-battle-background")

west("Chapel1.js")

var priest= newNPE()
priest.SetTexture("waiter_front")

priest.SetPosition(3,3)

priest.SetInteractFunc(function(player){
	dialogue("Priest Winston: Welcome! | Priest Winston: Have you come to take part in today's services or something else? | Jordan: I need help, I can't get to the armory to talk to NAME. Priest Windston: Why would you want to visit him? He's a rather vile man. | Jordan: Trust me, it's not my decision..|Priest Winston: Well, here take this holy water. I'm sure something like this could be useful.")
	setFlag("holy-water")
	
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