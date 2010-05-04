#ifndef SCRIPTABLEMAP_HH
#define SCRIPTABLEMAP_HH

#include <string>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

class ScriptableMap {
public:
	enum Directions {
		North, South, East, West
	};

	ScriptableMap();
	virtual ~ScriptableMap();
	int GetMapWidth();
	int GetMapHeight();
	int GetTileSize();
	std::string GetMapName();
	//sf::Image* GetBattleBackground(); //TODO
	void LoadMap(std::string filename);
	void ReloadMap();
	bool ChangeMap(Directions direction);

private:
	//TMXMap tmxMap //TODO
};

} // namespace CastleEscape

#endif // SCRIPTABLEMAP_HH
