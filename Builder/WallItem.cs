namespace Builder
{
    class WallItem : ConstructionItem
    {
        public override void ShowPossiblePlacement()
        {
            // Walls can only be placed at the edges of floors. For that purpose the floor edges will have trigger colliders.
            // This method will cast a ray about 2 meters along the camera's forward vector to find those colliders.
            // When such a collider is hit we render the wall prefab as it will be placed on the floor edge and _canBuild becomes true.
            // We also update the _position and _rotation variables so if the user decides to build it, the build method can instantiate without having to calculate anything.
        }
    }
}
