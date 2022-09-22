using System.Collections;
using System.Collections.Generic;


public class Grid{
    
    public int width;
    public int height;
    private int[,] gridArray;
    public Random rand = new Random();
    // Grid class generates a random grid with width and height params based on filPercentage. 
    // The param fillPercentage is proportional a number 1. Ex: 80 fill has more walls than 50 fill.
    public Grid(int width, int height, int fillPercentage){
        this.width = width;
        this.height = height;                
        gridArray = new int[width,height];        
        for(int x=0;x<gridArray.GetLength(0);x++){            
            for(int y=0;y<gridArray.GetLength(1);y++){
                int random = rand.Next(0,100);
                if(random < fillPercentage){
                    gridArray[x,y] = 1;
                }                
                else{
                    gridArray[x,y] = 0;
                }
            }                 
        }        
    }
    // Getters and Setters
    public int[,] getGridArray(){
        return this.gridArray;
    }
    public int getWidth(){
        return this.width;
    }
    public int getHeight(){
        return this.height ;
    }
    public void setValGridArr(int posx,int posy, int val){
        this.gridArray[posx,posy] = val;
    }

    //Getters and Setters

    public override string ToString(){
        string final = "";
        for(int x=0;x<gridArray.GetLength(0);x++){            
            string linha = "";
            for(int y=0;y<gridArray.GetLength(1);y++){
                linha += gridArray[x,y].ToString();
            }
        final += linha + "\n";
        }        
        return final;
    }

    // Modify the grid grouping elements 
    public void ceilAutomata(int count){        
        int[,] grid_temp = (int[,]) this.gridArray.Clone();    // corrigir para clonar                    
        for(int i=0; i<count;i++){
            for(int x=0; x < this.getGridArray().GetLength(0);x++){
                for(int y=0; y < this.getGridArray().GetLength(1);y++){
                    int wall_count = 0;
                    for(int j = x-1; j <= x+1; j++ ){
                        for(int k = y-1; k <= y+1;k++){
                            if(is_in_bounds(j,k)){
                                if(j != x || k != y){                                
                                    if(grid_temp[j,k] == 1){
                                        wall_count++;
                                    }
                                }
                            }else{
                                wall_count++;
                            }
                        }
                    }
                    if(wall_count > 4){
                        setValGridArr(x,y,1);
                    }else{
                        setValGridArr(x,y,0);
                    }
                }
        }
        }
    }
    // return true if x and y is inside matrix 
    private bool is_in_bounds(int x, int y){
        bool before_bounds = (x < 0 || y < 0);
        bool after_bounds = (x >getWidth()-1 || y > getHeight()-1);
        if(before_bounds || after_bounds){
            return false;
        }
        return true;
    }    
    // return string grid replacing "0" to "." and "1" to "#" 
    public string bestVisualizeGrid(){
        string final = "";
        for(int i=0; i < this.getGridArray().GetLength(0);i++){
                for(int j=0; j < this.getGridArray().GetLength(1);j++){
                    int ceil = gridArray[i,j];
                   if(ceil == 1){
                        final += "# ";
                   }else{
                    final += ". ";
                   } 
            }
            final += "\n";
        }
        return final;
    }
}
