#include "TextMenu.hh"

#include <string>
#include <vector>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

TextMenu::TextMenu(const std::vector<std::string>& options,
		const sf::Font& font) {
	this->options = options;
	this->font = font;
	defaultSpacing = 0;
	canMove = false;
	isFinished = false;
	canPressZ = false;
}

void TextMenu::Update(const sf::Clock& clock) {
	/*
	 if (!isFinished) {
	 selectedSpacing = (float) (defaultSpacing + Math.Sin(Math.Log(
	 gameTime.TotalGameTime.Milliseconds)) * 20);
	 selectedSpacing = selectedSpacing / options[selectedOption].Length;
	 } else {
	 canMove = false;
	 selectedSpacing = defaultSpacing;
	 return;
	 }

	 if (state.IsKeyUp(Keys.Z))
	 canPressZ = true;

	 if (canPressZ && state.IsKeyDown(Keys.Z)) {
	 isFinished = true;
	 canPressZ = false;
	 selectedSpacing = defaultSpacing;
	 }

	 if (state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down))
	 canMove = true;
	 if (!canMove)
	 return;
	 if (state.IsKeyDown(Keys.Up)) {
	 selectedOption = selectedOption > 0 ? selectedOption - 1
	 : options.Length - 1;
	 canMove = false;
	 } else if (state.IsKeyDown(Keys.Down)) {
	 selectedOption = (selectedOption + 1) % options.Length;
	 canMove = false;
	 }
	 */
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
	for (unsigned int i = 0; i < options.size(); i++) {
		sf::String item(options[i], font);
		item.SetPosition(x, y + i * font.GetCharacterSize());
		window.Draw(item);
	}
}

} // namespace CastleEscape
