var args = [['6 7', '5', 'UR 5', 'RD 2', 'DL 3', 'LU 6', 'DR 5'],
    ['3 3', '4', 'UR 22', 'DL 2', 'DR 8', 'UL 75']
    ,
    [
        '2 2',
        '10',
        'UR 2',
        'LD 100',
        'DR 500',
        'UL 500',
        'UL 5',
        'LD 120',
        'RD 123',
        'LU 321',
        'UR 2',
        'LD 100'
    ],
    [
        '81 61',
        '81',
        'RU 28',
        'DR 13',
        'DL 31',
        'UR 13',
        'RU 27',
        'LD 21',
        'LD 4',
        'LU 4',
        'DL 40',
        'UR 13',
        'RU 34',
        'DR 13',
        'DL 2',
        'UR 13',
        'UL 2',
        'LU 9',
        'RU 33',
        'LD 2',
        'LD 31',
        'DL 3',
        'UL 16',
        'LU 22',
        'DL 40',
        'UR 22',
        'LD 3',
        'DL 8',
        'RU 16',
        'DL 21',
        'LD 26',
        'DR 16',
        'DL 36',
        'RD 9',
        'DR 21',
        'LU 20',
        'LU 11',
        'UR 30',
        'RD 30',
        'LD 3',
        'LD 17',
        'LD 10',
        'UR 40',
        'LU 26',
        'RD 3',
        'RD 31',
        'LD 14',
        'DL 5',
        'UL 30',
        'LD 18',
        'DR 23',
        'DR 28',
        'DR 11',
        'RU 4',
        'LD 13',
        'UL 9',
        'DR 6',
        'LD 23',
        'LD 13',
        'UL 11',
        'DL 2',
        'LU 15',
        'UL 18',
        'UR 14',
        'RD 22',
        'RU 19',
        'DR 7',
        'LU 19',
        'UL 17',
        'DR 11',
        'LD 41',
        'RD 26',
        'RU 5',
        'DR 11',
        'RD 12',
        'LD 8',
        'UR 37',
        'DL 10',
        'RU 27',
        'LU 22',
        'UR 39',
        'UR 12',
        'LU 37']
    ,
    [
        '21 16',
        '21',
        'LU 3',
        'DR 8',
        'UL 5',
        'DR 8',
        'LU 10',
        'LD 7',
        'UL 6',
        'LD 2',
        'LD 7',
        'UR 2',
        'DL 10',
        'RD 3',
        'RD 9',
        'DL 4',
        'RD 2',
        'LU 3',
        'UR 9',
        'UL 5',
        'RD 9',
        'RU 5',
        'UL 7'
    ]];

function solve(args) {
    var dimensions = args[0].split(' ').map(Number),
        rowsAmount = dimensions[0],
        colsAmount = dimensions[1],
        N = +args[1],  // number of moves
        mapOfMoves = args[2].split(' '),
        directionToMove = mapOfMoves[0],
        timesToMoveToDirection = +mapOfMoves[1],
        startingR = rowsAmount - 1,
        startingC = 0,
        isMoving = true;

    //------------------------------------------------------------------------
    var arrWithMoves = args.slice(2).map(function (item) {
        return item.split(' ');
    });
    //------------------------------------------------------------------------


    function generateMatrix(rows, cols) {
        var array = [];
        var count = 0;
        var insideCount = 0;

        for (var i = rows - 1; i >= 0; i -= 1) {
            array[i] = [];

            for (var j = 0; j < cols; j += 1) {
                array[i][j] = count + insideCount;
                insideCount += 3;
            }
            count += 3;
            insideCount = 0;
        }
        return array;
    }

    function getDirection(direction, currentR, currentC) {
        switch (direction) {
            case 'UR':
                currentR -= 1;
                currentC += 1;
                break;
            case 'RU':
                currentR -= 1;
                currentC += 1;
                break;
            case 'UL':
                currentR -= 1;
                currentC -= 1;
                break;
            case 'LU':
                currentR -= 1;
                currentC -= 1;
                break;
            case 'DR':
                currentR += 1;
                currentC += 1;
                break;
            case 'RD':
                currentR += 1;
                currentC += 1;
                break;
            case 'DL':
                currentR += 1;
                currentC -= 1;
                break;
            case 'LD':
                currentR += 1;
                currentC -= 1;
                break;
        }
        return {
            currentR: currentR,
            currentC: currentC
        };
    }

    function checkValidity(row, col) {
        if (row < 0 || col < 0 || row >= rowsAmount || col >= colsAmount) {
            return {
                command: eval('break;'),
                row: lastValidRow,
                col: lastValidCol
            };
        }
        else {
            return {
                command: eval(),
                row: getDirection(direction, row, col),
                col: getDirection((direction, row, col))
            }
        }
    }


    //------------------------------------------------------------------------
    var matrix = generateMatrix(rowsAmount, colsAmount);
    var row = startingR;
    var col = startingC;
    var sum = 0;
    var lastValidRow = row;
    var lastValidCol = col;

    for (var i = 0; i < arrWithMoves.length; i += 1) {
        var direction = arrWithMoves[i][0];
        var repetitions = arrWithMoves[i][1] - 1;
        for (var j = 0; j < repetitions; j += 1) {
            row = getDirection(direction, row, col).currentR;
            col = getDirection(direction, row, col).currentC;

            if (row < 0 || col < 0 || row >= rowsAmount || col >= colsAmount) {
                row = lastValidRow;
                col = lastValidCol;
                break;
            }

            sum += matrix[row][col];
            matrix[row][col] = 0;
            lastValidRow = row;
            lastValidCol = col;
        }
    }
    //------------------------------------------------------------------------

    return console.log(sum);
}

solve(args[4]);

function Solve(input) {

    function Parser(input) {
        var result = input[0].split(" ").map(Number);
        return result;
    }

    var rowsCols = Parser(input[0]);
    var rows = rowsCols[0];
    var cols = rowsCols[1];

    function Matrix() {
        var arr = [];
        for (var i = 0; i < rows; i += 1) {
            arr[i] = [];
            for (var j = 0; j < cols; j += 1) {
                arr[i][j] = Math.pow(2, i) + j;
            }
        }
        return arr;
    }

    var matrixNums = Matrix(); //FIRST MATRIX
    function NextMatrix() {
        var arr = [];
debugger;
        for (var i = 1; i < input.length; i += 1) {
            arr[i] = [];
            console.log(input[i]);
            for (var j = 0; j < input[i].split(" ").length; j += 1) {

                arr[i][j] = input[i].split(" ")[j];
            }
        }
        return arr;
    }

    var secondMatrix = NextMatrix(); //SECOND MATRIX
    var startPosition = {
        row: 0,
        col: 0
    }

    function Move(string, obj) {

        switch (string) {
            case "dr":
                obj.row += 1; obj.col += 1;
                break;
            case "dl":
                obj.row += 1; obj.col -= 1;
                break;
            case "ur":
                obj.row -= 1; obj.col += 1;
                break;
            case "ul":
                obj.row -= 1; obj.col -= 1;
                break;

        }
    }

    var sum = 0;
    while (true) {
        if (startPosition.row < 0 || startPosition.col < 0 || startPosition.row >= rows || startPosition.col >= cols) {
            return "successed with " + sum;
        }
        if (matrixNums[startPosition.row][startPosition.col] == 'X') {
            return "failed at " + "(" + startPosition.row + ", " + startPosition.col + ")";
        }

        Move(secondMatrix[startPosition.row][startPosition.col], startPosition);
        sum += matrixNums[startPosition.row][startPosition.col];
        matrixNums[startPosition.row][startPosition.col] = 'X';




    }

}

var args2 =[
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];

Solve(args2);


