#ifndef TMXMAP_HH
#define TMXMAP_HH

#include <string>
#include <vector>

namespace CastleEscape {

struct Rectangle {
	int width;
	int height;
	int x;
	int y;
};

typedef std::vector<std::vector<std::vector<int> > > MapVector;

class TMXMap {
public:
	TMXMap();
	const MapVector& GetBaseLayers();
	const MapVector& GetTopLayers();
	int GetMapWidth();
	int GetMapHeight();
	int GetTileSize();
	void ParseTMXFile(std::string filename);
	bool IsCollisionAt(int x, int y);


private:
	MapVector baseLayers;
	MapVector topLayers;
	std::vector<Rectangle> collisionRects;
	int mapWidth;
	int mapHeight;
	int tilesize;
};

} // namespace CastleEscape

#endif // TMXMAP_HH
