#include "TextMenu.hh"

#include <cmath>
#include <string>
#include <vector>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

TextMenu::TextMenu(const std::vector<std::string>& options,
		const sf::Font& font) {
	this->options = options;
	this->font = font;
	defaultSpacing = 1;
	canMove = false;
	isFinished = false;
	canPressZ = false;
}

void TextMenu::Update(const sf::Clock& clock, const sf::Input& input) {
	if (!isFinished) {
		selectedSpacing = (float)(defaultSpacing + std::sin(clock.GetElapsedTime() * 5));
		selectedSpacing = 1 + selectedSpacing / options[selectedOption].size();
	} else {
		canMove = false;
		selectedSpacing = defaultSpacing;
		return;
	}

	if (!input.IsKeyDown(sf::Key::Z))
		canPressZ = true;

	if (canPressZ && input.IsKeyDown(sf::Key::Z)) {
		isFinished = true;
		canPressZ = false;
		selectedSpacing = defaultSpacing;
	}

	if (!input.IsKeyDown(sf::Key::Up) && !input.IsKeyDown(sf::Key::Down))
		canMove = true;
	if (!canMove)
		return;
	if (input.IsKeyDown(sf::Key::Up)) {
		selectedOption = selectedOption > 0 ? selectedOption - 1
				: options.size() - 1;
		canMove = false;
	} else if (input.IsKeyDown(sf::Key::Down)) {
		selectedOption = (selectedOption + 1) % options.size();
		canMove = false;
	}
}

void TextMenu::Draw(sf::RenderWindow& window, int x, int y,
		const sf::Color& color) {
	/*
	 for (int i = 0; i < options.Length; i++) {
	 var pos = new Vector2(x, y + i * font.LineSpacing);
	 if (i == selectedOption && !isFinished) {
	 pos.X += 2 * selectedSpacing;
	 font.Spacing = selectedSpacing;
	 } else
	 font.Spacing = defaultSpacing;
	 spriteBatch.DrawString(font, options[i], pos, textColor);
	 }
	 font.Spacing = defaultSpacing;
	 */
	for (uint i = 0; i < options.size(); i++) {
		sf::String item(options[i], font);
		item.SetPosition(x, y + i * font.GetCharacterSize());
		item.SetColor(color);
		if (i == selectedOption)
			item.SetScaleX(selectedSpacing);
		window.Draw(item);
	}
}

} // namespace CastleEscape
