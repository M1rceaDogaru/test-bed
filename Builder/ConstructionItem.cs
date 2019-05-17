using System;

namespace Builder
{
    abstract class ConstructionItem : BuildItem
    {
        protected int _position;
        protected int _rotation;
        protected bool _canPlace;

        public abstract void ShowPossiblePlacement();

        public void PlaceItem()
        {
            if (_canPlace)
            { 
                Console.WriteLine($"{Name} placed!");
                //Instantiate(Prefab, Position, Rotation) or something like that
            }
        }
    }
}
