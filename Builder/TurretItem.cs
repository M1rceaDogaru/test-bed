namespace Builder
{
    class TurretItem : ConstructionItem
    {
        public override void ShowPossiblePlacement()
        {
            // Turrets can only be placed on floors. This method casts a ray and displays a turret if the ray hits a floor.
            // It then measures the turret base and ensures the entire base stays on the floor. We'll need to figure out how we deal with turrets placed on two floor tiles.
            // We also need to ensure it doesn't collide with any walls.
            // If the placement is valid the _position and _rotation are updated and _canPlace becomes true.
        }
    }
}
