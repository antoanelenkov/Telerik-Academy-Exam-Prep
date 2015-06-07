/**
 * Created by Antoan Elenkov on 6/7/2015.
 */
//2014.01.Vehicles
function solve(params) {
    var s = parseInt(params[0]),
        count = 0,
        motor = 3,
        car = 4,
        truck = 10;

    for (var i = 0; i <= s; i += motor) {
        for (var j = 0; j <= s; j += car) {
            for (var k = 0; k <= s; k += truck) {
                if ((i + j + k) === s) {
                    count++;
                }
            }
        }
    }
    console.log(count);
}
//result 100/100

//2014.02.Paths.
function solve(params) {
    var rowsAndCols = params[0].split(' '),
        matrix = [],
        directions = [];
    matrix.length = parseInt(rowsAndCols[0]);
    directions.length = matrix.length;

    for (var i = 0; i < matrix.length; i += 1) {
        matrix[i] = [];
        matrix[i].length = parseInt((rowsAndCols[1]));
        directions[i] = [];
        directions[i].length = matrix[i].length;
    }

    for (var i = 0; i < matrix.length; i += 1) {
        var count = Math.pow(2, i);
        var dirs = params[i + 1].split(' ');
        for (var j = 0; j < matrix[i].length; j += 1) {
            matrix[i][j] = count++;
            directions[i][j] = dirs[j];
        }
    }

    var row = 0,
        col = 0,
        prevRow = 0,
        prevCol = 0,
        sum = 0;

    while (true) {
        if (row < 0 || row >= matrix.length || col < 0 || col >= matrix[0].length) {
            console.log('successed with ' + sum);
            return;
        }
        else if (directions[row][col] === 0) {
            console.log('failed at ' + '(' + row + ', ' + col + ')');
            return;
        }
        else {
            sum += matrix[row][col];
            prevCol = col;
            prevRow = row;

            switch (directions[row][col]) {
                case 'ur':
                    row--;
                    col++;
                    break;
                case 'ul':
                    row--;
                    col--;
                    break;
                case 'dr':
                    row++;
                    col++;
                    break;
                case 'dl':
                    row++;
                    col--;
                    break;
            }

            directions[prevRow][prevCol] = 0;
        }
    }
}

var args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
]
solve(args);
//result - 100/100