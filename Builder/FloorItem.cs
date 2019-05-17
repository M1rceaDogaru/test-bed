namespace Builder
{
    class FloorItem : ConstructionItem
    {
        public override void ShowPossiblePlacement()
        {
            // Floor items can be placed in extension of other floor items or directly on the ground if no other floor items are present.
            // For that purpose the floor items have trigger colliders on the edges to identify where other floor items would go.
            // Walls also have such a collider at the top edge, because a floor can also be used as a ceiling.

            // A ray is cast looking for those colliders and the ground. If a collider is hit, the floor prefab is rendered as an extension of the existing prefab.
            // If the ground is hit, the floor is rendered at the point on the ground where the raycast hit.
            // Additionally, a slope angle calculation is made and the floor is rendered in red and unable to be placed if the angle is too steep.

            // Every frame a floor is placed in a valid position, the _rotation and _position are updated and _canPlace becomes true.
        }
    }
}
