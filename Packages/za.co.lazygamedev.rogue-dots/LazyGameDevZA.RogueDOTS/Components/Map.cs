﻿using System.Runtime.CompilerServices;
using Unity.Entities;

namespace LazyGameDevZA.RogueDOTS.Components
{
    [InternalBufferCapacity(0)]
    public struct Tile: IBufferElementData
    {

        public TileType Type;

        public static implicit operator Tile(TileType type) => new Tile { Type = type};

        public static implicit operator TileType(Tile tile) => tile.Type;
    }
    
    public enum TileType
    {
        Wall, Floor
    }
    
    [InternalBufferCapacity(0)]
    public struct Rect: IBufferElementData
    {
        public readonly int X1, X2, Y1, Y2;

        public Rect(int x, int y, int w, int h)
        {
            this.X1 = x;
            this.Y1 = y;
            this.X2 = x + w;
            this.Y2 = y + h;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(Rect other) => this.X1 <= other.X2 && this.X2 >= other.X1 && this.Y1 <= other.Y2 && this.Y2 >= other.Y1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (int, int) Center() => ((this.X1 + this.X2) / 2, (this.Y1 + this.Y2) / 2);
    }
    
    public struct MapDimensions : IComponentData
    {
        public int Width;
        public int Height;
    }

    [InternalBufferCapacity(0)]
    public struct RevealedTile : IBufferElementData
    {
        public bool Value;
        
        public static implicit operator RevealedTile(bool value) => new RevealedTile { Value = value };

        public static implicit operator bool(RevealedTile revealedTile) => revealedTile.Value;
    }

    [InternalBufferCapacity(0)]
    public struct VisibleTile : IBufferElementData
    {
        public bool Value;
        
        public static implicit operator VisibleTile(bool value) => new VisibleTile { Value = value };
        
        public static implicit operator bool(VisibleTile visibleTile) => visibleTile.Value;
    }
}
