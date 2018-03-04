public class Board3D {
    private int[][][] board;
    private int winner;
    private boardxy;
    private boardyz;
    private boardxz;
    
    public Board3D() {
        board = new int[15][15][15];
        winner = 0;
        boardxy = new Board2D();
        boardyz = new Board2D();
        boardxz = new Board2D();
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
     * @param
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player to make the move
     * @returns
     *   bool - whether the given move is valid
     */
    public bool isValidMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        return isValidMove(boardxy) && isValidMove(boardyz) && isValidMove(boardxz);
    }
    
    /**
     * Returns whether the given move by the given player wins the game
     * 
     * @param
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player who makes the move
     * @returns
     *   bool - whether the given move wins
     */
    private bool isWinningMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        bool xywin = boardxy.isWinningMove(x, y, player) || boardxy.won(player);
        bool yzwin = boardyz.isWinningMove(y, z, player) || boardyz.won(player);
        bool xzwin = boardxz.isWinningMove(x, z, player) || boardxz.won(player);
        
        return xywin && yzwin && xzwin;
    }
    
    /**
     * Returns whether the given player has won
     * 
     * @param
     *   int player - the player
     * @returns
     *   bool - whether the player has won
     */
    public bool won(int player) {
        checkPlayer(player);
        return winner == player;
    }
    
    /**
     * Takes in 0-indexed coordinates and makes a move at those coordinates
     * if valid.
     *
     * @param
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int player - the player who makes the move
     * @returns
     *   bool - whether the move was successfully made
     */
    public bool makeMove(int x, int y, int player) {
        checkCoord(x);
        checkCoord(y);
        checkPlayer(player);
        
        if (!isValidMove(x, y, player)) {
            return false;
        }
        
        Assert(boardxy.makeMove(x, y, player));
        Assert(boardyz.makeMove(y, z, player));
        Assert(boardxz.makeMove(x, z, player));
        
        board[x][y][z] = player;
        
        if (isWinningMove(x, y, z, player)) {
            winner = player
        }
        
        return true;
    }
    

    /**
     * Takes in 0-indexed coordinates and outputs the type of token
     * placed at the given coordinates
     * 
     * @param
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     *   int z - 0-indexed z coordinate
     * @returns
     *   int - 0 if no token is placed
     *         1 if the token placed belongs to player 1
     *         2 if the token placed belongs to player 2
     */
    public int getToken(int x, int y, int z) {
        return board[x][y][z];
    }
    
    /**
     * Takes in 0-indexed coordinates and outputs the type of token
     * placed at coordinates of the xy projection
     * 
     * @param
     *   int x - 0-indexed x coordinate
     *   int y - 0-indexed y coordinate
     * @returns
     *   int - 0 if no token is placed
     *         1 if the token placed belongs to player 1
     *         2 if the token placed belongs to player 2
     */
    public int getxyToken(int x, int y) {
        return boardxy.getToken(x, y);
    }
    
    /**
     * Takes in 0-indexed coordinates and outputs the type of token
     * placed at coordinates of the yz projection
     * 
     * @param
     *   int y - 0-indexed y coordinate
     *   int z - 0-indexed z coordinate
     * @returns
     *   int - 0 if no token is placed
     *         1 if the token placed belongs to player 1
     *         2 if the token placed belongs to player 2
     */
    public int getyzToken(int y, int z) {
        return boardyz.getToken(y, z);
    }
    
    /**
     * Takes in 0-indexed coordinates and outputs the type of token
     * placed at coordinates of the xz projection
     * 
     * @param
     *   int x - 0-indexed x coordinate
     *   int z - 0-indexed z coordinate
     * @returns
     *   int - 0 if no token is placed
     *         1 if the token placed belongs to player 1
     *         2 if the token placed belongs to player 2
     */
    public int getxzToken(int x, int z) {
        return boardxz.getToken(x, z);
    }
    
    
}