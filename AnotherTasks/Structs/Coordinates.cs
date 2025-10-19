namespace AnotherTasks.Structs
{
    struct Coordinates 
    {
        public int X {  get; } // координата по X
        public int Y { get; } // координата по Y
        public int Z { get; } // координата по Z

        public Coordinates(int X, int Y, int Z)
        {
            this.X = X; 
            this.Y = Y; 
            this.Z = Z;
        }
    }  
}
