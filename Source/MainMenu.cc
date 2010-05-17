#include "MainMenu.hh"

#include <iostream>
#include <string>
#include <vector>
using namespace std;

#include <SFML/Graphics.hpp>

#include "StateManager.hh"
#include "TextMenu.hh"
#include "Overworld.hh"

namespace CastleEscape {

const int MENU_X = 520;
const int MENU_Y = 200;
const int MENU_FONT_SIZE = 40;

MainMenu::MainMenu() {
	background.LoadFromFile("Content/Graphics/main-menu-background.png");
	bgSprite.SetImage(background);

	sf::Font font;
	font.LoadFromFile("Content/Fonts/diavlo-bold.otf", MENU_FONT_SIZE);
	options.push_back("New Game");
	options.push_back("Load Game");
	options.push_back("About");
	options.push_back("Quit");
	menu = new TextMenu(options, font);
}

MainMenu::~MainMenu() {
	delete menu;
}

void MainMenu::Pause() {
	// TODO
}

void MainMenu::Resume() {
	// TODO
}

void MainMenu::Update(const sf::Clock& clock, const sf::Input& input) {
	menu->Update(clock, input);

	if (!menu->IsFinished())
		return;

	string selectedOption = options[menu->GetSelectedOption()];

	if (selectedOption == "New Game") {
		//TODO: Initialize player, etc.
		StateManager::PushState(new Overworld());
	} else if (selectedOption == "Load Game") {
		menu->Restart(); //TODO: Load Game
	} else if (selectedOption == "About") {
		menu->Restart(); //TODO: Port about state
	} else if (selectedOption == "Quit") {
		StateManager::PopAllStates();
	}
}

void MainMenu::Draw(sf::RenderWindow& window) {
	window.Draw(bgSprite);
	menu->Draw(window, MENU_X, MENU_Y, sf::Color(0, 0, 0));
}

} // namespace CastleEscape
