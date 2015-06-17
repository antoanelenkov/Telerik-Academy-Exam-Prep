/**
 * Created by Antoan Elenkov on 6/8/2015.
 */
//01.Cakes
function solve1(params) {
    var s = +params[0],
        c1 = +params[1],
        c2 = +params[2],
        c3 = +params[3];

    var sum = 0,
        lastSum = 0,
        finalSum = 0;

    debugger;
    for (var i = 0; i <= s + c1; i += c1) {
        for (var j = 0; j <= s + c2; j += c2) {
            for (var k = 0; k <= s + c3; k += c3) {
                var currentSum = sum;
                sum = k + i + j;
                if (sum > s) {
                    if (finalSum < currentSum) {
                        finalSum = currentSum;
                    }
                    sum = 0;
                }
            }
        }
    }

    return console.log(finalSum);
}

var params = ['20',
    '11',
    '200',
    '300'];

//solve1(params);


//02.Horsy
function solve(args) {
    var dimensions = args[0].split(' ').map(Number),
        x = dimensions[0],
        y = dimensions[1],
        directionMatrix = args.slice(1).map(function (str) {
            return str.split('').map(Number);
        }),
        sum = 0,
        jumpsAmount = 0,
        startingX = x - 1,
        startingY = y - 1,
        isMoving = true;

    function getDirection(number, x, y) {

        switch (number) {
            case 1:
                x -= 2;
                y += 1;
                break;
            case 2:
                x -= 1;
                y += 2;
                break;
            case 3:
                x += 1;
                y += 2;
                break;
            case 4:
                x += 2;
                y += 1;
                break;
            case 5:
                x += 2;
                y -= 1;
                break;
            case 6:
                x += 1;
                y -= 2;
                break;
            case 7:
                x -= 1;
                y -= 2;
                break;
            case 8:
                x -= 2;
                y -= 1;
                break;
        }

        return {
            x: x,
            y: y
        };
    }

    function checkIfOut(currentRow, currentCol) {
        return currentRow < 0 || currentCol < 0 || currentRow >= x || currentCol >= y;
    }

    function findNumber(row, col) {
        return (Math.pow(2, row) - col);
    }

    var row = startingX,
        col = startingY;

    var number;
    while (isMoving) {
        //console.log(sum)
        if (checkIfOut(row, col)) {
            isMoving = false;
            console.log('Go go Horsy! Collected ' + sum + ' weeds');
        }
        else if (directionMatrix[row][col] === 0) {
            isMoving = false;
            console.log('Sadly the horse is doomed in ' + jumpsAmount + ' jumps');
        }
        else {
            sum += findNumber(row, col);//0
            number = directionMatrix[row][col];
            //console.log(directionMatrix[row][col])
            directionMatrix[row][col] = 0;
            row = getDirection(number, row, col).x;
            col = getDirection(number, row, col).y;
            jumpsAmount++;
        }
    }
}

var args = [
    '3 5',
    '54361',
    '43326',
    '52188',
];

//solve(args);

//03.Cloujure parsing
function solve3(test3) {
    //My Library
    String.prototype.myContains = function (subString) {
        return this.indexOf(subString) === -1 ? false : true;
    }
    String.prototype.myReplaceAll = function (stringToReplace, newString) {
        return this.split(stringToReplace).join(newString);
    }
    //-----------------------------------------------
    var commands = [];
    for (var i = 0; i < test3.length; i += 1) {
        var separator = /\s+/;
        commands.push(test3[i].split(separator).join(' '));
    }
    //console.log(commands);

    var result = 0;
    var insideResult = 0;
    var functions = [];
    for (var i = 0; i < commands.length; i += 1) {
        var separatedWords = commands[i].myReplaceAll('(', '').myReplaceAll(')', '').split(' ');
        var operator = separatedWords[0];
        var numberExpr = /[0-9]/;
        var result = 0;
        //remove empty strings;
        separatedWords = separatedWords.filter(Boolean);
        switch (operator) {
            case 'def':
                var instructions = commands[i].substring(6 + separatedWords[1].length).myReplaceAll('(', '').myReplaceAll(')', '').split(' ');
                instructions = instructions.filter(Boolean)
                functions[separatedWords[1]] = instructions;
                switch (instructions[0]) {
                    case numberExpr:
                        break;
                    case '+':
                        insideResult = 0;
                        for (var j = 1; j < instructions.length; j += 1) {
                            for (var key in functions) {
                                if (key === instructions[j]) {
                                    instructions[j] = functions[key];
                                    break;
                                }

                            }
                            if (!isNaN(parseInt(instructions[j]))) {
                                insideResult += parseInt(instructions[j]);
                            }
                        }
                        functions[key] = insideResult;
                        break;
                    case '-':
                        insideResult = instructions[1] * 1;
                        for (var j = 1; j < instructions.length; j += 1) {
                            for (var key in functions) {
                                if (key === instructions[j]) {
                                    if (j === 1) {
                                        insideResult = functions[key] * 1;
                                    }
                                    instructions[j] = functions[key];
                                    break;
                                }
                            }
                            if (j > 1) {
                                if (!isNaN(parseInt(instructions[j]))) {
                                    insideResult -= parseInt(instructions[j]);
                                }
                            }
                        }
                        functions[key] = insideResult;
                        break;
                    case '*':
                        insideResult = 1;
                        for (var j = 1; j < instructions.length; j += 1) {
                            for (var key in functions) {
                                if (key === instructions[j]) {
                                    instructions[j] = functions[key];
                                    break;
                                }
                            }
                            if (!isNaN(parseInt(instructions[j]))) {
                                insideResult *= parseInt(instructions[j]);
                            }
                        }
                        functions[key] = insideResult;
                        break;
                    case '/':
                        //console.log('in')
                        insideResult = insideResult[1] * 1;
                        for (var j = 1; j < instructions.length; j += 1) {
                            for (var key in functions) {
                                if (key === instructions[j]) {
                                    if (j === 1) {
                                        insideResult = functions[key] * 1;
                                    }
                                    //console.log('YEAH')
                                    instructions[j] = functions[key];
                                    //console.log('Now func is: '+instructions[j])
                                    break;
                                }
                            }
                            if (parseInt(instructions[j]) === 0) {
                                return console.log('Division by zero! At Line:' + (i + 1));
                            }
                            if (j > 1) {
                                if (!isNaN(parseInt(instructions[j]))) {
                                    insideResult = Math.floor(insideResult / (instructions[j]));
                                }
                            }
                        }
                        functions[key] = insideResult;
                }
                break;
            case '+':
                insideResult = 0;
                for (var j = 1; j < separatedWords.length; j += 1) {
                    //console.log(separatedWords[j])
                    for (var key in functions) {
                        if (key === separatedWords[j]) {
                            separatedWords[j] = functions[key];
                            break;
                        }
                    }
                    if (!isNaN(parseInt(separatedWords[j]))) {
                        insideResult += parseInt(separatedWords[j]);
                    }

                }

                break;
            case '*':
                //console.log('*******')
                //console.log('instruction: '+functions[separatedWords[1]]);
                insideResult = 1;
                for (var j = 1; j < separatedWords.length; j += 1) {
                    //console.log(separatedWords[j])
                    for (var key in functions) {
                        if (key === separatedWords[j]) {
                            separatedWords[j] = functions[key];
                            break;
                        }
                    }
                    if (!isNaN(parseInt(separatedWords[j]))) {
                        insideResult *= parseInt(separatedWords[j]);
                    }
                }
                break;
            case numberExpr:
                break;
            case '-':

                insideResult = separatedWords[1] * 1;
                for (var j = 1; j < separatedWords.length; j += 1) {
                    //console.log(separatedWords[j])
                    for (var key in functions) {
                        if (key === separatedWords[j]) {
                            if (j === 1) {
                                insideResult = functions[key] * 1;
                            }
                            separatedWords[j] = functions[key];
                            break;
                        }
                    }
                    if (j > 1) {
                        if (!isNaN(parseInt(separatedWords[j]))) {
                            insideResult -= parseInt(separatedWords[j]);
                        }
                    }
                }
                break;
            case '/':
                insideResult = separatedWords[1] * 1;
                for (var j = 1; j < separatedWords.length; j += 1) {
                    for (var key in functions) {
                        if (key === separatedWords[j]) {
                            if (j === 1) {
                                insideResult = functions[key] * 1;
                            }
                            separatedWords[j] = functions[key];
                            break;
                        }
                    }
                    if (parseInt(separatedWords[j]) === 0) {
                        return console.log('Division by zero! At Line:' + (i + 1));
                    }
                    if (j > 1) {
                        if (!isNaN(parseInt(separatedWords[j]))) {
                            insideResult = Math.floor(insideResult / (separatedWords[j]));
                        }
                    }
                }
                break;
        }
        result += insideResult;
    }
    console.log(result)
}

var test3 = [
    [
        '(def      func 10)',
        '(def   newFunc (  + func   2 ))',
        '(def sumFunc (  + func func newFunc 0   0 0    )  )',
        '(* sumFunc 2)'

    ]
    ,
    ['(def func 5)',
        '(- func)']
    ,
    ['(def func 26)',
        '(/ func 5 2   )']
    ,
    [
        '(def     lube    5)',
        '(def     Lube    6)',
        '(def pe6o (+ lube Lube ))',
        '(def joro pe6o)',
        '(           *        pe6o        joro     )'
    ]
];

solve3(test3[0]);
solve3(test3[1]);
solve3(test3[2]);
solve3(test3[3]);
//66/100 - it is unhealthy trying to read and understand this solution
