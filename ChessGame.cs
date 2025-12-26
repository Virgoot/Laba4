using System;

public enum MoveResult
{
    Success,
    InvalidMove,
    KingInCheck,
    Check,
    Checkmate
}

public class ChessGame
{
    public const int BoardSize = 8;
    private Piece[,] board;
    private bool whiteTurn;

    public Piece[,] Board => board;
    public bool WhiteTurn => whiteTurn;
    public string CurrentPlayerColor => whiteTurn ? "White" : "Black";

    public ChessGame()
    {
        board = CreateBoard();
        whiteTurn = true;
    }

    public void ResetGame()
    {
        board = CreateBoard();
        whiteTurn = true;
    }

    public MoveResult MakeMove(int startRow, int startCol, int endRow, int endCol)
    {
        Piece selected = board[startRow, startCol];
        string opponentColor = whiteTurn ? "Black" : "White";

        if (!IsValidMove(selected, startRow, startCol, endRow, endCol))
        {
            return MoveResult.InvalidMove;
        }

        // Сохраняем состояние для возможного отката
        Piece backup = board[endRow, endCol];
        board[endRow, endCol] = selected;
        board[startRow, startCol] = null;

        // Проверяем, не оказался ли наш король под шахом
        if (IsKingChecked(CurrentPlayerColor))
        {
            // Откатываем ход
            board[startRow, startCol] = selected;
            board[endRow, endCol] = backup;
            return MoveResult.KingInCheck;
        }

        // Ход успешен, меняем игрока
        whiteTurn = !whiteTurn;

        // Проверяем на шах и мат уже для следующего игрока
        if (IsKingChecked(opponentColor))
        {
            if (IsCheckmate(opponentColor))
            {
                return MoveResult.Checkmate;
            }
            return MoveResult.Check;
        }

        return MoveResult.Success;
    }

    private bool IsValidMove(Piece selected, int startRow, int startCol, int endRow, int endCol)
    {
        if (selected == null) return false;
        if (selected.Color != CurrentPlayerColor) return false;

        string startPos = $"{(char)('A' + startCol)}{8 - startRow}";
        string endPos = $"{(char)('A' + endCol)}{8 - endRow}";

        if (!selected.CanMove(startPos, endPos, board)) return false;

        return true;
    }

    private Piece[,] CreateBoard()
    {
        Piece[,] newBoard = new Piece[BoardSize, BoardSize];

        newBoard[7, 0] = new Rook("White"); newBoard[7, 7] = new Rook("White");
        newBoard[7, 1] = new Knight("White"); newBoard[7, 6] = new Knight("White");
        newBoard[7, 2] = new Bishop("White"); newBoard[7, 5] = new Bishop("White");
        newBoard[7, 3] = new Queen("White"); newBoard[7, 4] = new King("White");
        for (int i = 0; i < BoardSize; i++) newBoard[6, i] = new Pawn("White");

        newBoard[0, 0] = new Rook("Black"); newBoard[0, 7] = new Rook("Black");
        newBoard[0, 1] = new Knight("Black"); newBoard[0, 6] = new Knight("Black");
        newBoard[0, 2] = new Bishop("Black"); newBoard[0, 5] = new Bishop("Black");
        newBoard[0, 3] = new Queen("Black"); newBoard[0, 4] = new King("Black");
        for (int i = 0; i < BoardSize; i++) newBoard[1, i] = new Pawn("Black");

        return newBoard;
    }

    private bool IsKingChecked(string color)
    {
        var kingPos = FindKing(color);
        if (kingPos == null) return false;

        int kingRow = kingPos.Value.row;
        int kingCol = kingPos.Value.col;

        string enemyColor = color == "White" ? "Black" : "White";

        for (int r = 0; r < BoardSize; r++)
        {
            for (int c = 0; c < BoardSize; c++)
            {
                Piece piece = board[r, c];
                if (piece != null && piece.Color == enemyColor)
                {
                    if (IsValidMove(piece, r, c, kingRow, kingCol))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool IsCheckmate(string color)
    {
        if (!IsKingChecked(color)) return false;

        // Проверяем, есть ли хоть один легальный ход
        for (int r = 0; r < BoardSize; r++)
        {
            for (int c = 0; c < BoardSize; c++)
            {
                Piece piece = board[r, c];
                if (piece == null || piece.Color != color) continue;

                for (int rr = 0; rr < BoardSize; rr++)
                {
                    for (int cc = 0; cc < BoardSize; cc++)
                    {
                        if (IsValidMove(piece, r, c, rr, cc))
                        {
                            // Делаем временный ход
                            Piece backup = board[rr, cc];
                            board[rr, cc] = piece;
                            board[r, c] = null;

                            // Если после этого хода король не под шахом, то это не мат
                            if (!IsKingChecked(color))
                            {
                                // Откатываем ход
                                board[r, c] = piece;
                                board[rr, cc] = backup;
                                return false;
                            }

                            // Откатываем ход
                            board[r, c] = piece;
                            board[rr, cc] = backup;
                        }
                    }
                }
            }
        }
        // Если не найдено ни одного хода, который выводит короля из-под шаха, то это мат
        return true;
    }

    private (int row, int col)? FindKing(string color)
    {
        for (int r = 0; r < BoardSize; r++)
            for (int c = 0; c < BoardSize; c++)
                if (board[r, c] is King && board[r, c].Color == color)
                    return (r, c);
        return null;
    }
}
