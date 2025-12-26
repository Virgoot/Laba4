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
        ResetGame();
    }

    public void ResetGame()
    {
        board = CreateBoard();
        whiteTurn = true;
    }

    public MoveResult MakeMove(int startRow, int startCol, int endRow, int endCol)
    {
        Piece selected = board[startRow, startCol];
        string currentPlayer = CurrentPlayerColor;
        string opponentPlayer = whiteTurn ? "Black" : "White";

        // Проверяем, является ли ход в принципе допустимым
        if (!IsValidMove(selected, startRow, startCol, endRow, endCol))
        {
            return MoveResult.InvalidMove;
        }

        // Временно делаем ход
        Piece backup = board[endRow, endCol];
        board[endRow, endCol] = selected;
        board[startRow, startCol] = null;

        // Проверяем, не оказался ли наш собственный король под шахом после хода
        if (IsKingChecked(currentPlayer))
        {
            // Если да, отменяем ход - это нелегальный ход
            board[startRow, startCol] = selected;
            board[endRow, endCol] = backup;
            return MoveResult.KingInCheck;
        }

        // Ход успешен, передаем очередь
        whiteTurn = !whiteTurn;

        // Теперь проверяем, поставили ли мы шах или мат сопернику
        if (IsKingChecked(opponentPlayer))
        {
            if (IsCheckmate(opponentPlayer))
            {
                return MoveResult.Checkmate;
            }
            return MoveResult.Check;
        }

        return MoveResult.Success;
    }

    // Проверяет, может ли фигура сделать такой ход по правилам (без учета шахов)
    private bool IsValidMove(Piece selected, int startRow, int startCol, int endRow, int endCol)
    {
        if (selected == null || selected.Color != CurrentPlayerColor)
        {
            return false;
        }

        // Запрещаем "съедать" короля напрямую
        Piece targetPiece = board[endRow, endCol];
        if (targetPiece is King)
        {
            return false;
        }

        string startPos = $"{(char)('A' + startCol)}{8 - startRow}";
        string endPos = $"{(char)('A' + endCol)}{8 - endRow}";

        return selected.CanMove(startPos, endPos, board);
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

    // Проверяет, может ли фигура атаковать указанную клетку
    private bool CanPieceAttack(Piece piece, int startR, int startC, int endR, int endC)
    {
        if (piece == null) return false;
        string startPos = $"{(char)('A' + startC)}{8 - startR}";
        string endPos = $"{(char)('A' + endC)}{8 - endR}";
        return piece.CanMove(startPos, endPos, board);
    }

    private bool IsKingChecked(string kingColor)
    {
        var kingPos = FindKing(kingColor);
        if (kingPos == null) return false;

        string enemyColor = kingColor == "White" ? "Black" : "White";

        for (int r = 0; r < BoardSize; r++)
        {
            for (int c = 0; c < BoardSize; c++)
            {
                Piece piece = board[r, c];
                if (piece != null && piece.Color == enemyColor)
                {
                    if (CanPieceAttack(piece, r, c, kingPos.Value.row, kingPos.Value.col))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool IsCheckmate(string kingColor)
    {
        if (!IsKingChecked(kingColor)) return false;

        // Проверяем, есть ли хоть один легальный ход, который выводит короля из-под шаха
        for (int r = 0; r < BoardSize; r++)
        {
            for (int c = 0; c < BoardSize; c++)
            {
                Piece piece = board[r, c];
                if (piece == null || piece.Color != kingColor) continue;

                for (int rr = 0; rr < BoardSize; rr++)
                {
                    for (int cc = 0; cc < BoardSize; cc++)
                    {
                        string startPos = $"{(char)('A' + c)}{8 - r}";
                        string endPos = $"{(char)('A' + cc)}{8 - rr}";

                        // Проверяем, может ли фигура в принципе пойти на эту клетку
                        if (!piece.CanMove(startPos, endPos, board)) continue;

                        // Временно делаем ход
                        Piece backup = board[rr, cc];
                        board[rr, cc] = piece;
                        board[r, c] = null;

                        // Если после этого хода король НЕ под шахом, значит, это не мат
                        if (!IsKingChecked(kingColor))
                        {
                            // Откатываем ход и возвращаем false - мы нашли спасение
                            board[r, c] = piece;
                            board[rr, cc] = backup;
                            return false;
                        }

                        // Откатываем ход в любом случае, чтобы проверить следующий
                        board[r, c] = piece;
                        board[rr, cc] = backup;
                    }
                }
            }
        }

        // Если мы перебрали все ходы и не нашли ни одного спасения, это мат
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
