public class Board2D {
    private int[][] board;
    private bool win1;
    private bool win2;
    priavte static readonly int[][] directions =
        new int[][] {
            new int[] {0, 1},
            new int[] {1, 1},
            new int[] {1, 0},
            new int[] {1, -1}
        };
    
    public Board2D() {
        board = new int[15][15];
        win1 = false;
        win2 = false;
    }
    
    /**
     * checks whether coordinate is a valid argument
     */
    private void checkCoord(int coord) {
        if (coord < 0 || coord >= 15) {
            throw new System.ArgumentException("Coordinate out of bounds", "coord");
        }
    }
    
    /**
     * checks whether player is a valid argument
     */
    private void checkPlayer(int player) {
        if (player != 1 && player != 2) {
            throw new System.ArgumentException("Player must be 1 or 2", "player");
        }
    }
    
    /**
     * Returns whether the given move by the given player is valid
     * 
     * arguments:
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player to make the move
     * returns:
     *   bool - whether the given move is valid
     */
    public bool isValidMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        return board[x][y] == 0;
    }
    
    /**
     * Returns whether the given move by the given player wins the game
     * 
     * arguments:
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player who makes the move
     * returns:
     *   bool - whether the given move wins
     */
    private bool isWinningMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        foreach (dir in directions) {
            dx = dir[0];
            dy = dir[1];
            
            int total = 0;
            
            int newx = x + dx;
            int newy = y + dy;
            while (total < 4 && newx >= 0 && newx < 15 && newy >= 0 && newy < 15) {
                if (board[newx][newy] == player) {
                    total++;
                    newx += dx;
                    newy += dy;
                } else {
                    break;
                }
            }
            newx = x - dx;
            newy = y - dy;
            while (total < 4 && newx >= 0 && newx < 15 && newy >= 0 && newy < 15) {
                if (board[newx][newy] == player) {
                    total++;
                    newx -= dx;
                    newy -= dy;
                } else {
                    break;
                }
            }
            
            if (total >= 4) {
                return true
            }
        }
        return false;
    }
    
    /**
     * Returns whether the given player has won
     * 
     * arguments:
     *   int player - the player
     * returns:
     *   bool - whether the player has won
     */
    public bool won(int player) {
        checkPlayer(player);
        if (player == 1) {
            return win1;
        } else {
            return win2;
        }
    }
    
    /**
     * Takes in 0-indexed coordinates and makes a move at those coordinates
     * if valid.
     *
     * arguments:
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player who makes the move
     * returns:
     *   bool - whether the move was successfully made
     */
    public bool makeMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        if (!isValidMove(x, y, player)) {
            return false;
        }
        
        board[x][y] = player;
        
        if (isWinningMove(x, y, player)) {
            if (player == 1) {
                win1 = true;
            } else {
                win2 = true;
            }
        }
        
        return true;
    }
    

    /**
     * Takes in 0-indexed coordinates and outputs the type of token
     * placed at the given coordinates
     * 
     * arguments:
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     * returns:
     *   int - 0 if no token is placed
     *         1 if the token placed belongs to player 1
     *         2 if the token placed belongs to player 2
     */
    public int getToken(int x, int y) {
        return board[x][y];
    }
}