/**
 * Created by Antoan Elenkov on 6/10/2015.
 */
//My library

//indexOf for more than one occurrences. Returns the indexes of occurrences
function myIndexOf(text, subString) {
    var indexOccurrences = [];
    var index = text.indexOf(subString);
    //check for first match
    if (index === -1) {
        return indexOccurrences;
    }

    while (index > -1) {
        indexOccurrences.push(index);
        index = text.indexOf(subString, index + 1);
    }
    return indexOccurrences;
}

//check if a substring is in the string. Returns 'true' or 'false'
String.prototype.myContains = function (subString) {
    return this.indexOf(subString) === -1 ? false : true;
}

//myReplaceAll. Replace all 'stringToReplace' with  'newString'
String.prototype.myReplaceAll = function (stringToReplace, newString) {
    return this.split(stringToReplace).join(newString);
}

function solve1(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]), i, move;

    //fill numbers
    var matrix = [];
    var letterCode = 97;
    var letter = String.fromCharCode(97);
    //console.log(letter);
    var rowCounter = 1;

    for (var i = rows-1; i >= 0; i -= 1) {
        matrix[i] = [];
        for (var j = 0; j < cols; j += 1) {
            matrix[i][j] = String.fromCharCode(letterCode) + rowCounter;
            letterCode += 1;
        }
        rowCounter += 1;
        letterCode = 97;
    }
    //console.log(matrix.join(','));

    var figuresArr = [];

    //put figures
    for (var i = 0; i < matrix.length; i += 1) {
        figuresArr[i]=params[i+2].split('');
        for (var j = 0; j < cols; j += 1) {
            var pos=figuresArr[i][j]
            if(pos==='R'||pos==='B'||pos==='Q'){
                matrix[i][j]=pos;
            }
        }
    }
    //console.log(matrix.join(','))
    var positions = [];


var isUsed= function (row,col) {
    if(matrix[row][col]==='B'||matrix[row][col]==='Q'||matrix[row][col]==='R'){
        return true;
    }
    return false;
}

  var checkStraight=function(startRow,startCol,endRow,endCol){
      var row=startRow;
      var col=startCol;
      if(startRow===endRow){
          //direction right-horizontal
          if(startCol<=endCol) {
              for (var i = startCol+1; i <= endCol; i += 1) {
                  if (isUsed(row, i)) {
                      return true;
                  }
              }
              return false;
           //direction left-horizontal
          }else{
              for (var i = startCol-1; i >= endCol; i -= 1) {
                  if (isUsed(row, i)) {
                      return true;
                  }
              }
              return false;
          }
      }
      else{
          //direction down-vertical
          if(startRow<endRow){
              for(var i=startRow+1;i<=endRow;i+=1){
                  if(isUsed(i,col)){
                      return true;
                  }
              }
              return false;
          }
          //direction up-vertical
          else{
              //console.log('tuka sam');
              for(var i=startRow-1;i>=endRow;i-=1){
                  if(isUsed(i,col)){
                      return true;
                  }
              }
              return false;
          }
      }
  }

    var checkDiagonal=function(startRow,startCol,endRow,endCol){
        //direction down-right
        if(startRow<endRow&&startCol<endCol){
            for(var i=startRow+1,j=startCol+1;i<=endRow,j<=endCol;i+=1,j+=1){
                if(isUsed(i,j)){
                    return true;
                }
            }
            return false;
        }
        //direction down-left
        else if(startRow<endRow&&startCol>endCol){
            for(var i=startRow+1,j=startCol-1;i<=endRow,j>=endCol;i+=1,j-=1){
                if(isUsed(i,j)){
                    return true;
                }
            }
            return false;
        }
        //direction up-right
        else if(startRow>endRow&&startCol<endCol){
            for(var i=startRow-1,j=startCol+1;i>=endRow,j<=endCol;i-=1,j+=1){
                if(isUsed(i,j)){
                    return true;
                }
            }
            return false;
        }
        //direction up-left
        else{
            //console.log('tukkkk')
            for(var i=startRow-1,j=startCol-1;i>=endRow,j>=endCol;i-=1,j-=1){
                if(isUsed(i,j)){
                    return true;
                }
            }
            return false;
        }
    }


    for (i = 0; i < tests; i++) {
        move = params[rows + 3 + i];
        var beginPos=params[rows + 3 + i].split(' ')[0];
        var endPos=params[rows + 3 + i].split(' ')[1];
        var startRow=Math.abs(beginPos[1]-matrix.length);
        var startCol=beginPos[0].charCodeAt(0)-97;
        var endRow=Math.abs(endPos[1]-matrix.length);
        var endCol=endPos[0].charCodeAt(0)-97;
        var startPos=matrix[startRow][startCol];
        var endPos=matrix[endRow][endCol];
        //check if there is figure on start position
        if(startPos!=='R'&&startPos!=='B'&&startPos!=='Q'){
            console.log('no');
        }
        else if(startPos==='R'){
            //check validity of moving
            if(startRow!==endRow&&startCol!==endCol){
                console.log('no');
            }
            //check the cells in horizontal or vertical path if they are vacant(The previous 'if' guarantee that the move is horizontal or vertical)
            else if(startRow===endRow||startCol===endCol){
                if(checkStraight(startRow,startCol,endRow,endCol)){
                    console.log('no');
                }
                console.log('yes');
                continue;
            }
            else{
                console.log('yes');
            }
        }
        else if(startPos==='Q'){
            //check validity of moving
            if(startRow!==endRow&&startCol!==endCol&&(Math.abs(startRow-endRow)!==Math.abs(startCol-endCol))){
                console.log('no');
            }
            //check the cells in diagonal path if they are vacant(if applicable)
            else if(startRow!==endRow&&startCol!==endCol){
                if(checkDiagonal(startRow,startCol,endRow,endCol)){
                    console.log('no');
                    continue;
                }
                console.log('yes');
            }
            //check the cells in path if they are vacant(if applicable)
            else if(startRow===endRow||startCol===endCol){
                if(checkStraight(startRow,startCol,endRow,endCol)){
                    console.log('no');
                    continue;
                }
                console.log('yes');
            }
            else{
                console.log('yes');
            }
        }
        else if(startPos==='B'){
            //check validity of moving
            if(startRow===endRow||startCol==endCol||(Math.abs(startRow-endRow)!==Math.abs(startCol-endCol))){
                console.log('no');
            }
            //check the cells in diagonal path if they are vacant(The previous 'if' guarantee that the move is diagonal)
            else if(startRow!==endRow&&startCol!==endCol){
                if(checkDiagonal(startRow,startCol,endRow,endCol)){
                    console.log('no');
                    continue;
                }
                console.log('yes');
            }
            else{
                console.log('yes');
                break;
            }
        }
    }
}

var test1 = [
    [
        '3',
        '4',
        '--R-',
        'B--B',
        'Q--Q',
        '12',
        'd1 b3',
        'a1 a3',
        'c3 b2',
        'a1 c1',
        'a1 b2',
        'a1 c3',
        'a2 b3',
        'd2 c1',
        'b1 b2',
        'c3 b1',
        'a2 a3',
        'd1 d3',]
    ,
    [
        '5',
        '5',
        'Q---Q',
        '-----',
        '-B---',
        '--R--',
        'Q---Q',
        '10',
        'a1 a1',
        'a1 d4',
        'e1 b4',
        'a5 d2',
        'e5 b2',
        'b3 d5',
        'b3 a2',
        'b3 d1',
        'b3 a4',
        'c2 c5',
    ]
];




solve1(test1[1]);

function solve2(params) {
    //var size = params[0].split(' ').map(Number),
    //    rows = size[0],
    //    cols = size[1],
    //    matrix = params.slice(1).map(function (line) {
    //        return line.split(' ');
    //    }),
    //    col = 0,
    //    row = 0,
    //    sum = 0;
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

var test2 = [
    [],
    [],
    []
];

var args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
]
//solve2(test2[0]);


function solve3(params){
    String.prototype.myReplaceAll = function (stringToReplace, newString) {
        return this.split(stringToReplace).join(newString);
    }
var result='';
    for(var i=0;i<params.length;i+=1){
        //console.log(params[i]);
        var reg=/\s+/;
        result+=params[i].myReplaceAll(reg,'');
    }
    console.log(result);
}

var test5=[
'#the-big-b{',
'    color: yellow;',
'    size: big;',
'}',
'.muppet{',
'    powers: all;',
'    skin: fluffy;',
'}',
'.water-spirit {',
'    powers: water;',
'    alignment : not-good;',
'}',
'all{',
'    meant-for: nerdy-children;',
'}'
]
solve3(test5);
