public interface IControls {
	//movement of the player
	void Movement(float _direction);

	//breaks objects
	void Shoot();

	//enter portals
	void Connect();
}