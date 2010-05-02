name("Chapel")
mapfile("Chapel2.tmx")
battleTexture("test-battle-background")

west("Chapel1.js")

var priest= newNPE()
priest.SetTexture("ghostie")

priest.SetPosition(3,3)

priest.SetInteractFunc(function(player){
	dialogue("Welcome! |||| Have you come to take part in today's services or something else?")
	//Add something to allow player to enter armory after talking to priest
})
	
addNPE(priest)

var churchgoer21 = newNPE()
churchgoer21.SetTexture("snake")

churchgoer21.SetPosition(2,9)

churchgoer21.SetInteractFunc(function(player){
	dialogue("Mind your manners in church")
})
	
addNPE(churchgoer21)

var churchgoer22 = newNPE()
churchgoer22.SetTexture("test-npe")

churchgoer22.SetPosition(14,4)

churchgoer22.SetInteractFunc(function(player){
	dialogue("Those books on the shelves over there are some of the oldest books i've ever seen")
})
	
addNPE(churchgoer22)