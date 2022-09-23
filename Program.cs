// See https://aka.ms/new-console-template for more information

class Program
    {
        static void Main(string[] args)
        { 
            Grid grid = new Grid(50,50,60);
            System.Console.Write(grid.bestVisualizeGrid() + "\n");
            grid.ceilAutomata(6);   
            System.Console.Write(grid.bestVisualizeGrid() + "\n");
            

        }
}