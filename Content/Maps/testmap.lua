
name = "Test Map 1"

if getFlag("poop") then
    mapfile = "testmap.tmx"
else
    mapfile = "testmap2.tmx"
end

east = "testmap2.lua"

local bob = NPE()
bob:SetTexture("test-npe.png")

if getFlag("talked-to-bob") then
	bob:SetPosition(5, 5)
else
	bob:SetPosition(12, 11)
end

self:addNPE(bob)
--[[
bob.Interact = function(player) --Sets the interact function for the specified NPE
	if getFlag("talked-to-bob") then
		dialogue("I have nothing more to say to you.") -- Pushes on a dialogue state with the selected text
	else
		dialogue("Hi, it's nice to meet you. Let's fight!")
		--newEnemy() creates a new enemy object. Parameters are...
		--texture name, enemy name, health, attack, defense, speed, exp, array of items
		var enemy = newEnemy("test-npe.png", "Bob: The Monarch of Entropy", 50000, 70, 1, 1, 10, nil)
		battle(player, enemy) --Starts a battle with the player and the enemy
		setFlag("talked-to-bob") -- Sets a flag to "true"
		reloadMap() -- Reloads the map
	end
end

-- Adds an NPE to the room. It's important that you call this function.
-- Otherwise, the NPE won't appear in the room.
addNPE(bob)

local saveOrb = newNPE()
saveOrb:SetTexture("orb-of-saving")
saveOrb:SetPosition(1, 8)

saveOrb.Interact = function(player)
	save(player) -- Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
end

addNPE(saveOrb)


local ghost = newEnemy("ghostie", "Ghost of Doom", 50, 7, 1, 1, 1000, null)
local pauper = newEnemy("snake", "Pauper of Evil", 80, 5, 1, 1, 1000, null)
addRandomEncounter(ghost) --Adds a random encounter to the room
addRandomEncounter(pauper)
]]
